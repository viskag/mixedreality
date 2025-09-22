using System;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [Header("Teleport Settings")]
    public Transform teleportTarget;   
    public GameObject playerRig;      

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            Debug.Log("teleport");
            playerRig.transform.position = teleportTarget.position;
            playerRig.transform.rotation = teleportTarget.rotation;
        }
    }
}
