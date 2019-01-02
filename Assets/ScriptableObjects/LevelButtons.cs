using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "NewLevelButton", menuName = "LevelButton")]
[System.Serializable]
public class LevelButtons : ScriptableObject
{
    public Button levelButton;
    public string levelName;

	
}
