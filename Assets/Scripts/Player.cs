using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool hasGreenKey = false;        //asking if the player has the green key (and makes it so that when this bool is called it is set to false/no)
    public bool hasBlueKey = false;     //asking if the player has the blue key (and starting with it false)
    public bool hasRedKey = false;      //asking if the player has the red key (and sets its starting answer to know)

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))        //explains what will happen if the A key is pressed on the keyboard and asking if it is being pushed down
        {
            RaycastHit hit;     //this variable containes the data of what will be hit by the raycast

            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))        //saying what will happen if the cast of vision from the position of the camera (on the players pov) is on and hits (and asks if we are looking at it)
            {
                if (hit.collider.gameObject.tag == "Door")     //what will happen if the "players vision" (the raycasters line of vision) hits anything with the Door tag applied in the inspector and asks if the thing in front of the player is a locked door 
                {
                    LockedDoor door = hit.collider.GetComponent<LockedDoor>();
                    
                    if (door.isDoorLocked == true)      //states what will happen if the door that is hit is locked (set as locked)
                    {
                        //Open The Door
                    }
                    else 
                    {
                        if ((door.keyColorRequired == KeyColor.Green && hasGreenKey) ||     //asking and saying what will happen if the required color of key is green AND the player has it in their inventory
                            (door.keyColorRequired == KeyColor.Blue && hasBlueKey) ||
                            (door.keyColorRequired == KeyColor.Red && hasRedKey))
                        {
                            //Open The Door
                        }
                    }
                    
                }
            }
        }
    }
}
