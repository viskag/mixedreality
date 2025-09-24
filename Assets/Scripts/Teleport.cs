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

    [Header("Room Settings")]
    [Tooltip("Assign all objects from the scene that should appear after teleporting.")]
    public GameObject[] sceneObjects;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            Debug.Log("teleport");
            playerRig.transform.position = teleportTarget.position;
            playerRig.transform.rotation = teleportTarget.rotation;

            DisableRoom();
            EnableObjects();
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

    private void EnableObjects()
    {
        foreach (GameObject obj in sceneObjects)
        {
            if (obj != null)
                obj.SetActive(true);
        }
    }
}
