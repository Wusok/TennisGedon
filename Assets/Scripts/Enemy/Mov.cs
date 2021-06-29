using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov : MonoBehaviour
{
    GameObject player;
    int life = 10;
    float damp = 3;
    Rigidbody rb;
    int speed = 10;
    float range = 3f;
    bool stay = false;
    bool jumping = false;
    int jumpForce = 30;
    int jumpSpeed = 5;
    bool isGround;
    float gravity = 0.5f;
    bool moveJump = false;
    Vector3 rotacion;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (stay == false)
        {
            if (Vector3.Distance(player.transform.position, transform.position) < 30)
            {
                //var rotate = transform.LookAt(player.transform.position - transform.position);
                //rotate = Quaternion.Euler(new Vector3(0, rotate.y, rotate.z));
                transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));

                //transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.y, transform.rotation.z));

                transform.position += transform.forward * speed * Time.deltaTime;
            }
        }

        RayCast();
        if (moveJump)
        {
            transform.position += transform.forward * jumpSpeed * Time.deltaTime;
            if (isGround)
            {
                moveJump = false;
            }
        }
        
        if (isGround == false)
        {
            rb.AddForce(transform.up * -1 * gravity, ForceMode.Acceleration);
        }

    }

    void RayCast()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward * range, new Color(1, 0, 0));
        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            Debug.Log(hit.collider.tag);
            if (hit.collider.tag == "Wall" && isGround == true)
            {
                stay = true;
                //jumping = true;
                rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
                StartCoroutine(WaitJump());
                
            }
            else if (hit.collider.tag != "Wall" && isGround == true)
            {
                stay = false;
            }
        }
    }


    IEnumerator WaitJump()
    {
        yield return new WaitForSeconds(0.1f);
        if(isGround == false)
        {
            moveJump = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            isGround = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isGround = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pelota")
        {
            if(other.GetComponent<BulletBeheivor>().WhatIsThisBall == 1)
            {

            }
            /*if(bB.WhatIsThisBullet == 1)
            {

            }*/
        }
    }
}
