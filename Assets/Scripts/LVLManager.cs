using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LVLManager : MonoBehaviour
{
    public Slider slidersensibilidad;
    public static float Sensibilidad = 80f;

    private void Start()
    {
        slidersensibilidad.value = Sensibilidad;
    }
    private void Update()
    {
        Sensibilidad = slidersensibilidad.value;
    }
    public void CargarNivel(string NombreNivel)
    {
        SceneManager.LoadScene(NombreNivel);
    }

    public void Quit(string Salir)
    {
        Application.Quit();
    }

    public void SensibilidadMayor(float Sensibilidad2)
    {
        
        Sensibilidad = Sensibilidad2;
    }

   
}
