using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject Option;
    public GameObject Cross;
    public int ThisLVL;
    private bool esc = false;

    // Start is called before the first frame update
    private void Awake()
    {
        NewPJSMove.NextLVL = ThisLVL;
        MenuOff();
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if(esc == false)
            {
                Debug.Log("Apreto");
                Time.timeScale = 0;
                MenuOn();
                esc = true;
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
            }
            else if (esc == true)
            {
                Debug.Log("ApretoOff");
                Time.timeScale = 1;
                MenuOff();
                esc = false;
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
