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
        public float m_PitchRange = 0.2f;
        private float movementHorizontalValue;         // The current value of the movement input.
        private float movementVerticalValue;
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

            movementHorizontalValue = 0f;
            movementVerticalValue = 0;
            turnInputValue = 0;

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
        private void Update()
        {
            movementVerticalValue = Input.GetAxis("Vertical");
            movementHorizontalValue = Input.GetAxis("Horizontal");

            EngineAudio();

        }
        private void EngineAudio()
        {
            // If there is no input (the tank is stationary)...
            if (Mathf.Abs(movementVerticalValue) < 0.1f && Mathf.Abs(movementHorizontalValue) < 0.1f)
            {
                // ... and if the audio source is currently playing the driving clip...
                if (movementAudio.clip == m_EngineDriving)
                {
                    // ... change the clip to idling and play it.
                    movementAudio.clip = m_EngineIdling;
                    movementAudio.pitch = Random.Range(originalPitch - m_PitchRange, originalPitch + m_PitchRange);
                    movementAudio.Play();
                }
            }
            else
            {
                // Otherwise if the tank is moving and if the idling clip is currently playing...
                if (movementAudio.clip == m_EngineIdling)
                {
                    // ... change the clip to driving and play.
                    movementAudio.clip = m_EngineDriving;
                    movementAudio.pitch = Random.Range(originalPitch - m_PitchRange, originalPitch + m_PitchRange);
                    movementAudio.Play();
                }
            }
        }
        private void FixedUpdate()
        {
            Move();
            Turn();
        }


        private void Move()
        {
            movementVerticalValue = Input.GetAxis("Vertical");
            movementHorizontalValue = Input.GetAxis("Horizontal");

            Vector3 movement0 = transform.forward * movementVerticalValue * moveSpeed * Time.deltaTime;
            Vector3 movement1 = transform.forward * movementHorizontalValue * moveSpeed * Time.deltaTime;
             
            rigidbody.MovePosition(rigidbody.position + (movement0 + movement1));
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