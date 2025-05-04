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
        if (Input.GetKeyDown(KeyCode.E))        //explains what will happen if the E key is pressed on the keyboard and asking if it is being pushed down
        {
            RaycastHit hit;     //this variable containes the data of what will be hit by the raycast

            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))        //saying what will happen if the cast of vision from the position of the camera (on the players pov) is on and hits (and asks if we are looking at it)
            {
                if (hit.collider.gameObject.tag == "Door")     //what will happen if the "players vision" (the raycasters line of vision) hits anything with the Door tag applied in the inspector and asks if the thing in front of the player is a locked door 
                {
                    LockedDoor door = hit.collider.GetComponent<LockedDoor>();     //get the reference to the LockedDoor script on the object the raycast hit

                    if (door != null)      //makes sure the object actually has a LockedDoor script attached
                    {
                        //check if the player has the correct key, and then try to open the door using that color
                        if (door.keyColorRequired == KeyColor.Green && hasGreenKey)         //if the key color required to open the door is set to green AND the player has the green key
                        {
                            door.TryToOpenDoor(KeyColor.Green);     //then the door will try to open with using the key that is green 
                        }
                        else if (door.keyColorRequired == KeyColor.Blue && hasBlueKey)       //if the key color required to open the door is set to blue AND the player has the blue key
                        {
                            door.TryToOpenDoor(KeyColor.Blue);          //then the door will try to open with using the key that is blue 
                        }
                        else if (door.keyColorRequired == KeyColor.Red && hasRedKey)         //if the key color required to open the door is set to red AND the player has the red key
                        {
                            door.TryToOpenDoor(KeyColor.Red);       //then the door will try to open with using the key that is green 
                        }
                        else
                        {
                            door.TryToOpenDoor(KeyColor.Red);       //tries to open the door ig the key used is red
                        }
                    }
                }
            }
        }
    }
}
