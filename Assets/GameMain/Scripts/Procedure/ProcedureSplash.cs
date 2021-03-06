
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace GameFrameworkDemo
{
    using GameFramework.Procedure;
    public class ProcedureSplash : ProcedureBase
    {
      

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
            Debug.Log("ProcedureSplash");
            // TODO: 增加一个 Splash 动画，这里先跳过
            // 编辑器模式下，直接进入预加载流程；否则，检查版本

 
            ChangeState(procedureOwner, GameEntry.Base.EditorResourceMode ? typeof(ProcedurePreload) : typeof(ProcedureCheckVersion));
        }
    }
}

