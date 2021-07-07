using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sensibilidad : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;

    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("sensibilidaMouse", 0.5f);
        ControllCamera.mouseSensitivity = slider.value;
    }

    public void ChangeSlider(float valor)
    {
        sliderValue = valor;
        PlayerPrefs.SetFloat("sensibilidaMouse", sliderValue);
        ControllCamera.mouseSensitivity = slider.value;
    }
}
