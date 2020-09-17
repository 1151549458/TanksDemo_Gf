using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TanksDemo
{
    public class TankMovement : MonoBehaviour
    {

        public float moveSpeed = 12f;  //前进和后退的速度
        public float turnSpeed = 180f;    //旋转的速度
        public AudioSource movementAudio;

        public AudioClip m_EngineIdling;            //坦克不移动时候的音频
        public AudioClip m_EngineDriving;           // 坦克移动时候 的音频


        private new Rigidbody rigidbody;              // 重力
        private float originalPitch;                    //场景开始时候的音量

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