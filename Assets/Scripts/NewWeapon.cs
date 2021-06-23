using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewWeapon : MonoBehaviour
{
    public bool Mele = false;
    public bool Rapid = false;
    public bool Multi = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(Mele == true)
            {
                Bullet.MeleRacket = true;
                Destroy(gameObject);
            }
            if (Rapid == true)
            {
                Bullet.RapidRacket = true;
                Destroy(gameObject);
            }
            if (Multi == true)
            {
                Bullet.MultiRacket = true;
                Destroy(gameObject);
            }
        }
    }
}
