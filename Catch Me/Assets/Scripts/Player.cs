using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(PlayerController))]
    [RequireComponent(typeof(GunController))]
    public class Player : MonoBehaviour {

        public float MoveSpeed = 5;
        private Camera _viewCamera;
        private PlayerController _controller;
        private GunController _gunController;
        void Start()
        {
            _controller = GetComponent<PlayerController>();
            _gunController = GetComponent<GunController>();
            _viewCamera = Camera.main;
        }

        // Update is called once per frame
        void Update()
        {
            //Move Input
            Vector3 moveInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            Vector3 moveVelocity = moveInput.normalized * MoveSpeed;
            _controller.Move(moveVelocity);

            //Look Input
            Ray ray = _viewCamera.ScreenPointToRay(Input.mousePosition);
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
            float rayDistance;

            if (groundPlane.Raycast(ray, out rayDistance))
            {
                Vector3 point = ray.GetPoint(rayDistance);
                //Debug.DrawLine(ray.origin,point,Color.red);
                _controller.LookAt(point);
            }

            //Weapon Input
            if (Input.GetMouseButton(0))
            {
                _gunController.Shoot();
            }
        }
    }
}
