using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private Vector3 _velocity;
    private Rigidbody _myRigidbody;

    void Start ()
	{
	    _myRigidbody = GetComponent<Rigidbody>();
	}

    public void Move(Vector3 _velocity)
    {
        this._velocity = _velocity;
    }

    public void LookAt(Vector3 lookPoint)
    {
        Vector3 heightCorrectedPoint = new Vector3(lookPoint.x,transform.position.y,lookPoint.z);
        transform.LookAt(heightCorrectedPoint);
    }

    public void FixedUpdate()
    {
        _myRigidbody.MovePosition(_myRigidbody.position + _velocity * Time.fixedDeltaTime);
    }
}
