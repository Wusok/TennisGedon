using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    float speed = 40;
    GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        transform.LookAt(player.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag != "Enemy" && other.gameObject.tag != "Trigger" && other.gameObject.tag != "JumpBoost" +
            "")
        {
            Destroy(gameObject);
        }
    }
}
