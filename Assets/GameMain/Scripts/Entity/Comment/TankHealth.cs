using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TanksDemo
{
    public class TankHealth : MonoBehaviour
    {

        public float startingHealth = 100;
        public Slider slider;
        public Image fillImage;
        public Color fullHealthColor = Color.green;
        public Color zeroHealthColor = Color.red;

        public GameObject goExplosion; //À¿Õˆ ±∫Úµ˜”√

        private AudioSource audioSource;               // The audio source to play when the tank explodes.
        private ParticleSystem explosionParticles;        // The particle system the will play when the tank is destroyed.
        private float currentHealth;                      // How much health the tank currently has.
        private bool isDead;                                // Has the tank been reduced beyond zero health yet?


        // Start is called before the first frame update
        void Awake()
        {

        }

        private void OnEnable()
        {
            
        }

        public void TakeDamage(float amount)
        {
            currentHealth -= amount;

            SetHealthUI();
            if (currentHealth <= 0 && !isDead)
            {
                OnDeath();
            }
        }

        private void SetHealthUI()
        {
            slider.value = currentHealth;

            fillImage.color = Color.Lerp(zeroHealthColor, fullHealthColor, currentHealth / startingHealth); 
        }
        void OnDeath()
        {
            isDead = true;

            explosionParticles.transform.position = transform.position;
            explosionParticles.gameObject.SetActive(true);

            explosionParticles.Play();

            audioSource.Play();

            gameObject.SetActive(false);

        }

    }
}