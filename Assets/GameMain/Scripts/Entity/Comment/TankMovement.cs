using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TanksDemo
{
    public class TankMovement : MonoBehaviour
    {
        private Rigidbody rigidbody;              // Reference used to move the tank.

        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody>(); 
        }

        private void OnEnable()
        {
            
        }

        private void OnDisable()
        {
            
        }

    }
}