using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform BulletOut;
    public GameObject bulletPrefab;

    public int bulletValue = 10;
    public float bulletForce = 20f;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (bulletValue > 0)
            {
                Shoot();
                bulletValue--;
                Debug.Log(bulletValue);
            }
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, BulletOut.position, BulletOut.rotation);
        Rigidbody2D _rigidbody2D = bullet.GetComponent<Rigidbody2D>();
        _rigidbody2D.AddForce(BulletOut.right * bulletForce, ForceMode2D.Impulse);
    }
}
