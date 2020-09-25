/**
 *Copyright(C) 2018 by DefaultCompany
 *All rights reserved.
 *FileName:     ProcedurePreload.cs
 *Author:       Pan
 *Version:      1.0
 *UnityVersion��2018.4.0f1
 *Date:         2020-07-06
 *Description:   
 *History:
*/
using GameFramework;
using GameFramework.Fsm;
using GameFramework.Procedure;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;
namespace GameFrameworkDemo
{
    public class ProcedurePreload : ProcedureBase
    {
        public static readonly string[] DataTableNames = new string[]
        {
            "test01", // 这是个测试资源，并没有使用 
            "Entity",
            "Music",
            "Sound", 
            "UIForm",
            "UISound",
          /*   "Scene", ,
         */
        };
        private Dictionary<string, bool> m_LoadedFlag = new Dictionary<string, bool>();

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);

          //  m_LoadedFlag.Clear();

            Debug.Log("ProcedurePreload");
        }

        protected override void OnInit(ProcedureOwner procedureOwner)
        {
            base.OnInit(procedureOwner);
        }
        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);
        }

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
        }

        protected override void OnDestroy(ProcedureOwner procedureOwner)
        {
            base.OnDestroy(procedureOwner);
        }
    }
}