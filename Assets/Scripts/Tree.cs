using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public Transform ThisRotation;
    private bool IsFall;
    private bool Floor = false;
    private Vector3 Falling;
    private float timer = 0;
    private void Update()
    {
        if (IsFall == true)
        {
            ThisRotation.transform.Rotate(0, 0, 1);
            timer += 1 * Time.deltaTime;
        }

        /*if(ThisRotation.transform.localRotation.z >= 85)
        {
            IsFall = false;
        }*/

        if(timer >= 1.45)
        {
            Floor = true;
            IsFall = false;
        }
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ExplosiveBall" && Floor == false)
        {
            IsFall = true;
            Debug.Log("Trigeo");
        }
    }
}
