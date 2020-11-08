using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using System.Threading;
using UnityEngine;

public class Car : MonoBehaviour
{
    public Transform centerOfMass;

    public WheelCollider wheelColliderLeftFront;
    public WheelCollider wheelColliderRightFront;
    public WheelCollider wheelColliderLeftBack;
    public WheelCollider wheelColliderRightBack;

    public Transform wheelLeftFront;
    public Transform wheelRightFront;
    public Transform wheelLeftBack;
    public Transform wheelRightBack;

    public float motorTorque = 1500f;
    public float maxSteer = 20f;
    private Rigidbody _rigidbody;
    private Vector3 startPos;
    private Quaternion startRot;

    

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.centerOfMass = centerOfMass.localPosition;
        startPos = _rigidbody.position;
        startRot = _rigidbody.rotation;
    }

    
    void FixedUpdate()
    {
        wheelColliderLeftBack.motorTorque = Input.GetAxis("Vertical") * motorTorque;
        wheelColliderRightBack.motorTorque = Input.GetAxis("Vertical") * motorTorque;
        wheelColliderLeftFront.steerAngle = Input.GetAxis("Horizontal") * maxSteer;
        wheelColliderRightFront.steerAngle = Input.GetAxis("Horizontal") * maxSteer;
    }

    void Update()
    {
        var pos = Vector3.zero;
        var rot = Quaternion.identity;

     
        
        bool restart = Input.GetKey(KeyCode.R); //restart
        if (restart)
        {
            _rigidbody.position = startPos;
            _rigidbody.rotation = startRot;
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;
        }

        

        wheelColliderLeftFront.GetWorldPose(out pos, out rot);
        wheelLeftFront.position = pos;
        wheelLeftFront.rotation = rot;

        wheelColliderRightFront.GetWorldPose(out pos, out rot);
        wheelRightFront.position = pos;
        wheelRightFront.rotation = rot * Quaternion.Euler(0,180,0);

        wheelColliderLeftBack.GetWorldPose(out pos, out rot);
        wheelLeftBack.position = pos;
        wheelLeftBack.rotation = rot;

        wheelColliderRightBack.GetWorldPose(out pos, out rot);
        wheelRightBack.position = pos;
        wheelRightBack.rotation = rot * Quaternion.Euler(0, 180, 0);
    }

    
}
