using UnityEngine;
using System.Collections;

public class VehicleController : MonoBehaviour
{
    [Header("Transmission State")]
    public enum ShiftGear { Park, Reverse, Neutral, Drive }
    public ShiftGear currentGear = ShiftGear.Drive;

    private float throttleInput;
    private float steeringInput;
    private float brakeInput;

    [Header("Wheel Colliders")]
    public WheelCollider[] driveWheels;
    public WheelCollider[] steeringWheels;

    [Header("Motor Performance")]
    public float motorTorque = 4500f; // Adjusted from proposal's 1600f for better simulation
    public float brakeTorque = 4500f; // Adjusted from proposal's 32f for better simulation
    public float maxSteerAngle = 32f;

    [Header("Physics Mass Hub")]
    private Rigidbody rb;
    public Transform centerOfMass;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (centerOfMass != null) rb.centerOfMass = centerOfMass.localPosition;
    }

    void Update()
    {
        // Input handling
        throttleInput = Input.GetAxis("Vertical");
        steeringInput = Input.GetAxis("Horizontal");
        brakeInput = Input.GetKey(KeyCode.Space) ? 1f : 0f;

        // Gear shifting
        if (Input.GetKeyDown(KeyCode.E)) currentGear = ShiftGear.Drive;
        if (Input.GetKeyDown(KeyCode.Q)) currentGear = ShiftGear.Reverse;
        if (Input.GetKeyDown(KeyCode.P)) currentGear = ShiftGear.Park;
    }

    void FixedUpdate()
    {
        ApplySteering();
        ApplyPropulsion();
    }

    private void ApplyPropulsion()
    {
        float calculatedTorque = 0f;

        if (currentGear == ShiftGear.Drive && throttleInput > 0)
        {
            calculatedTorque = throttleInput * motorTorque;
        }
        else if (currentGear == ShiftGear.Reverse && throttleInput < 0)
        {
            calculatedTorque = Mathf.Abs(throttleInput) * motorTorque;
        }

        foreach (var wheel in driveWheels)
        {
            wheel.motorTorque = calculatedTorque;
            wheel.brakeTorque = brakeInput * brakeTorque;

            // Electronic parking brake enforcement
            if (currentGear == ShiftGear.Park)
            {
                wheel.brakeTorque = brakeTorque; // Apply full brake torque when in Park
            }
        }
    }

    private void ApplySteering()
    {
        float targetAngle = steeringInput * maxSteerAngle;
        foreach (var wheel in steeringWheels)
        {
            wheel.steerAngle = targetAngle;
        }
    }

    // Public method to get current gear for other scripts (e.g., ParkingZone)
    public ShiftGear GetCurrentGear()
    {
        return currentGear;
    }
}
