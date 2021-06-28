using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHability : MonoBehaviour
{
    public bool Rapid;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (Rapid)
            {
                UIManager.HaveRapid = true;
                Destroy(gameObject);
            }
            else
            {
                UIManager.HaveMulti = true;
                Destroy(gameObject);
            }
        }
    }
}
