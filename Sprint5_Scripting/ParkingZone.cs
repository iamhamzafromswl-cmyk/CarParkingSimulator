using UnityEngine;
using System.Collections;

public class ParkingZone : MonoBehaviour
{
    [Header("Validation Rules")]
    public float requiredParkTime = 3.0f;
    private float validationTimer = 0f;
    private bool structureContained = false;
    private VehicleController activeVehicle;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBoundBox")) // Assuming the vehicle has a child collider with this tag
        {
            structureContained = true;
            activeVehicle = other.GetComponentInParent<VehicleController>();
            if (activeVehicle != null)
            {
                StartCoroutine(EvaluateParkingState());
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PlayerBoundBox"))
        {
            structureContained = false;
            validationTimer = 0f;
            StopAllCoroutines(); // Stop the parking evaluation if vehicle leaves
            activeVehicle = null;
        }
    }

    IEnumerator EvaluateParkingState()
    {
        while (structureContained && activeVehicle != null)
        {
            // Check if the vehicle is in Park gear
            if (activeVehicle.GetCurrentGear() == VehicleController.ShiftGear.Park)
            {
                validationTimer += Time.deltaTime;
                if (validationTimer >= requiredParkTime)
                {
                    Debug.Log("Parking Validated!");
                    // Trigger success event, reward player, etc.
                    // For now, we'll just stop the coroutine after success
                    yield break; 
                }
            }
            else
            {
                // Reset timer if vehicle is not in Park gear
                validationTimer = 0f;
            }
            yield return null;
        }
    }
}
