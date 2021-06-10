using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public Transform ThisRotation;
    private bool IsFall;
    private Vector3 Falling;
    private void Update()
    {
        
        if (IsFall == true)
        {
            
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "ExplosiveB")
        {
            IsFall = true;
        }
    }
}
