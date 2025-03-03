using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TargetType
{
    Destroyable,
    Movable,
    DestroyableWithSound
}

public class Target : MonoBehaviour
{ 
    public AudioSource targetSound;
    public TargetType targetType;
    private Vector3 startingPosition;
    public float maxMovingTargetRange = 3f;

    void Start()
    {
        startingPosition = transform.position;

        if (targetType == TargetType.Destroyable)
        {
            this.GetComponent<MeshRenderer>().material.color = Color.magenta;
        }
        else if (targetType == TargetType.Movable)
        {
            this.GetComponent<MeshRenderer>().material.color = Color.red;
        }
        else if (targetType == TargetType.DestroyableWithSound)
        {
            this.GetComponent<MeshRenderer>().material.color = Color.yellow;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ballet")
        {
            
            
            if(targetType == TargetType.Destroyable)
            {
                gameObject.SetActive(false);

            }
            else if(targetType == TargetType.Movable)
            {
                float randomY = Random.Range(-maxMovingTargetRange, maxMovingTargetRange);
                float randomZ = Random.Range(-maxMovingTargetRange, maxMovingTargetRange);

                transform.position = startingPosition + new Vector3(0f, randomY, randomZ);
            }
            else if (targetType == TargetType.DestroyableWithSound)
            {
                targetSound.Play();
                gameObject.SetActive(false);
            }
        }
    }
}