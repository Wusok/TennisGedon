using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlane : MonoBehaviour
{
    public GameObject respawnZero;
    public GameObject respawnOne;
    public GameObject respawnTwo;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (other.GetComponent<NewPJSMove>().numberRespawn == 0)
            {
                other.transform.position = respawnZero.transform.position;
            }
            else if (other.GetComponent<NewPJSMove>().numberRespawn == 1)
            {
                other.transform.position = respawnOne.transform.position;
            }
            else if (other.GetComponent<NewPJSMove>().numberRespawn == 2)
            {
                other.transform.position = respawnTwo.transform.position;
            }
        }
    }
}
