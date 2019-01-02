using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{


    public TextMeshProUGUI scoreTxt;
    private SceneFader scenefade;

    public int scorePoint;
    public int levelReached;

    public LevelButtons[] levelbuttons;
    public Sound[] sounds;
    

    public AudioSource audioSource;
    public Slider volMusicSlider;
    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        
        scenefade = FindObjectOfType<SceneFader>();
        audioSource.volume = sounds[0].volume;

        volMusicSlider.value = audioSource.volume;

    }
    public void VolumeMusicSettings()
    {
        audioSource.volume = volMusicSlider.value;
        sounds[0].volume = audioSource.volume;
    }
    private PlayerData data;

    void Start()
    {

        data = SaveSystem.LoadPlayer();

        if (data == null)
        {
            levelReached = 1;
            scorePoint = 0;
        }
        else
        {
            levelReached = data.level;
            scorePoint = data.experience;
            scoreTxt.text = "Score " + scorePoint;
        }

        for (int i = 0; i < levelbuttons.Length; i++)
        {
            if (i + 1 > levelReached)
            {

                levelbuttons[i].levelButton.interactable = false;
            }
            else
            {

                levelbuttons[i].levelButton.interactable = true;
            }
        }

    }

    void Update()
    {
        scoreTxt.text = "Score " + scorePoint;
        for (int i = 0; i < levelbuttons.Length; i++)
        {
            if (i + 1 > levelReached)
            {
                levelbuttons[i].levelButton.interactable = false;

            }
            else
            {
                levelbuttons[i].levelButton.interactable = true;
            }

        }
    }

    public void SetPoint(int point)
    {
        scorePoint += point;
        SaveSystem.SavePlayerProgress(this);
    }

    public void SetLevel(int nextlevel)
    {

        //When player wants to player old levels buttons still showing the max level
        if (nextlevel > levelReached)
        {
            levelReached = nextlevel;
        }

        //Player achive a new level next button can be accesible for the level selection panel
        for (int i = 0; i < levelbuttons.Length; i++)
        {
            if (i + 1 > levelReached)
            {
                levelbuttons[i].levelButton.interactable = false;

            }
            else
            {
                levelbuttons[i].levelButton.interactable = true;
            }

        }

        string a = "Level" + nextlevel;

        scenefade.FadeTo(a);
        scenefade.FadeTo();


        SaveSystem.SavePlayerProgress(this);
    }
    public void LoadLevel(int k)
    {

        string b = "Level" + k;

        scenefade.FadeTo(b);

        scenefade.FadeTo();
    }


}




