using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;
using GameFrameworkDemo;
using GameFramework.Procedure;
using UnityGameFramework.Runtime;
using GameFramework.Event;

namespace TanksDemo
{
    public class ProcedureMenu : ProcedureBase
    {
        StartMenuPanelLogic uIMenuStartLogic;
        private bool isChangeGame;
        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);
            Debug.Log("ProcedureMenu");
            //Open UI

            GameFrameworkDemo.GameEntry.Event.Subscribe(LoadSceneSuccessEventArgs.EventId, OnLoadSceneSuccess);
            GameFrameworkDemo.GameEntry.Event.Subscribe(LoadSceneFailureEventArgs.EventId, OnLoadSceneFailure);

            GameFrameworkDemo.GameEntry.Scene.LoadScene(Constant.AssetPath.GetScene.MenuScenePath, this);
            GameFrameworkDemo.GameEntry.Event.Subscribe(OpenUIFormSuccessEventArgs.EventId, OnOpenUIFormSuccess);
            GameFrameworkDemo.GameEntry.UI.OpenUIForm(Constant.AssetPath.GetUI.StartMenuPath, "one", this);
            //  GameFrameworkDemo.GameEntry.Entity.ShowEntity<CubeLogic>(1, Constant.AssetPath.GetEntity.CubePath, "one", this); 

            isChangeGame = false;

          //  GameFrameworkDemo.GameEntry.UI.OpenUIForm( UIFormId.IntroduceForm);

        }
        protected override void OnInit(ProcedureOwner procedureOwner)
        {
            base.OnInit(procedureOwner);
          
        }
        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
            if (!isChangeGame) { return; }
            if (isChangeGame)
            {
                ChangeState<ProcedureGame>(procedureOwner);
            }

        }
        private void OnLoadSceneSuccess(object sender, GameEventArgs e)
        {
            LoadSceneSuccessEventArgs ne = (LoadSceneSuccessEventArgs)e;
            if (ne.UserData != this)
            {
                return;
            }
            Log.Info("Load scene '{0}' OK.", ne.SceneAssetName); 

        }
        private void OnLoadSceneFailure(object sender, GameEventArgs e)
        {
            LoadSceneFailureEventArgs ne = (LoadSceneFailureEventArgs)e;
            if (ne.UserData != this)
            {
                return;
            }
            Log.Error("Load scene '{0}' failure, error message '{1}'.", ne.SceneAssetName, ne.ErrorMessage);
        }
        public void StartGameClick()
        {
            isChangeGame = true;
        }


        private void OnOpenUIFormSuccess(object sender, GameEventArgs e)
        {
            OpenUIFormSuccessEventArgs ne = (OpenUIFormSuccessEventArgs)e;
            if (ne.UserData != this)
            {
                return;
            }

            uIMenuStartLogic = (StartMenuPanelLogic)ne.UIForm.Logic;

        }
        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);

            GameFrameworkDemo.GameEntry.Scene.UnloadScene(Constant.AssetPath.GetScene.MenuScenePath, this);
            GameFrameworkDemo.GameEntry.UI.CloseUIForm(uIMenuStartLogic); //用加载回调赋值方法隐藏

            GameFrameworkDemo.GameEntry.Event.Unsubscribe(OpenUIFormSuccessEventArgs.EventId, OnOpenUIFormSuccess);

            

            GameFrameworkDemo.GameEntry.Event.Unsubscribe(LoadSceneSuccessEventArgs.EventId, OnLoadSceneSuccess);
            GameFrameworkDemo.GameEntry.Event.Unsubscribe(LoadSceneFailureEventArgs.EventId, OnLoadSceneFailure);




        }
        protected override void OnDestroy(ProcedureOwner procedureOwner)
        {
            base.OnDestroy(procedureOwner);
        }
    }
}