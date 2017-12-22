using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCar : MonoBehaviour {

    public string MoveForward;
    public string MoveBackward;
    public string TurnRight;
    public string TurnLeft;

    public float topSpeed = 100; // km per hour
    private float currentSpeed = 0;
    private float pitch = 0;


    public Transform[] Wheels;
    public float MotorPower;
    public float MaxTurn;

    private float InstantPower = 0.0f;
    private float Brake = 0.0f;
    private float WheelTurn = 0.0f;

    private Rigidbody CarRigidbody;
	

	// Use this for initialization
	void Start () {
        CarRigidbody = gameObject.GetComponent<Rigidbody>();
        CarRigidbody.centerOfMass = new Vector3(0, 0.0f, 0.0f);     //new Vector3(0, -0.5f, 0.3f);
    }
	
	// Update is called once per frame
	void Update () {
        //InstantPower = Input.GetAxis("Vertical") * MotorPower * Time.deltaTime;
        InstantPower = Input.GetKey(MoveForward) ? -1 * MotorPower * Time.deltaTime : Input.GetKey(MoveBackward) ? 1 * MotorPower * Time.deltaTime : 0.0f;
        //WheelTurn = Input.GetAxis("Horizontal") * MaxTurn;
        WheelTurn = Input.GetKey(TurnLeft) ? -1 * MaxTurn : Input.GetKey(TurnRight) ? 1 * MaxTurn : 0.0f;
        Brake = Input.GetKey("space") ? CarRigidbody.mass * 0.1f : 0.0f;

        GetCollider(0).steerAngle = WheelTurn;
        GetCollider(1).steerAngle = WheelTurn;

        Wheels[0].localEulerAngles = new Vector3(Wheels[0].localEulerAngles.x,
            GetCollider(0).steerAngle - Wheels[0].localEulerAngles.z, Wheels[1].localEulerAngles.z);
        Wheels[1].localEulerAngles = new Vector3(Wheels[1].localEulerAngles.x,
            GetCollider(1).steerAngle - Wheels[1].localEulerAngles.z, Wheels[1].localEulerAngles.z);

        Wheels[0].Rotate(GetCollider(0).rpm / 60 * 360 * Time.deltaTime, 0, 0);
        Wheels[1].Rotate(GetCollider(1).rpm / 60 * 360 * Time.deltaTime, 0, 0);
        Wheels[2].Rotate(GetCollider(2).rpm / 60 * 360 * Time.deltaTime, 0, 0);
        Wheels[3].Rotate(GetCollider(3).rpm / 60 * 360 * Time.deltaTime, 0 ,0);

		if (Brake > 0.0f) {
			GetCollider (0).brakeTorque = Brake;
			GetCollider (1).brakeTorque = Brake;
			GetCollider (2).brakeTorque = Brake;
			GetCollider (3).brakeTorque = Brake;

			GetCollider (2).motorTorque = 0.0f;
			GetCollider (3).motorTorque = 0.0f;
		} 
		else 
		{
			GetCollider(0).brakeTorque = 0.0f;
			GetCollider(1).brakeTorque = 0.0f;
			GetCollider(2).brakeTorque = 0.0f;
			GetCollider(3).brakeTorque = 0.0f;

            GetCollider(0).motorTorque = InstantPower;
            GetCollider(1).motorTorque = InstantPower;
            GetCollider(2).motorTorque = InstantPower;
            GetCollider(3).motorTorque = InstantPower;
        }

        currentSpeed = transform.GetComponent<Rigidbody>().velocity.magnitude * 3.6f;
        pitch = currentSpeed / topSpeed;
        GetComponent<AudioSource>().pitch = pitch;

    }

    private WheelCollider GetCollider(int n)
    {
        return Wheels[n].gameObject.GetComponent<WheelCollider>();
    }
}
