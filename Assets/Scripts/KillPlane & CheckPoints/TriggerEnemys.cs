using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnemys : MonoBehaviour
{
    public int amount = 6;
    public List<GameObject> flamitas;
    public int amountFlamitas;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (amount == 0)
        {
            for (int i = 0; i < amountFlamitas; i++)
            {
                Destroy(flamitas[i]);
            }
            Destroy(gameObject);
        }
    }
}
