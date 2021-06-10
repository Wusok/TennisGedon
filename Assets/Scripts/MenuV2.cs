using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuV2 : MonoBehaviour
{
    string ThisScene;
    void Start()
    {
        ThisScene = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LVLReset()
    {
        SceneManager.LoadScene(ThisScene);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
