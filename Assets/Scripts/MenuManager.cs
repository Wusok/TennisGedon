using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static bool CantMove = false;
    public GameObject Option;
    public GameObject Cross;
    public int ThisLVL;

    // Start is called before the first frame update
    private void Awake()
    {
        NewPJSMove.NextLVL = ThisLVL;
        MenuOff();
        CantMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if(CantMove == false)
            {
                Debug.Log("Apreto");
                MenuOn();
                CantMove = true;
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
            }
            else if (CantMove == true)
            {
                Debug.Log("ApretoOff");
                MenuOff();
                CantMove = false;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }

        }

    }

    void MenuOn()
    {
        Cross.SetActive(false);
        Option.SetActive(true);
    }

    void MenuOff()
    {
        Cross.SetActive(true);
        Option.SetActive(false);
    }

    public void SensibilidadInicial (float SensibilidadIni)
    {
        SensibilidadIni = LVLManager.Sensibilidad;
    }
}
