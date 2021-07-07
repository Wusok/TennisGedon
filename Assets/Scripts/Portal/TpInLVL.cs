using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpInLVL : MonoBehaviour
{
    public GameObject otherPortal;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger");
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("triggerplayer");
            other.transform.position = otherPortal.transform.position;
        }
    }
}
