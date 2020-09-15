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
    public class BaseTanks : MonoBehaviour
    {
        public Color tanksColor;                             // 坦克的颜色
        public Transform tranTanskPoint;
        public GameObject goInstance;

        protected TankMovement tankMovement;
        protected TankShooting tankShooting;
        protected GameObject goHPCanvas;
        public virtual void SetUp(GameObject go)
        {
            goInstance = go; 
            tankMovement = goInstance.GetComponent<TankMovement>();
            tankShooting = goInstance.GetComponent<TankShooting>(); 
            goHPCanvas = goInstance.GetComponentInChildren<Canvas>().gameObject; 
            SetTanksColor(tanksColor);


        }

         
        /// <summary>
        /// 设置坦克颜色
        /// </summary>
        /// <param name="color"></param>
        public void SetTanksColor(Color color)
        { 
            MeshRenderer[] renderers = goInstance.GetComponentsInChildren<MeshRenderer>(); 
            for (int i = 0; i < renderers.Length; i++)
            { 
                renderers[i].material.color = color;
            }

        }


        /// <summary>
        /// 设置属性状态 true和false
        /// </summary>
        public void SetControlStep(bool b)
        {
            tankMovement.enabled = b;
            tankShooting.enabled = b;

            goHPCanvas.SetActive(b);
        }

 

        /// <summary>
        /// 重置坦克
        /// </summary>
        public void Reset()
        {
            goInstance.transform.position = tranTanskPoint.position;
            goInstance.transform.rotation = tranTanskPoint.rotation;

            goInstance.SetActive(false);
            goInstance.SetActive(true);
        }


    }
}