using System;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [Header("Teleport Settings")]
    public Transform teleportTarget;   
    public GameObject playerRig;

    [Header("Room Settings")]
    [Tooltip("Assign all objects from the room that should disappear after teleporting.")]
    public GameObject[] roomObjects;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            Debug.Log("teleport");
            playerRig.transform.position = teleportTarget.position;
            playerRig.transform.rotation = teleportTarget.rotation;

            DisableRoom();
        }
    }

    private void DisableRoom()
    {
        foreach (GameObject obj in roomObjects)
        {
            if ( obj != null)
                obj.SetActive(false);
        }
    }
}
