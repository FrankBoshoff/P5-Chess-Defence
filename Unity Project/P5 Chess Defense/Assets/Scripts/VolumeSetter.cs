using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSetter : MonoBehaviour {

    public Slider masterSlider;
    public Slider musicSlider;
    public Slider effectsSlider;
    public float masterVolume;
    public float musicVolume;
    public float effectsVolume;

    // Use this to set references
    private void Awake()
    {
        if (PlayerPrefs.HasKey("MasterVolume"))
        {
            masterVolume = PlayerPrefs.GetFloat("MasterVolume");
        }
        else
        {
            masterVolume = 0.5f;
            PlayerPrefs.SetFloat("MasterVolume", masterVolume);
        }
        masterSlider.value = masterVolume;

        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            musicVolume = PlayerPrefs.GetFloat("MusicVolume");
        }
        else
        {
            musicVolume = 0.5f;
            PlayerPrefs.SetFloat("MusicVolume", musicVolume);
        }
        musicSlider.value = musicVolume;

        if (PlayerPrefs.HasKey("EffectsVolume"))
        {
            effectsVolume = PlayerPrefs.GetFloat("EffectsVolume");
        }
        else
        {
            effectsVolume = 0.5f;
            PlayerPrefs.SetFloat("EffectsVolume", effectsVolume);
        }
        effectsSlider.value = effectsVolume;
    }

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
