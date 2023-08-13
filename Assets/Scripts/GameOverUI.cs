using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        Dusman.OnPlayerDeath -= ActivateGameObject;
    }

    public void AnaMenuyeDon()
    {
        SceneManager.LoadScene(0);
    }

    private void ActivateGameObject()
    {
        this.gameObject.SetActive(true);
    }
}
