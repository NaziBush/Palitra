using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager sound_manager;
    AudioSource source;
    [SerializeField]
    AudioClip main_menu;
    [SerializeField]
    AudioClip game;

    void Awake()
    {
        sound_manager = this;
        source = GetComponent<AudioSource>();
    }

    public void MainMenuTheme()
    {
        if (source.clip != main_menu)
        {
            source.clip = main_menu;
            source.Play();
        }
    }

    public void GameTheme()
    {
        if (source.clip!=game)
        {
            source.clip = game;
            source.Play();
        }
    }
}
