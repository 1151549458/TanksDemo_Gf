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

        public TanksData(int entityId,int typeId,CampType camp) : base( entityId, typeId,  camp)
        { 
            CurrentHP = MaxHP;
     
        }

        public override int MaxHP
        {
            get;
        }

        public override int Attack { get; }
    }
}