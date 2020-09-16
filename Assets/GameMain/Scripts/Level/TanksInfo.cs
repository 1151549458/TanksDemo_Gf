using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TanksDemo
{
    public class TanksInfo 
    {
        /// <summary>
        /// 等级
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// 当前血量
        /// </summary>
        public int CurrentHp { get; set; }
        /// <summary>
        /// 最大血量
        /// </summary>
        public int MaxHp { get { return Level * 100; } }

        /// <summary>
        /// 攻击
        /// </summary>
        public int Attack { get { return Level * 20; } }

        /// <summary>
        /// boss要大点
        /// </summary>
        public float TankScale { get; set; }

    }
}