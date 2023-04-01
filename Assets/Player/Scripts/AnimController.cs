using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using SH.Player.Move;

namespace SH.Player.Animation
{
    internal class AnimController : MonoBehaviour
    {
        [SerializeField] private InputController gameInput;
        [SerializeField] private Animator animator;
        [SerializeField] private MovementPlayer movementPlayer;

        private Rigidbody _rigidbody;

        private bool isGrounded => movementPlayer.isGrounded;


        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
        private void Update()
        {
            animator.SetFloat("speed", _rigidbody.velocity.magnitude);
            animator.SetBool("isGround", isGrounded);
        }
    }
}
