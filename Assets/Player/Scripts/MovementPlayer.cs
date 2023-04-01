using UnityEngine;

namespace SH.Player.Move
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent (typeof(CapsuleCollider))]
    internal class MovementPlayer : MonoBehaviour
    {
        [SerializeField] private InputController _inputController;

        Rigidbody playerRB;
        //Rigid Body
        [SerializeField] LayerMask groundMask;
        [SerializeField] Transform groundCheck;

        [Space(20f)] [Header("Movements")]
        [Range(0, 10)][SerializeField] float _speedOnGround;
        [Range(0, 10)][SerializeField] float _speedOnAir;

        [Range(0, 100)][SerializeField] float jumpHeight;
        [Range(0, 10)][SerializeField] float airDrag;
        [Range(0, 10)][SerializeField] float groundDrag;

        float groundDistance = 0.3f;
        float pos;
        public bool isGrounded;
        Vector2 vect;
        void Start()
        {
            playerRB = GetComponent<Rigidbody>();
            groundMask = LayerMask.GetMask("Ground");
        }
        private void Update()
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
            ControlDrag();
            Move();
        }
        void Move()
        {
            if (isGrounded)
            {
                playerRB.AddForce(pos * _speedOnGround, 0, 0, ForceMode.Force);
            }
            else
            {
                playerRB.AddForce(pos * _speedOnAir, 0, 0, ForceMode.Force);
            }
        }
        void ControlDrag()
        {
            if (isGrounded)
            {
                playerRB.drag = groundDrag;
            }
            else
            {
                playerRB.drag = airDrag;
            }
        }
        public void SetValue(float pos)
        {
            this.pos = pos;
        }
        public void Jump()
        {
            if (isGrounded)
            {
                playerRB.AddForce(transform.up * jumpHeight, ForceMode.Impulse);
            }
        }

        
        private void OnEnable()
        {
            _inputController.MoveEvent += SetValue;
            _inputController.JumpEvent += Jump;

        }
        private void OnDisable()
        {
            _inputController.MoveEvent -= SetValue;
            _inputController.JumpEvent -= Jump;
        }
    }
}
