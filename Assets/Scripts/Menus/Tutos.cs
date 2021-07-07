using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutos : MonoBehaviour
{
    public GameObject tutos;
    public GameObject pag1;
    public GameObject pag2;
    public GameObject main;

    public void Pagina1()
    {
        main.gameObject.SetActive(false);
        tutos.gameObject.SetActive(true);
        pag1.gameObject.SetActive(true);
        pag2.gameObject.SetActive(false);
    }

    public void Pagina2()
    {
        main.gameObject.SetActive(false);
        tutos.gameObject.SetActive(true);
        pag1.gameObject.SetActive(false);
        pag2.gameObject.SetActive(true);
    }

    public void Back()
    {
        main.gameObject.SetActive(true);
        tutos.gameObject.SetActive(false);
        pag1.gameObject.SetActive(true);
        pag2.gameObject.SetActive(false);
    }
}
