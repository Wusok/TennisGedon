using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov : MonoBehaviour
{
    GameObject player;
    float life = 10;
    Rigidbody rb;
    int speed = 10;
    float range = 3f;
    bool stay = false;
    bool jumping = false;
    int jumpForce = 20;
    int jumpSpeed = 2;
    bool isGround;
    float rangeDown = 2f;

    bool rayCast;

    public Material dmg;
    public Material normal;
    public Material freeze;

    Renderer rend;

    bool freezing;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
    }

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (freezing == false)
        {
            if (stay == false)
            {
                //Debug.Log("stay");
                if (Vector3.Distance(player.transform.position, transform.position) < 30 && jumping == false)
                {
                    //Debug.Log("piso");

                    //var rotate = transform.LookAt(player.transform.position - transform.position);
                    //rotate = Quaternion.Euler(new Vector3(0, rotate.y, rotate.z));
                    transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));

                    //transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.y, transform.rotation.z));

                    transform.position += transform.forward * speed * Time.deltaTime;
                }
            }

            RayCastFloor();
            RayCast();

            if(isGround && jumping == false && rayCast == false)
            {
                stay = false;
            }

            if (jumping == false)
                stay = false;

            if (jumping && isGround)
            {
                isGround = false;
            }

            if (jumping)
            {
                transform.position += transform.forward * jumpSpeed * Time.deltaTime;
            }

            if (isGround)
                jumping = false;
            else
                jumping = true;
        }
    }

    void RayCast()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward * range, new Color(1, 0, 0));
        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            rayCast = true;
            if (hit.collider.tag == null)
            {
                stay = false;
            }

            if (hit.collider.tag == "Wall" && isGround == true && jumping == false)
            {
                stay = true;
                //Debug.Log("se");
                jumping = true;
                rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            }
            else if (hit.collider.tag != "Wall" && isGround == true)
            {
                stay = false;
            }
        }
        else if(Physics.Raycast(transform.position, transform.forward, out hit, range) == false)
        {
            rayCast = false;
        }
    }

    void RayCastFloor()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.up * -1 * range, new Color(1, 0, 0));
        if (Physics.Raycast(transform.position, transform.up * -1, out hit, rangeDown))
        {
            if (hit.collider.tag == "Floor")
            {
                isGround = true;
            }
            else
            {
                isGround = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pelota")
        {
            if (other.GetComponent<BulletBeheivor>().WhatIsThisBall == 0)
            {
                Debug.Log("1");
                life -= 3;
                rend.material = dmg;
                StartCoroutine(ReturnMaterial());
            }
            else if (other.GetComponent<BulletBeheivor>().WhatIsThisBall == 1)
            {
                Debug.Log("2");
                life -= 1.5f;
                rend.material = freeze;
                StartCoroutine(ReturnMaterialAF());
            }
            else if (other.GetComponent<BulletBeheivor>().WhatIsThisBall == 2)
            {
                Debug.Log("3");
                life -= 2f;
                rend.material = dmg;
                StartCoroutine(ReturnMaterial());
            }
        }

        if (other.gameObject.tag == "Explosion")
        {
            life -= 1f;
        }

        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator ReturnMaterialAF()
    {
        freezing = true;
        yield return new WaitForSeconds(1f);
        freezing = false;
        rend.material = normal;
    }

    IEnumerator ReturnMaterial()
    {
        yield return new WaitForSeconds(0.3f);
        rend.material = normal;
    }
}
