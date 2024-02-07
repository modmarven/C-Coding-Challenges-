using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingManager : MonoBehaviour
{
    public GameObject bulletPref;
    public Transform bulletSpawn;

    void Start()
    {
        
    }

    
    void Update()
    {
        WeaponShoot();
    }

    private void WeaponShoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bulletPref, bulletSpawn.position, bulletSpawn.rotation);
        }
    }
}
