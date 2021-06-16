using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Rigidbody Rb;
    private float Velocity = 1500;
    void Start()
    {
        transform.Rotate(0, +1.5f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Rb = GetComponent<Rigidbody>();
        Rb.velocity = transform.forward * Velocity * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag != "Trigger" && other.gameObject.tag != "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
