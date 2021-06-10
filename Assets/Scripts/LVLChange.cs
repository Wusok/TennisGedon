using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LVLChange : MonoBehaviour
{
    public int WhatLVL;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Colisione");
            if (WhatLVL == 1)
            {
                SceneManager.LoadScene("LVL1");
                Debug.Log("Intento cargar 1");
            }
            else if (WhatLVL == 2)
            {
                SceneManager.LoadScene("LVL2");
                Debug.Log("Intento cargar 2");
            }
            else if (WhatLVL == 3)
            {
                SceneManager.LoadScene("NewLVL");
                Debug.Log("Intento cargar 3");
            }
        }
    }
}
