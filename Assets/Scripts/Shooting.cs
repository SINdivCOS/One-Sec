using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform BulletOut;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, BulletOut.position, BulletOut.rotation);
        Rigidbody2D _rigidbody2D = bullet.GetComponent<Rigidbody2D>();
        _rigidbody2D.AddForce(BulletOut.up * bulletForce, ForceMode2D.Impulse);
    }
}
