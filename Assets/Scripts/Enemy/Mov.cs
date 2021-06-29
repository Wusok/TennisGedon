using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov : MonoBehaviour
{
    GameObject player;
    int life = 10;
    void Start()
    {
        
    }

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Pelota")
        {
            //other.GetComponent<BulletBeheivor>(WhatIsThisBall);
        }
    }
}
