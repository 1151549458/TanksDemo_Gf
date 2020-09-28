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

        [SerializeField]
        private int m_DeadEffectId = 0;

        public TargetableObjectData(int entityId, int typeId, CampType camp)
            : base(entityId, typeId)
        {
            m_Camp = camp;
            currentHP = 0;
          
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
        public int DeadEffectId { get; set; }
        public int DeadSoundId { get; set; }
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
 