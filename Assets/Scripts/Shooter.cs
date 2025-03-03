using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject bulletPrefab;     //creates a variable for the prefab of the bullet 
    public float bulletForce;       
    public Transform bulletSpawnPosition;       //references the position that the bullets will spawn at

    void Update()
    {
        if (Input.GetMouseButtonDown(0))        //states what will happen when the mouse button is clicked down and asks if it is being clicked
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPosition.position, bulletSpawnPosition.rotation);      //this spawns the perfab of the bullet being called through the gmae object. 

            bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.up * bulletForce);

            Destroy(bullet, 3f);
        }
    }
}
