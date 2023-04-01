using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SH.Player.Hook
{
    internal class GrapplingHook : MonoBehaviour
    {
        [SerializeField] private InputController _inputController;
        private void OnEnable()
        {
            _inputController.CreateHookEvent += CreateHook;
            _inputController.DisableHookEvent += DisableHook;
        }
        private void OnDisable()
        {
            _inputController.CreateHookEvent -= CreateHook;
            _inputController.DisableHookEvent -= DisableHook;
        }

        HookRaycaster hookRaycaster;
        HookRenderer hookRenderer;
        [SerializeField] LayerMask layer;

        SpringJoint _springJoint;

        private void Awake()
        {
            //hookRaycaster = new HookRaycaster();
            //hookRenderer = new HookRenderer();
        }

        public void CreateHook()
        {
            Collider[] hits = Physics.OverlapSphere(transform.position, 20, layer);
            Collider hit = hits[0];
            foreach (var item in hits)
            {
                Debug.Log(item.transform.name);
            }
            Vector3 grapplePoint = hit.transform.position;
            _springJoint = transform.gameObject.AddComponent<SpringJoint>();
            _springJoint.autoConfigureConnectedAnchor = false;
            //springJoint.connectedBody = hit.transform.GetComponent<Rigidbody>();
            _springJoint.connectedAnchor = grapplePoint;
            float grapleDistance = Vector3.Distance(transform.position, grapplePoint);
            _springJoint.maxDistance = grapleDistance;
            _springJoint.minDistance = grapleDistance - 2;

            //TODO добавить поля
            _springJoint.damper = 10;
            _springJoint.spring = 5;
        }
        public void DisableHook()
        {
            Destroy(_springJoint);
        }
    }
}