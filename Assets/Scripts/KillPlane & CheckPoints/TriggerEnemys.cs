using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnemys : MonoBehaviour
{
    public GameObject barrier;
    private int amount = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(amount == 0)
        {
            Destroy(barrier.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("salio");
        if (other.gameObject.tag == "Enemey")
        {
            amount--;
        }
    }
}
