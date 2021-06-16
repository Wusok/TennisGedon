using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitThree : MonoBehaviour
{
    GameObject RotationPoint;
    bool Falling = false;

    private void Update()
    {
        if(Falling == true && RotationPoint.transform.rotation != Quaternion.Euler(0,0,-90))
        {
            RotationPoint.transform.Rotate(new Vector3(0, 0, -90) * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Mele")
        {
            Falling = true;
        }
    }
}
