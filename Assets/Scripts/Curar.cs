using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curar : MonoBehaviour
{
    private bool cure = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && cure == false)
        {
            cure = true;
            NewPJSMove.Life = 6;
        }
    }
}
