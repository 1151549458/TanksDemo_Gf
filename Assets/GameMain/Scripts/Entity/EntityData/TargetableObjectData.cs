using GameFrameworkDemo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TanksDemo
{
    public abstract class TargetableObjectData : EntityData
    {

        [SerializeField]
        private CampType m_Camp = CampType.UnKnown;

        [SerializeField]
        private int currentHP = 0;

        public TargetableObjectData(int entityId, int typeId, CampType camp ,Color color)
            : base(entityId, typeId)
        {
            m_Camp = camp;
            currentHP = 0;
            SelfColor = color; 
        }

        /// <summary>
        /// ��ɫ��Ӫ��
        /// </summary>
        public CampType Camp
        {
            get
            {
                return m_Camp;
            }
        }

        /// <summary>
        /// ��ǰ������
        /// </summary>
        public int CurrentHP
        {
            get
            {
                return currentHP;
            }
            set
            {
                currentHP = value;
            }
        }

        public Color SelfColor
        {
            get;set;
        }
        /// <summary>
        /// ���������
        /// </summary>
        public abstract int MaxHP
        {
            get;
        }
        public bool IsDead { get; set; }

        /// <summary>
        /// �����ٷֱȡ�
        /// </summary>
        public float HPRatio
        {
            get
            {
                return MaxHP > 0 ? (float)CurrentHP / MaxHP : 0f;
            }
        }
        public abstract int Attack
        {
            get;
        }

        public int Level { get; set; }
 
        public float TankScale { get { return Camp == CampType.EnemyBoss ? 1.5f : 1.0f; }  }
    }
}
 