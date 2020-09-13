/**
 *Copyright(C) 2018 by DefaultCompany
 *All rights reserved.
 *FileName:     ProcedureChangeScene.cs
 *Author:       Pan
 *Version:      1.0
 *UnityVersion��2018.4.0f1
 *Date:         2020-07-06
 *Description:   
 *History:
*/
using GameFramework.Procedure;
using UnityGameFramework.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;
using GameFramework.Event;
using System;
using TanksDemo;

namespace GameFrameworkDemo
{
    public class ProcedureChangeScene : ProcedureBase
    {
        private bool isEnterMenuScene;
        private bool isEnterGameScene;

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);
            Debug.Log("ProcedureChangeScene"  );
            //切场景 
         
            isEnterMenuScene = true;
            isEnterGameScene = false;

            ChangeState<ProcedureMenu>(procedureOwner);
        }

        public void SetChange(bool b)
        {
            isEnterMenuScene = b;
            isEnterGameScene = !b;
        }

        protected override void OnInit(ProcedureOwner procedureOwner)
        {
            base.OnInit(procedureOwner);
        }
        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

            

            if (isEnterMenuScene)
            {
                ChangeState<ProcedureMenu>(procedureOwner);
            }
            if (isEnterGameScene)
            {
                ChangeState<ProcedureGame>(procedureOwner);
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                //加载场景场景 
                GameEntry.Scene.LoadScene(Constant.AssetPath.GetScene.MainScenePath, this); 
            }
            if (Input.GetKeyDown(KeyCode.B))
            {
                GameEntry.Scene.UnloadScene(Constant.AssetPath.GetScene.MainScenePath, this);
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
            //    ChangeState<ProcedureHome>(procedureOwner); 
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
