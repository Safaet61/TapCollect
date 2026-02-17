using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] private AudioSource bgSource;
    [SerializeField] private AudioSource sfxSource;

    [Header("Audio Clips")]
    [SerializeField] private AudioClip bgSound;
    [SerializeField] private AudioClip clickSound;
    [SerializeField] private AudioClip explosionSound;
    [SerializeField] private bool isMusicOn;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(gameObject);
    }
    private void Start()
    {
        isMusicOn = PlayerPrefs.GetInt("Music", 1) == 1;
        if (isMusicOn)
        {
            PlayBGMusic();
        }
        else
            bgSource.Stop();
    }
    public void ToggleMusic()
    {

        isMusicOn = !isMusicOn;

        if (isMusicOn)
        {
            PlayBGMusic();
            PlayerPrefs.SetInt("Music", 1);
        }
        else
        {
            bgSource.Stop();
            PlayerPrefs.SetInt("Music", 0);
        }
    }
    public void PlayBGMusic()
    {
        bgSource.clip = bgSound;
        bgSource.Play();
    }
    public void PlayButtonClick()
    {
        sfxSource.PlayOneShot(clickSound);
    }
    public void PlayExplosionSound()
    {
        sfxSource.PlayOneShot(explosionSound);
    }
   

}
