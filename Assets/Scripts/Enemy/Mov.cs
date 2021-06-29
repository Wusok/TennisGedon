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
        if (Vector3.Distance(player.transform.position, transform.position) < 30)
        {
            var rotate = Quaternion.LookRotation(player.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp((transform.rotation), rotate, damp * Time.deltaTime);

            transform.position += transform.forward * speed * Time.deltaTime;
        }

        RayCast();
    
    }

    void RayCast()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward * range, new Color(1, 0, 0));
        if(Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            Debug.Log(hit.collider.tag);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pelota")
        {
            other.GetComponent<BulletBeheivor>();
        }
    }
}
