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
using UnityGameFramework.Runtime;
using GameFrameworkDemo;
using UnityEngine.UI;
namespace TanksDemo
{ 
    public abstract class BaseTanks : EntityLogic
    {
        ///// <summary>
        ///// 坦克阵营类型
        ///// </summary>
        //public CampType tanksCampType;
       
        private Color tanksColor;                             // 坦克的颜色
        public Transform tranTanskPoint;


        protected Slider healthSlider;
        protected TanksInfo tanksInfo;
        protected TankMovement tankMovement;
        protected TankShooting tankShooting;
        protected GameObject goHPCanvas;
        protected Image fillImage;
        private TargetableObjectData targetableObjectData = null;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            tankMovement = GetComponent<TankMovement>();
            tankShooting = GetComponent<TankShooting>();
            goHPCanvas = GetComponentInChildren<Canvas>().gameObject;
            healthSlider = transform.Find("Canvas/HealthSlider").GetComponent<Slider>();
            fillImage = healthSlider.transform.GetChild(1).GetChild(0).GetComponent<Image>();
        }
        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
            targetableObjectData = userData as TargetableObjectData;
            tanksColor = targetableObjectData.SelfColor;

            SetTanksColor(targetableObjectData.SelfColor);
        }
        protected override void OnHide(bool isShutdown, object userData)
        {
            base.OnHide(isShutdown, userData);
        }
        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);
        }

        protected override void OnRecycle()
        {
            base.OnRecycle();
        } 

        public virtual void LevelUp()
        {
            tanksInfo.Level++;
             
        }

        public virtual void SetLevel(int index)
        {
            tanksInfo.Level = index; 
        }

        /// <summary>
        /// 设置坦克颜色
        /// </summary>
        /// <param name="color"></param>
        public virtual void SetTanksColor(Color color)
        { 
            MeshRenderer[] renderers = GetComponentsInChildren<MeshRenderer>(); 
            for (int i = 0; i < renderers.Length; i++)
            { 
                renderers[i].material.color = color;
            } 
        }

        public void TakeDamage(int amount)
        {
            targetableObjectData.CurrentHP -= amount;

            SetHealthUI();
            if (targetableObjectData.CurrentHP <= 0 && !targetableObjectData.IsDead)
            {
                OnDeath();
            }
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
            transform.position = tranTanskPoint.position;
            transform.rotation = tranTanskPoint.rotation;

            gameObject.SetActive(false);
            gameObject.SetActive(true);
        }


        protected void SetHealthUI()
        { 
            healthSlider.value = targetableObjectData.HPRatio;

            fillImage.color = Color.Lerp(Color.red, Color.green, targetableObjectData.CurrentHP / targetableObjectData.MaxHP);
            
        }

        protected virtual void OnDeath()
        {
            targetableObjectData.IsDead = true; 
            gameObject.SetActive(false);

        }
    }
}