/**
 *Copyright(C) 2018 by DefaultCompany
 *All rights reserved.
 *FileName:     ProcedureMyself.cs
 *Author:       Pan
 *Version:      1.0
 *UnityVersion��2018.4.0f1
 *Date:         2020-07-03
 *Description:   
 *History:
*/
using System;
using System.Collections;
using System.Collections.Generic;
using GameFramework.Event;
using GameFramework.Fsm;
using GameFramework.Procedure;
using UnityEngine;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;
namespace GameFrameworkDemo
{
    public class ProcedureHome : ProcedureBase
    {
        int index = 0;
        UIMenuLogic uIMenuLogic;
        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);

            Debug.Log("ProcedureHome");
            //配表调用接口
            //    GameEntry.UI.OpenUIForm(UIFormId.AboutForm);

            //正常调用

            GameEntry.Event.Subscribe(OpenUIFormSuccessEventArgs.EventId, OnOpenUIFormSuccess);

            GameEntry.Entity.ShowEntity<CubeLogic>(1, Constant.AssetPath.GetEntity.CubePath, "one", this);
            GameEntry.Entity.HideEntity(1);
            //加载资源   
         //   GameEntry.Resource.InitResources(ResourcesCallback);
        }

        private void OnOpenUIFormSuccess(object sender, GameEventArgs e)
        {
            OpenUIFormSuccessEventArgs ne = (OpenUIFormSuccessEventArgs)e;
            if (ne.UserData != this)
            {
                return;
            }

            uIMenuLogic = (UIMenuLogic)ne.UIForm.Logic;
        }

        void ResourcesCallback()
        {
            Log.Info("加载资源");
        }
        protected override void OnInit(ProcedureOwner procedureOwner)
        {
            base.OnInit(procedureOwner);
        }
        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

            if (Input.GetKeyDown(KeyCode.Q))
            {
                index = GameEntry.UI.OpenUIForm(Constant.AssetPath.GetUI.LoginPanlePath, "one", this);
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                GameEntry.UI.CloseUIForm(index); // 用ID方式隐藏
                GameEntry.UI.CloseUIForm(uIMenuLogic); //用加载回调赋值方法隐藏
            }


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