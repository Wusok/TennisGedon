using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBeheivor : MonoBehaviour
{
    //[SerializeField] public un private

    private float Velocity = 150f;
    public float FallVelocity = 0.01f;
    Rigidbody Rb;
    public float DownTime = 0;
    public GameObject Ice;
    public int WhatIsThisBall;
    public GameObject particulasNormalHit;
    public GameObject particulasIceHit;
    public GameObject particulasExplosiveHit;
    public GameObject explosion;

    public GameObject pointtoview;

    private bool mirando = false;
    void Start()
    {

        Rb = GetComponent<Rigidbody>();
        /*Sidex = NewPJSMove.x;

        if (Sidex > 0)
            Rb.AddForce(transform.right * (1) * AngularVelocity);
        else if (Sidex < 0)
            Rb.AddForce(transform.right * (-1) * AngularVelocity);*/

        WhatIsThisBall = Bullet.UsingBullet;
    }

    // Update is called once per frame
    void Update()
    {
        if (mirando == false)
        {
            transform.LookAt(pointtoview.transform);
            mirando = true;
        }
        if (DownTime >= 1f)
        {
            Rb.AddForce(-transform.up * FallVelocity * Time.deltaTime);
        }
        DownTime = DownTime + 1 * Time.deltaTime;
        transform.position += transform.forward * Time.deltaTime * Velocity;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.name);
        if (other.gameObject.tag != "Player" && other.gameObject.tag != "Trigger")
        {
            if(WhatIsThisBall == 0)
            {
                GameObject normal = Instantiate(particulasNormalHit, transform.position, transform.rotation);
                Destroy(normal, 1f);
            }
            else if(WhatIsThisBall == 1)
            {
                GameObject ice = Instantiate(particulasIceHit, transform.position, transform.rotation);
                Destroy(ice, 1f);
            }
            else if (WhatIsThisBall == 2)
            {
                GameObject explosive = Instantiate(particulasExplosiveHit, transform.position, transform.rotation);
                GameObject explosionWait = Instantiate(explosion, transform.position, transform.rotation);
                Destroy(explosive, 1f);
            }
            Destroy(gameObject, 0.5f);
        }
    }
}
