using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    /*
    
    ammo count
    bullet speed
    bullet prefab
    aim vector
    instantiate
    get key / button down

     
    */

    public GameObject bulletPrefab;
    public float bulletSpeed;
    public int bulletCount;
    public Vector3 bulletAim;

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            
        } 
    }

}
