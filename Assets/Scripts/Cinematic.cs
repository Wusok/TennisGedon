using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cinematic : MonoBehaviour
{
    public List <GameObject> cinematica;
    private float Timer;
    private int ThisImage = 0;

    void Update()
    {
        Timer += 1 * Time.deltaTime;
        Debug.Log(Timer);
        if (Timer > 1.5f && ThisImage != 17)
        {
            if(ThisImage != 0)
            {
                cinematica[ThisImage - 1].SetActive(false);
            }
            cinematica[ThisImage].SetActive(true);
            ThisImage++;
            Timer = 0;
        }
        if(Timer >= 1.5f && ThisImage == 17)
        {
            if (ThisImage == 17)
            {
                SceneManager.LoadScene("LVL1");
            }
        }
        

        if (Input.GetKeyDown("p"))
        {
            SceneManager.LoadScene("LVL1");
        }
    }
}
