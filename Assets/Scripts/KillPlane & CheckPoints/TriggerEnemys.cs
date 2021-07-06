using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnemys : MonoBehaviour
{
    public int amount = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(amount == 0)
        {
            Destroy(gameObject);
        }
    }
}
