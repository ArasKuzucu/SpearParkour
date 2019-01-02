using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

[CreateAssetMenu(fileName = "New Sound", menuName = "Sound")]
[System.Serializable]
public class Sound : ScriptableObject
{
    public string name1;
    public AudioClip clip;
    [Range(0f,1f)]
    public float volume;
   

    [HideInInspector]
    public AudioSource source;
}
