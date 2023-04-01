using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace SH.PMechanics.Portal
{
    //[RequireComponent(typeof(BoxCollider))]
    internal class Portals : MonoBehaviour
    {
        private Transform startPortal;
        [SerializeField] private Transform endPortal;
        [SerializeField] private float delay = 0.1f; // delay before portal can be used again

        [HideInInspector] public float lastUseTime; // time of the last portal use

        private Portals _endPortal;

        private void Start()
        {
            startPortal = transform;
            _endPortal = endPortal.GetComponent<Portals>();
        }

        void OnTriggerEnter(Collider other)
        {
            // Check if enough time has passed since the last portal use.
            if (Time.time - lastUseTime > delay)
            {
                // Set the time of the last portal use.
                lastUseTime = Time.time;
                _endPortal.lastUseTime = lastUseTime;
                Debug.Log($"Игрок был телепортирован из {startPortal.position} в {endPortal.position}. \nВремя {lastUseTime}");

                // Get the rigidbody of the object that collided with the portal.
                Rigidbody rb = other.GetComponent<Rigidbody>();

                // Calculate the direction from the start portal to the end portal.
                Vector3 direction = (endPortal.position - startPortal.position).normalized;

                // Calculate the velocity the object needs to travel in order to reach the end portal.
                Vector3 velocity = direction * rb.velocity.magnitude;

                // Set the velocity of the object that collided with the portal.
                rb.velocity = velocity;

                // Set the position of the object to the position of the end portal.
                rb.position = endPortal.position;
            }
        
        }
}
}
