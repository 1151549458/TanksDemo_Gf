using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TanksDemo
{
    public class TanksInfo 
    {
        /// <summary>
        /// �ȼ�
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// ��ǰѪ��
        /// </summary>
        public int CurrentHp { get; set; }
        /// <summary>
        /// ���Ѫ��
        /// </summary>
        public int MaxHp { get { return Level * 100; } }

        /// <summary>
        /// ����
        /// </summary>
        public int Attack { get { return Level * 20; } }

        /// <summary>
        /// bossҪ���
        /// </summary>
        public float TankScale { get; set; }

    }
}