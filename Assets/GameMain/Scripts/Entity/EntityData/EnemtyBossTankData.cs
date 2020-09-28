using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TanksDemo { 
    public class EnemtyBossTankData : TanksData
    {
 
        [SerializeField]
        private string m_Name = null;
        public EnemtyBossTankData(int entityId, int typeId) : base(entityId, typeId, CampType.EnemyBoss )
        {
            //new Color(212, 0, 0, 1)
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
            get { return 100 + Level * 10; } 
        }
        public override int Attack
        {
            get { return 15 + Level * 15; }
        }

    }
}
