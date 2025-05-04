using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TargetType      //makes drop down for different target types you can assign to game objects with current script on it   
{
    Destroyable,
    Movable,
    DestroyableWithSound
}

public class Target : MonoBehaviour
{
    public AudioSource targetSound;     //references an audio clip in the content drawer that can be played
    public TargetType targetType;       //references the types of targets the game objects can be assigned as 
    private Vector3 startingPosition;   //references the position that the assigned objects will start at 
    public float maxMovingTargetRange = 3f; //maximum amount that target can move

    void Start()
    {
        startingPosition = transform.position;      //sets the starting position of the target to its current position at start

        if (targetType == TargetType.Destroyable)       //asks if the target is destroyable and states what happens if it is
        {
            this.GetComponent<MeshRenderer>().material.color = Color.cyan;       //changes the material of the target game object to cyan if it is destroyable 
        }
        else if (targetType == TargetType.Movable)      //asks if the target is moveable and explains what will happen if it is 
        {
            this.GetComponent<MeshRenderer>().material.color = new Color(1f, 0.5f, 0f);       //changes the material to orange-ish (not used by default colors)
        }
        else if (targetType == TargetType.DestroyableWithSound)     //asks if the target is destroyable with sound and states what will happen if it is
        {
            this.GetComponent<MeshRenderer>().material.color = Color.white;        //changes the material of the target game object to white if it is destroyable with sound
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Bullet")       //asks if game object has bullet tag applied to it and states what to do if it does 
        {
            Destroy(other.gameObject);      //destroys the bullet that hit this target

            if (targetType == TargetType.Destroyable)        //asks if the target is destroyable and says what happens if it is
            {
                gameObject.SetActive(false);        //if the target is destroyable, this will make it disappear by setting its activity to false (turning it off)
            }
            else if (targetType == TargetType.Movable)      //if target type is movable then move it randomly within the range
            {
                float randomY = Random.Range(-maxMovingTargetRange, maxMovingTargetRange);    //generates random y movement range
                float randomZ = Random.Range(-maxMovingTargetRange, maxMovingTargetRange);    //generates random z movement range

                transform.position = startingPosition + new Vector3(0f, randomY, randomZ);     //moves the target randomly around its original position
            }
            else if (targetType == TargetType.DestroyableWithSound)     //if it's a destroyable target with sound
            {
                StartCoroutine(PlaySoundAndDisable());    //play sound then disable after it ends
            }
        }
    }

    // Coroutine to wait for sound to finish before disabling
    IEnumerator PlaySoundAndDisable()
    {
        targetSound.Play();                                 // play the audio
        yield return new WaitForSeconds(targetSound.clip.length);   // wait for sound to finish
        gameObject.SetActive(false);                        // then disable the object
    }
}
