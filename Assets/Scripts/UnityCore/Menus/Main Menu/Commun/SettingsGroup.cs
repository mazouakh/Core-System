using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityCore.Audio;
using UnityEngine;
using AudioType = UnityCore.Audio.AudioType;

public class SettingsGroup : MonoBehaviour
{
    public Color textIdleColor;
    public Color textActiveColor;
    
    [SerializeField] private float tweenDuration = .5f;

    private AudioController _audioController;
    
    #region Unity Functions

    private void Start()
    {
        _audioController = AudioController.instance;
    }

    #endregion
    
    #region Public Functions

    public void OnElementEnter(SettingsElement element)
    {
        //Tweening & Audi
        //Tweening
        element.outlineImage.enabled = false;
        element.highlightImage.enabled = true;
        element.elementText.DOColor(textActiveColor, tweenDuration);
        //Play Hover Audio
        _audioController.PlayAudio(AudioType.SFX_ElementHover);
    }

    public void OnElementExit(SettingsElement element)
    {
        element.outlineImage.enabled = true;
        element.highlightImage.enabled = false;
        element.elementText.DOColor(textIdleColor, tweenDuration);
    }

    #endregion
}
