using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour
{
    public int WhatIsThisCheck;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            NewPJSMove.LastCheckpoint = WhatIsThisCheck;
            NewPJSMove.EnableCheckPoints = true;
        }
    }
}
