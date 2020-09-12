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
            GameFrameworkDemo.GameEntry.Event.Subscribe(OpenUIFormSuccessEventArgs.EventId, OnOpenUIFormSuccess);
            GameFrameworkDemo.GameEntry.UI.OpenUIForm(Constant.AssetPath.GetUI.StartMenuPath, "one", this);
            //  GameFrameworkDemo.GameEntry.Entity.ShowEntity<CubeLogic>(1, Constant.AssetPath.GetEntity.CubePath, "one", this); 

            isChangeGame = false;
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
        }
        protected override void OnDestroy(ProcedureOwner procedureOwner)
        {
            base.OnDestroy(procedureOwner);
        }
    }
}