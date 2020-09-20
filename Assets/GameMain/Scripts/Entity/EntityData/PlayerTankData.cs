using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TanksDemo
{
    public class PlayerTankData : TanksData
    {
        [SerializeField]
        private string m_Name = null;
        public PlayerTankData(int entityId, int typeId) : base(entityId, typeId, CampType.Player,new Color(42,100, 178,1))
        {
             
        }
        /// <summary>
        /// ½ÇÉ«Ãû³Æ¡£
        /// </summary>
        public string Name
        {
            get
            {
                return m_Name;
            }
            set
            {
                m_Name = value;
            }
        }
        public override int MaxHP
        {
            get { return Level * 100; }

        }

    }
}