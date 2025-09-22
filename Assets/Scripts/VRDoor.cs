using UnityEngine;

public class VRDoor : MonoBehaviour
{
    [Header("References")]
    public Transform handle;       // The handle object
    public Transform door;         // The door object (pivoted at hinges)

    [Header("Settings")]
    public float handleDownAngle = 25f; // angle required to unlock
    public float doorOpenAngle = 90f;    // how far door swings open
    public float openSpeed = 2f;

    private bool isUnlocked = false;
    private bool isOpen = false;
    private Quaternion doorClosedRot;

    void Start()
    {
        doorClosedRot = door.localRotation;
    }

    void Update()
    {
        // Open door if unlocked and not already opening
        if (isUnlocked && !isOpen)
        {
            Quaternion targetRot = Quaternion.Euler(0, doorOpenAngle, 0);
            door.localRotation = Quaternion.Slerp(door.localRotation, targetRot, Time.deltaTime * openSpeed);

            if (Quaternion.Angle(door.localRotation, targetRot) < 1f)
            {
                isOpen = true;
                Debug.Log("Door Opened!");
            }
        }
    }
    public void OpenDoor()
    {
        isUnlocked = true;
    }
}
