using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    
    void Start()
    {
        Time.timeScale = 1;
    }

    public void OyunuBaslatBut()
    {
        SceneManager.LoadScene(1);
    }

    public void CikisBut()
    {
        Application.Quit();
    }
}
