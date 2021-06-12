using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBeheivor : MonoBehaviour
{
    public float Velocity = 1500f;
    public float FallVelocity = 0.01f;
    private float AngularVelocity = 10f;
    private float Sidex;
    private float Sidez;
    Rigidbody Rb;
    public float DownTime = 0;
    public GameObject Ice;
    private int WhatIsThisBall;
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
        Rb.velocity = transform.forward * Velocity * Time.deltaTime;
        Sidex = NewPJSMove.x;
        Sidez = NewPJSMove.z;
        /*if (Side == 1)
        {
            Debug.Log("Lado1");
            Rb.AddForce(transform.right * AngularVelocity);
        }
        else if (Side == -1)
        {
            Debug.Log("Lado2");
            Rb.AddForce(-transform.right * AngularVelocity);
        }*/
        Rb.AddForce(-transform.right * Sidex * AngularVelocity);
        Rb.AddForce(transform.forward * Sidez * AngularVelocity);
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
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "Player")
        {
            if (other.gameObject.tag != "IW")
            {
                Destroy(gameObject);
            } 
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }

        if(other.gameObject.tag == "Water" && WhatIsThisBall == 1)
        {
            GameObject ThisIce = Instantiate(Ice, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
        }

        if (other.gameObject.tag == "SpecialWall" && WhatIsThisBall == 2)
        {
            Destroy(other.gameObject);
        }
    }
}
