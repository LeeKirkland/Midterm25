using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject bulletPrefab
    public float bulletForce
    public Transform bulletSpawnPosition;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPosition.position, bulletSpawnPosition.rotation);

            bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.up * bulletForce);

            Destroy(bullet, .25f);
        }
    }
}
