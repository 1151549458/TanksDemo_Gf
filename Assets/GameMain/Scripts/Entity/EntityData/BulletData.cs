using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFrameworkDemo;
namespace TanksDemo
{
    public class BulletData:EntityData
    {
        [SerializeField]
        private CampType m_Camp = CampType.UnKnown;
         
        public BulletData(int entityId, int typeId, CampType camp)
            : base(entityId, typeId)
        {
            m_Camp = camp;
               
        }
         
    }
}