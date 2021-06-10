using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    
    public Animator Anima;
    private bool Shotting;
    private float CDR;
    private float ANimationTime;

    void Start()
    {
        Anima = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MenuManager.CantMove == false)
        {
            if (Input.GetButtonDown("Fire1") && CDR >= 0.5)
            {
                Shotting = true;
                Anima.SetBool("Shotting", Shotting);
                CDR = 0;
                ANimationTime = 0;
            }
        }
        CDR += 1 * Time.deltaTime;
        if(ANimationTime >= 0.5)
        {
            Shotting = false;
            Anima.SetBool("Shotting", Shotting);
        }
        ANimationTime += 1 * Time.deltaTime;
    }
}
