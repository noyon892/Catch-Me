using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class Player : MonoBehaviour {

    public float MoveSpeed = 5;
    private Camera _viewCamera;
    private PlayerController _controller;
    void Start()
    {
        _controller = GetComponent<PlayerController>();
        _viewCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 moveVelocity = moveInput.normalized * MoveSpeed;
        _controller.Move(moveVelocity);
        Ray ray = _viewCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayDistance;

        if (groundPlane.Raycast(ray, out rayDistance))
        {
            Vector3 point = ray.GetPoint(rayDistance);
            //Debug.DrawLine(ray.origin,point,Color.red);
            _controller.LookAt(point);
        }
    }
}
