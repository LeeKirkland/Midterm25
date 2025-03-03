using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    public KeyColor keyColorRequired;       //references the key color that is needed to open the door

    public Transform doorFinalPosition;     //references the position the door is at 

    public bool isDoorLocked = true;        //asks if the door has is locked and answers that it is (true)

    public bool hasBeenOpened = false;      //asks if the door has been opened and answers that it has not (false)


    private void Start()            //this makes it so that the doors only open with their specified color of keys. If the player has a red key, it will only open the red door, same with blue and green.
    {
        if (keyColorRequired == KeyColor.Green)        //saying what will happen if the key color requiered is set to green in inspector and asks if the required key is green
        {
            this.GetComponent<MeshRenderer>().material.color = Color.green;     //if the key color required is set to green, the color of the material on the key will change to green
        }
        else if (keyColorRequired == KeyColor.Blue)        //saying what will happen if the key color requiered is set to blue in inspector and asks if the requiered key is blue
        {
            this.GetComponent<MeshRenderer>().material.color = Color.blue; //if the key color required is set to blue, the color of the material on the key will change to blue
        }
        else if (keyColorRequired == KeyColor.Red)        //saying what will happen if the key color requiered is set to red in inspector and asks if the required key is red
        {
            this.GetComponent<MeshRenderer>().material.color = Color.red; //if the key color required is set to red, the color of the material on the key will change to red
        }
    }

    public void OpenDoor()          //this is the function that is called to open the door. It also states what position the door will be in if it has not been opened yet (hasBeenOpened == false).
    {
        if (hasBeenOpened == false)         //giving results for what will happen if the door being open is false (not being opened)
        {
            this.transform.position = doorFinalPosition.position;           //what sets the position of the door
        }
    }
}
