using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [Header("----------- Audio Source -----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("----------- Audio Source -----------")]
    public AudioClip[] deathSoundArray;
    public AudioClip[] deathSquishSoundArray;
    public AudioClip backGroundMusic;

    private void Start(){
        musicSource.clip = backGroundMusic;
        musicSource.Play();
    }
    public void SoundsOnDeath(){
        AudioClip deathSound = deathSoundArray[Random.Range(0, deathSoundArray.Length)];
        SFXSource.PlayOneShot(deathSound);
    }
    public void SquishySoundsOnDeath(){
        AudioClip deathSquishSound = deathSquishSoundArray[Random.Range(0, deathSquishSoundArray.Length)];
        SFXSource.PlayOneShot(deathSquishSound);
    }
}
