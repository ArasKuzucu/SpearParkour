using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    private SceneFader fade;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if (FindObjectsOfType(GetType()).Length > 3)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {

        fade = FindObjectOfType<SceneFader>();


    }

    public void StartGame()
    {
        fade.FadeTo("Level1");
        fade.FadeTo();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

}
