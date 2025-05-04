using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    public KeyColor keyColorRequired;         // The key color required to unlock this door
    public Transform doorFinalPosition;       // Where the door moves when opened
    public bool isDoorLocked = true;
    public bool hasBeenOpened = false;

    private void Start()
    {
        MeshRenderer renderer = GetComponent<MeshRenderer>();

        if (renderer == null)
        {
            renderer = GetComponentInChildren<MeshRenderer>();
            Debug.Log($"[LockedDoor] MeshRenderer not on '{gameObject.name}', checking children.");
        }

        if (renderer != null)
        {
         
            Material matInstance = new Material(renderer.material);     //makes a new material to change so that others using it (keys) arent effected
            renderer.material = matInstance;

            Color newColor = Color.white;

            if (keyColorRequired == KeyColor.Green)
            {
                newColor = Color.green;
            }
            else if (keyColorRequired == KeyColor.Blue)
            {
                newColor = Color.blue;
            }
            else if (keyColorRequired == KeyColor.Red)
            {
                newColor = Color.red;
            }

            matInstance.color = newColor;
            Debug.Log($"[LockedDoor] Set '{gameObject.name}' color to {newColor} based on key {keyColorRequired}");
        }
        else
        {
            Debug.LogWarning($"[LockedDoor] No MeshRenderer found on '{gameObject.name}' or children.");
        }
    }

    public void OpenDoor()
    {
        if (!hasBeenOpened)
        {
            transform.position = doorFinalPosition.position;
            hasBeenOpened = true;
        }
        else
        {
            Debug.Log("[LockedDoor] Door already opened.");
        }
    }
}
