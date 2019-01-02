using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public  int level;
    public  int experience;

    public PlayerData(GameManager playerprogress)
    {
        experience = playerprogress.scorePoint;
        level = playerprogress.levelReached;


    }
	
}
