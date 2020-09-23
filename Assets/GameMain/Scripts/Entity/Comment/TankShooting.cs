using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TanksDemo
{
    /// <summary>
    /// 射击
    /// </summary>
    public class TankShooting : MonoBehaviour
    {

        public Rigidbody rigidbodyShell;
        public Transform tranFire;
        public Slider slider;

        public AudioSource audioShooting;         //  
        public AudioClip clipCharging;            // 充电声音吧
        public AudioClip clipFire;                // 发射声音


        public float minLaunchForce = 15f;        // 子弹最小的力
        public float maxLaunchForce = 30f;        // 最大充能时间给的力
        public float maxChargeTime = 0.75f;       // 充能时间
         
        private bool isFire;                        //是否发射
        private float chargeSpeed;                 //充能速度
        private float currentLaunchForce;          //当前充能所收到的力
       

        private void Start()
        {
            chargeSpeed = (maxLaunchForce - minLaunchForce) / maxChargeTime;
        }

        private void OnEnable()
        {

            currentLaunchForce = minLaunchForce;
            slider.value = minLaunchForce;
        }
     
        private void Update()
        {
            

        }

        private void Fire()
        {
            isFire = true;
             

        }



    }

}