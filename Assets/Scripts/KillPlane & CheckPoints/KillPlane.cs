using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlane : MonoBehaviour
{
    public GameObject respawnZero;
    public GameObject respawnOne;
    public GameObject respawnTwo;
    public GameObject respawnThree;
    public GameObject respawnFour;
    public GameObject respawnFive;
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
            else if (other.GetComponent<NewPJSMove>().numberRespawn == 3)
            {
                other.transform.position = respawnThree.transform.position;
            }
            else if (other.GetComponent<NewPJSMove>().numberRespawn == 4)
            {
                other.transform.position = respawnFour.transform.position;
            }
            else if (other.GetComponent<NewPJSMove>().numberRespawn == 5)
            {
                other.transform.position = respawnFive.transform.position;
            }
        }
    }
}
