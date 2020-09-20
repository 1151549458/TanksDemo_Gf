using GameFrameworkDemo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TanksDemo { 
    public class TanksData : TargetableObjectData
    {
        [SerializeField]
        private int m_OwnerId = 0;

        [SerializeField]
        private CampType m_OwnerCamp = CampType.UnKnown;

        public TanksData(int entityId,int typeId,CampType camp,Color color) : base( entityId, typeId,  camp, color)
        { 
            CurrentHP = MaxHP;
        }

        public override int MaxHP
        {
            get;
        } 

    }
}