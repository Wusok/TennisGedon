using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class ScreenOptions : MonoBehaviour
{
    //Cntrl + K + D Ordenar Codigo
    
    public Toggle toggle;

    public TMP_Dropdown resolucionesDropDown;
    Resolution[] resoluciones;
    void Start()
    {
        if (Screen.fullScreen)
            toggle.isOn = true;
        else
            toggle.isOn = false;

        RevisarResolucion();
    }


    public void PantallaCompleta(bool pantallaCompleta)
    {
        Screen.fullScreen = pantallaCompleta;
    }

    public void RevisarResolucion()
    {
        resoluciones = Screen.resolutions;
        resolucionesDropDown.ClearOptions();
        List<string> options = new List<string>();
        int actualresolution = 0;

        for (int i = 0; i < resoluciones.Length; i++)
        {
            string option = resoluciones[i].width + " x " + resoluciones[i].height;
            options.Add(option);

            if (Screen.fullScreen && resoluciones[i].width == Screen.currentResolution.width && resoluciones[i].height == Screen.currentResolution.height)
                actualresolution = i;
        }
        resolucionesDropDown.AddOptions(options);
        resolucionesDropDown.value = actualresolution;
        resolucionesDropDown.RefreshShownValue();
    }

    public void ChangeResolution(int indiceResolution)
    {
        Resolution resolucion = resoluciones[indiceResolution];
        Screen.SetResolution(resolucion.width, resolucion.height, Screen.fullScreen);
    }
}
