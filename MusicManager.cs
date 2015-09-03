using UnityEngine;
using System.Collections;

[RequireComponent(typeof (AudioSource))]
public class MusicManager : MonoBehaviour {


    static float musicVolume = 1f, sfxVolume = 1f;

    void Awake()
    {
        musicVolume = DataBase.GetFloat("MusicVolume");
        sfxVolume = DataBase.GetFloat("SFXVolume");
    }

    public static float SFXVolume
    {
        get { return MusicManager.sfxVolume; }
        set {
            MusicManager.sfxVolume = value; 
            DataBase.SetFloat("SFXVolume", value);
        }
    }

    public static float MusicVolume
    {
        get { return MusicManager.musicVolume; }
        set { 
            MusicManager.musicVolume = value;
            DataBase.SetFloat("MusicVolume", value);
        }
    }
}
