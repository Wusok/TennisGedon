using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager2 : MonoBehaviour
{
    string ThisScene;
    void Start()
    {
        ThisScene = SceneManager.GetActiveScene().name;
    }

    public void MenuScene(string Menu)
    {
        MenuManager.CantMove = false;
        SceneManager.LoadScene(Menu);
    }

    public void RestartScene()
    {
        MenuManager.CantMove = false;
        SceneManager.LoadScene(ThisScene);
    }
}
