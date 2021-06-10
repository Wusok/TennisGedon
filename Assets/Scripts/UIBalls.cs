using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;
using UnityEngine.UI;

public class UIBalls : MonoBehaviour
{
    public Color gris;
    public Color normal;
    private Image image;
    public bool esnormal = true;
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if(esnormal == true)
        {
            image.color += normal;
        }
        else
        {
            image.color += gris;
        }*/
    }
}
