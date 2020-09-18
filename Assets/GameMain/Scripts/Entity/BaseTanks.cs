/**
 *Copyright(C) 2018 by DefaultCompany
 *All rights reserved.
 *FileName:     BaseTanks.cs
 *Author:       Pan
 *Version:      1.0
 *UnityVersion��2018.4.0f1
 *Date:         2020-09-11
 *Description:   
 *History:
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TanksDemo
{
    public interface ITanksInfo
    {
        void TakeDamage(float amount);


    }



    public class BaseTanks : MonoBehaviour
    {
        /// <summary>
        /// 坦克阵营类型
        /// </summary>
        public CampType tanksCampType;
       
        public Color tanksColor;                             // 坦克的颜色
        public Transform tranTanskPoint;
        public GameObject goInstance;

        protected TanksInfo tanksInfo;
        protected TankMovement tankMovement;
        protected TankShooting tankShooting;
        protected GameObject goHPCanvas;
        protected virtual void Awake()
        { 
           // goInstance = go; 
            tankMovement = goInstance.GetComponent<TankMovement>();
            tankShooting = goInstance.GetComponent<TankShooting>(); 
            goHPCanvas = goInstance.GetComponentInChildren<Canvas>().gameObject;
           
        }
        /// <summary>
        /// 初始化信息
        /// </summary>
        /// <param name="t"></param>
        /// <param name="info"></param>
        public virtual void InitTanks(CampType t , TanksInfo info)
        {
            tanksCampType = t;
            tanksInfo = info;
            SetTanksColor(tanksColor);
        }

        public virtual void LevelUp()
        {
            tanksInfo.Level++;
             
        }

        public virtual void SetLevel(int index)
        {
            tanksInfo.Level = index;

            if (tanksCampType == CampType.EnemyBoss)
            {
                tanksInfo.TankScale += tanksInfo.Level * 0.08f;
            }
        }

        /// <summary>
        /// 设置坦克颜色
        /// </summary>
        /// <param name="color"></param>
        public virtual void SetTanksColor(Color color)
        { 
            MeshRenderer[] renderers = goInstance.GetComponentsInChildren<MeshRenderer>(); 
            for (int i = 0; i < renderers.Length; i++)
            { 
                renderers[i].material.color = color;
            } 
        }
        public virtual void SetAttriInfo()
        {
             
        }

        /// <summary>
        /// 设置属性状态 true和false
        /// </summary>
        public virtual void SetControlStep(bool b)
        {
            tankMovement.enabled = b;
            tankShooting.enabled = b;

            goHPCanvas.SetActive(b);
        }
         
        /// <summary>
        /// 重置坦克
        /// </summary>
        public virtual void Reset()
        {
            goInstance.transform.position = tranTanskPoint.position;
            goInstance.transform.rotation = tranTanskPoint.rotation;

            goInstance.SetActive(false);
            goInstance.SetActive(true);
        }
 




    }
}