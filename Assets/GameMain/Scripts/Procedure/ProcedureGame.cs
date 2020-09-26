/**
 *Copyright(C) 2018 by DefaultCompany
 *All rights reserved.
 *FileName:     ProcedureGame.cs
 *Author:       Pan
 *Version:      1.0
 *UnityVersion��2018.4.0f1
 *Date:         2020-09-11
 *Description:   
 *History:
*/
using GameFramework.Procedure;
using System.Collections;
using System.Collections.Generic; 
using UnityEngine;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;
using GameFrameworkDemo;
using UnityGameFramework.Runtime;
using GameFramework.Event;

namespace TanksDemo
{
    public class ProcedureGame : ProcedureBase
    {
        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);
            Debug.Log("ProcedureGame");
            //切场景 
            GameFrameworkDemo.GameEntry.Event.Subscribe(LoadSceneSuccessEventArgs.EventId, OnLoadSceneSuccess);
            GameFrameworkDemo.GameEntry.Event.Subscribe(LoadSceneFailureEventArgs.EventId, OnLoadSceneFailure);

            GameFrameworkDemo.GameEntry.Scene.LoadScene(Constant.AssetPath.GetScene.MainScenePath, this);


            GameFrameworkDemo.GameEntry.Entity.ShowPlayerTanks(new PlayerTankData(GameFrameworkDemo.GameEntry.Entity.GenerateSerialId(),10000));


        }
        protected override void OnInit(ProcedureOwner procedureOwner)
        {
            base.OnInit(procedureOwner);
        }
        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
            //if (Input.GetKeyDown(KeyCode.A))
            //{
            //    //加载场景场景 
            //    GameEntry.Scene.LoadScene(Constant.AssetPath.GetScene.MainScenePath, this);
            //}
            //if (Input.GetKeyDown(KeyCode.B))
            //{
            //    GameEntry.Scene.UnloadScene(Constant.AssetPath.GetScene.MainScenePath, this);
            //}

            //if (Input.GetKeyDown(KeyCode.Alpha1))
            //{
            //    ChangeState<ProcedureHome>(procedureOwner);
            //}

        }

        private void OnLoadSceneSuccess(object sender, GameEventArgs e)
        {
            LoadSceneSuccessEventArgs ne = (LoadSceneSuccessEventArgs)e;
            if (ne.UserData != this)
            {
                return;
            }
            Log.Info("Load scene '{0}' OK.", ne.SceneAssetName);
         //   isEnterGameScene = true;
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
        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);
             
            GameFrameworkDemo.GameEntry.Event.Unsubscribe(LoadSceneSuccessEventArgs.EventId, OnLoadSceneSuccess);
            GameFrameworkDemo.GameEntry.Event.Unsubscribe(LoadSceneFailureEventArgs.EventId, OnLoadSceneFailure);

            GameFrameworkDemo.GameEntry.Scene.UnloadScene(Constant.AssetPath.GetScene.MainScenePath, this);
             
        }
        protected override void OnDestroy(ProcedureOwner procedureOwner)
        {
            base.OnDestroy(procedureOwner);
        }
    }
}