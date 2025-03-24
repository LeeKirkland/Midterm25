using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TargetType      //makes drop down for different target types you can assigne to game objects with current script on it   
{
    Destroyable,
    Movable,
    DestroyableWithSound
}

public class Target : MonoBehaviour
{ 
    public AudioSource targetSound;     //references an audio clip in the content drawer that can be played
    public TargetType targetType;       //references the types of targets the game objects can be assigned as 
    private Vector3 startingPosition;QualityLevel   //references the position that the assigned objects will start at 
    public float maxMovingTargetRange = 3f;  

    void Start()
    {
        startingPosition = transform.position;

        if (targetType == TargetType.Destroyable)       //asks if the target is destroyable and states what happens if it is
        {
            this.GetComponent<MeshRenderer>().material.color = Color.magenta;       //changes the material of the target game object to magenta if it is destroyable 
        }
        else if (targetType == TargetType.Movable)      //asks if the target is moveable and explains what will happen if it is 
        {
            this.GetComponent<MeshRenderer>().material.color = Color.red;       //changes the material of the target game object to red if it is moveable
        }
        else if (targetType == TargetType.DestroyableWithSound)     //asks if the target is destroyable with sound and states what will happen if it is
        {
            this.GetComponent<MeshRenderer>().material.color = Color.yellow;        //changes the material of the target game object to yellow if it is destroyable with sound
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Bullet")       //asks if game object has bullet tag applied to it and states what to do if it does 
        {
            
            
            if(targetType == TargetType.Destroyable)        //asks if the target is destrotyable and says happens if it is
            {
                gameObject.SetActive(false);        //if the target is destroyable, this will make it disapear when collided with by setting its activity to false (turning it off)

            }
            else if(targetType == TargetType.Movable)
            {
                float randomY = Random.Range(-maxMovingTargetRange, maxMovingTargetRange);
                float randomZ = Random.Range(-maxMovingTargetRange, maxMovingTargetRange);

                transform.position = startingPosition + new Vector3(0f, randomY, randomZ);
            }
            else if (targetType == TargetType.DestroyableWithSound)
            {
                targetSound.Play();     //triggers the sound being referenced by the TargetSound to be played 
                gameObject.SetActive(false);        //makes the target disapear by setting it being active and visible to false (not active anymore)
            }
        }
    }
}