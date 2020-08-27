using System;
using System.Collections;
using System.Collections.Generic;
using UnityCore.Audio;
using UnityEngine;
using UnityEngine.SceneManagement;
using AudioType = UnityCore.Audio.AudioType;

public class AudioManager : MonoBehaviour
{
    private AudioController _audioController;
    
    void Start()
    {
        _audioController = AudioController.instance;
        if (SceneManager.GetActiveScene().name == "Main Menu" && _audioController.tracks[0].source.clip == null)
        {
            _audioController.PlayAudio(AudioType.ST_MainMenu, true, 2f);
        }
    }

    #region Public Functions

    public void PlayMouseClickAudio()
    {
        _audioController.PlayAudio(AudioType.SFX_MouseClick1);
    }

    #endregion
}
