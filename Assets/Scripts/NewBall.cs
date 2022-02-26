using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBall : MonoBehaviour
{
    public bool Ice;
    public bool Explosive;
    public bool Big;
    // probando
    public bool Fire;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Ice == true)
            {
                Bullet.HaveIceBullet = true;
            }
            if (Explosive == true)
            {
                Bullet.HaveExplosiveBullet = true;
            }
            if (Big == true)
            {
                Bullet.HaveBigBullet = true;
            }
            if (Fire == true)
            {
                Bullet.HaveFireBullet = true;
            }

            Destroy(gameObject);
        }
    }
}
