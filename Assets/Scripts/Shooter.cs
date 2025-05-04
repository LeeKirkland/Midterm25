using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject bulletPrefab;     //references the variable for the prefab 
    public float bulletForce;       //to set the force of the bullet and be able to change it in the inspector
    public Transform bulletSpawnPosition;       //references the position that the bullets will spawn at

    void Update()
    {
        if (Input.GetMouseButtonDown(0))        //states what will happen when the mouse button is clicked down and asks if it is being clicked
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPosition.position, bulletSpawnPosition.rotation);      //this spawns the perfab of the bullet and sets the roation and position of the bullet spawner (which is slightly in front of the player)

            Rigidbody rb = bullet.GetComponent<Rigidbody>();     //gets the rigidbody component from the spawned bullet

            rb.AddForce(bullet.transform.forward * bulletForce, ForceMode.Impulse);      //adds force to the bullet in a forward direction

            Destroy(bullet, 3f);        //destroys the bullet after 3 seconds
        }
    }
}
