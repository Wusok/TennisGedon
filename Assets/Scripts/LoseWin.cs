using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseWin : MonoBehaviour
{
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void LVL1()
    {
        SceneManager.LoadScene("LVL1");
    }
    public void LVL2()
    {
        SceneManager.LoadScene("LVL2");
    }
    public void LVL3()
    {
        SceneManager.LoadScene("LVL3");
    }
    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
