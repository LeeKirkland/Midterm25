using System.Collections;
using System.Collections.Generic;
using Unity.Hierarchy;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    public KeyColor keyColorRequired;         //the key color required to unlock this door
    public Transform doorFinalPosition;       // there the door moves when opened
    public bool isDoorLocked = true;        //the door starts locked (when the game starts the lock is set to true)
    public bool hasBeenOpened = false;      // the door is not consisdered open when starting start

    public AudioClip wrongKeySound;           //sound to play if wrong key used
    private AudioSource audioSource;        // the audio source with the sound effect attatched to it 

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();      //accesses the audio source 

        if (keyColorRequired == KeyColor.Green)         //if the key reqired to open the door is green..
        {
            this.gameObject.GetComponent<MeshRenderer>().material.color = Color.green;      //then the color of the game object required to open the door is the one with the green material 
        }
        else if (keyColorRequired == KeyColor.Blue)     //if the key reqired to open the door is blue..
        {
            this.gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;   //then the color of the game object required to open the door is the one with the blue material 
        }
        else if (keyColorRequired == KeyColor.Red)      //if the key reqired to open the door is red..
        {
            this.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;    //then the color of the game object required to open the door is the one with the red material 
        }
    }

    public void TryToOpenDoor(KeyColor playerKeyColor)          // calls this method when player interacts with the door
    {
        if (isDoorLocked)       //if the door is locked whrn player tired to interact with it then starts this function 
        {
            if (playerKeyColor == keyColorRequired)     //if the player has the correct color key...
            {
                OpenDoor();     //then it calls the open door function 
                isDoorLocked = false;       //and makes it so that the door is no longer locked (false when it was previously true)
            }
            else
            {
                if (audioSource != null && wrongKeySound != null)       //if the player uses the wrong key..
                {
                    audioSource.PlayOneShot(wrongKeySound);         //references the audio source and plays the wrong sound effect
                }
            }
        }
        else        //but if not..
        {
            OpenDoor();     //it opens the door 
        }
    }

    public void OpenDoor()      //when the open door funciton is called, this will trigger
    {
        if (!hasBeenOpened)     //if it has been opened (has been opened is true)
        {
            transform.position = doorFinalPosition.position;        //the door will move to the set open door position 
            hasBeenOpened = true;       //sets open door to ture (the door has been opened)
        }
        else    //if it has already been set to true and the fucntion is called.. 
        {
            Debug.Log("[LockedDoor] Door already opened.");     //this message will appear in console to tell the player that the door has already been opened
        }
    }
}
