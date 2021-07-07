using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosWin : MonoBehaviour
{
    public GameObject portal;
    public static bool isDead = false;

    void Update()
    {
        if(isDead == true)
        {
            portal.gameObject.SetActive(true);
        }
    }
}
