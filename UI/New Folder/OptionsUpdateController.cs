using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OptionsUpdateController : MonoBehaviour {

    public Slider musicSlider, SFXSlider;

    void Awake()
    {
        if (GameObject.Find("MusicManager") == null)
        {
            GameObject manager = new GameObject();
            manager.AddComponent<MusicManager>();
            manager.name = "MusicManager";
        }
    }

	void Start () {
        musicSlider.value = MusicManager.MusicVolume;
        SFXSlider.value = MusicManager.SFXVolume;
	}

    void Update()
    {
        MusicManager.MusicVolume = musicSlider.value;
        MusicManager.SFXVolume = SFXSlider.value;
    }
}
