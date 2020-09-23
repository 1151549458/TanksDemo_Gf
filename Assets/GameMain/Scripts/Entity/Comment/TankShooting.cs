using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TanksDemo
{
    /// <summary>
    /// ���
    /// </summary>
    public class TankShooting : MonoBehaviour
    {

        public Rigidbody rigidbodyShell;
        public Transform tranFire;
        public Slider slider;

        public AudioSource audioShooting;         //  
        public AudioClip clipCharging;            // ���������
        public AudioClip clipFire;                // ��������


        public float minLaunchForce = 15f;        // �ӵ���С����
        public float maxLaunchForce = 30f;        // ������ʱ�������
        public float maxChargeTime = 0.75f;       // ����ʱ��
         
        private bool isFire;                        //�Ƿ���
        private float chargeSpeed;                 //�����ٶ�
        private float currentLaunchForce;          //��ǰ�������յ�����
       

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