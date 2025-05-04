using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    public KeyColor keyColorRequired;         // The key color required to unlock this door
    public Transform doorFinalPosition;       // Where the door moves when opened
    public bool isDoorLocked = true;
    public bool hasBeenOpened = false;

    private void Start()
    {
        if (keyColorRequired == KeyColor.Green)
        {
            this.gameObject.GetComponent<MeshRenderer>().material.color = Color.green; 
        }
        else if (keyColorRequired == KeyColor.Blue)
                {
            this.gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
        }
        else if (keyColorRequired == KeyColor.Red)
        {
            this.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
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
