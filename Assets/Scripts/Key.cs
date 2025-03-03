using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum KeyColor          //makes drop down for different colors you can assigne to game objects with current script on it   
{
    Green,
    Blue,
    Red
}

public class Key : MonoBehaviour
{
    public KeyColor keyColor;       

    public void Start()                //makes it so that when a specified color is selected in the inspector, the key prefab in game will change that color
    {
        if (keyColor == KeyColor.Green)     //if the key is not red or blue, saying what will happen if the key color is set to green in inspector
        {
            this.GetComponent<MeshRenderer>().material.color = Color.green;      //what changes the color of the material on the key that was selected to be green
        }
        else if (keyColor == KeyColor.Blue)     //if the key is not green or red, saying what will happen if the key color is set to blue in the inspector 
        {
            this.GetComponent<MeshRenderer>().material.color = Color.blue;      //what changes the color of the material on the key that was selected to be blue
        }
        else if (keyColor == KeyColor.Red)      //if the key is not blue or green, saying what will happen if the key colr is set to red in teh inspector
        {
            this.GetComponent<MeshRenderer>().material.color = Color.red;       //what changes the color of the material on the key that was selected to be red
        }
    }

    void OnTriggerEnter(Collider other)             //this makes it so that if the player (or anything tagged with player) picks up the specified colored key(triggers the trigger on the object), it will disapear and turn "has whatever color key" to true. More specifically it will 
                                                    //destroy the key and set "has whatever color key" to true.
    {
        if (other.tag == "Player")      //states what will happen to anything with the tag "player" applied to it in inspector
        {
            Player player = other.GetComponent<Player>();

            if (keyColor == KeyColor.Green)     //asking if the color of the key is green and not red or blue
            {
                if (player.hasGreenKey == false)        //saying what will happen if the player does NOT (false) have the green key when interacting with the green key
                {
                    player.hasGreenKey = true;      //this is making it so that the player now has the green key (having the key is true now)
                    Destroy(gameObject);     //this will make the green key disappear (detroys it)

                   // Debug.Log();
                }
            }
            else if (keyColor == KeyColor.Blue)     //saying what will happen if the key is blue not green or red and asks if it is blue 
            {
                if (player.hasBlueKey == false)     //what will happen if the player doesn't have the blue key while triggering the trigger on the blue key
                {
                    player.hasBlueKey = true;       //makes it so that the player now has the blue key 
                    Destroy(gameObject);        //this destroys the blue key 
                }
            }
            else if (keyColor == KeyColor.Red)      //if the key is red, not blue or green, what follows is what will happen
            {
                if (player.hasRedKey == false)      //states what will happen if the player does not have the red key at the time of stepping over the red key (triggering it)
                {
                    player.hasRedKey = true;        //makes it so that the player now has the red key 
                    Destroy(gameObject);        //this makes the red key disappear 
                }
            }

        }
    }
}
