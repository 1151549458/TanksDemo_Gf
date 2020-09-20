using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TanksDemo
{
    public class EnemtyTanksData : TanksData
    {
        [SerializeField]
        private string m_Name = null;
        public EnemtyTanksData(int entityId, int typeId) : base(entityId, typeId, CampType.Player,new Color(229, 46,40,1))
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
            get { return 100 + Level * 10; }

        }
    }
}