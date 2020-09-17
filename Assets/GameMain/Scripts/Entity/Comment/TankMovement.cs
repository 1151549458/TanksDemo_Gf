using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TanksDemo
{
    public class TankMovement : MonoBehaviour
    {

        public float moveSpeed = 12f;  //ǰ���ͺ��˵��ٶ�
        public float turnSpeed = 180f;    //��ת���ٶ�
        public AudioSource movementAudio;

        public AudioClip m_EngineIdling;            //̹�˲��ƶ�ʱ�����Ƶ
        public AudioClip m_EngineDriving;           // ̹���ƶ�ʱ�� ����Ƶ


        private new Rigidbody rigidbody;              // ����
        private float originalPitch;                    //������ʼʱ�������

        private float movementInputValue;         // The current value of the movement input.
        private float turnInputValue;
        private ParticleSystem[] arrayParticleSystems; // 

        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody>(); 
             
        }
        private void Start()
        {
            originalPitch = movementAudio.pitch;
        }
        private void OnEnable()
        {
            rigidbody.isKinematic = false;

            arrayParticleSystems = GetComponentsInChildren<ParticleSystem>();
            for (int i = 0; i < arrayParticleSystems.Length; ++i)
            {
                arrayParticleSystems[i].Play();
            }

        }

        private void OnDisable()
        {
            rigidbody.isKinematic = true;
            for (int i = 0; i < arrayParticleSystems.Length; ++i)
            {
                arrayParticleSystems[i].Stop();
            }
        }


        private void FixedUpdate()
        {
            Move();
            Turn();
        }


        private void Move()
        {
        
            Vector3 movement = transform.forward * movementInputValue * moveSpeed * Time.deltaTime;


            rigidbody.MovePosition(rigidbody.position + movement);
        }
        private void Turn()
        {
            float turn = turnInputValue * turnSpeed * Time.deltaTime;

            // Make this into a rotation in the y axis.
            Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

            // Apply this rotation to the rigidbody's rotation.
            rigidbody.MoveRotation(rigidbody.rotation * turnRotation);
        }


    }
}