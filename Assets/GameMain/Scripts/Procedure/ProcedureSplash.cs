
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
            // TODO: ����һ�� Splash ����������������
            // �༭��ģʽ�£�ֱ�ӽ���Ԥ�������̣����򣬼��汾

 
            ChangeState(procedureOwner, GameEntry.Base.EditorResourceMode ? typeof(ProcedurePreload) : typeof(ProcedureCheckVersion));
        }
    }
}

