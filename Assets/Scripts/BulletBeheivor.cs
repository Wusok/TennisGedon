﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBeheivor : MonoBehaviour
{
    //[SerializeField] public un private

    private float Velocity = 50f;
    public float FallVelocity = 0.01f;
    private float AngularVelocity = 2500;
    private float Sidex;
    Rigidbody Rb;
    public float DownTime = 0;
    public GameObject Ice;
    private int WhatIsThisBall;
    public GameObject particulasNormalHit;
    public GameObject particulasIceHit;
    public GameObject particulasExplosiveHit;
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
        Sidex = NewPJSMove.x;

        if (Sidex > 0)
            Rb.AddForce(transform.right * (1) * AngularVelocity);
        else if (Sidex < 0)
            Rb.AddForce(transform.right * (-1) * AngularVelocity);

        WhatIsThisBall = Bullet.UsingBullet;
    }

    // Update is called once per frame
    void Update()
    {
        if (DownTime >= 1f)
        {
            Rb.AddForce(-transform.up * FallVelocity* Time.deltaTime);
        }
        DownTime = DownTime + 1 * Time.deltaTime;
        transform.position += transform.forward * Time.deltaTime * Velocity;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player")
        {
            if(WhatIsThisBall == 0)
            {
                Instantiate(particulasNormalHit, transform.position, transform.rotation);
            }
            else if(WhatIsThisBall == 1)
            {
                Instantiate(particulasIceHit, transform.position, transform.rotation);
            }
            else if (WhatIsThisBall == 2)
            {
                Instantiate(particulasExplosiveHit, transform.position, transform.rotation);
            }
            //Destroy(gameObject);
        }
    }
}
