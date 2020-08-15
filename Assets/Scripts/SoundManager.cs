using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
// Reference to Audio Source component
    private AudioSource mySoundEffectSource;
    private AudioSource myMusicSource;
    // Music volume variable that will be modified
    // by dragging slider knob
    private float musicVolume = 0f;
    private float soundEffectVolume=0f;

	// Use this for initialization
	void Start () {

        // Assign Audio Source component to control it
        mySoundEffectSource = GetComponent<AudioSource>();
        myMusicSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

        // Setting volume option of Audio Source to be equal to musicVolume
        mySoundEffectSource.volume = soundEffectVolume;
        myMusicSource.volume = musicVolume;
	}

    // Method that is called by slider game object
    // This method takes vol value passed by slider
    // and sets it as musicValue
    public void SetMusicVolume(float vol)
    {
        musicVolume = vol;
    }
    public void SetSoundEffectVolume(float vol)
    {
        soundEffectVolume = vol;
    }
}
