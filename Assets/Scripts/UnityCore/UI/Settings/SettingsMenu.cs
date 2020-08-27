using UnityEngine;
using UnityEngine.Audio;
using UnityCore.UI;

namespace UnityCore
{
    namespace Settings
    {
        public class SettingsMenu : MonoBehaviour
        {
            [Header("Graphics Settings")]
            [SerializeField] private ToggleGroup fullScreenToggle;
            [SerializeField] private HorizontalSelection resolutionHorSelection;
            [SerializeField] private HorizontalSelection textureQualityHorSelection;
            [SerializeField] private HorizontalSelection shadowQualityHorSelection;
            [SerializeField] private ToggleGroup vSyncToggle;
            private Resolution[] _resolutions;

            [Header("Audio Settings")]
            [SerializeField] private AudioMixer audioMixer;
            [SerializeField] private ToggleGroup musicToggle;
            [SerializeField] private ToggleGroup subtitleToggle;
            

            #region Unity Functions

            private void Start()
            {
                //Set default values
                SetFullscreen();
                SetVSync();
                InitializeAvailableResolutions();
                SetShadowQualitySelectionIndex();
                textureQualityHorSelection.selectionIndex = QualitySettings.GetQualityLevel();
                
            }

            #endregion
            
            #region Graphics Settings

            #region Public Functions

            public void SetBrightness(float value)
            {
                //TODO Set the brightness
            }

            public void SetFullscreen()
            {
                Screen.fullScreen = fullScreenToggle.toggleValue;
            }

            public void SetResolution()
            {
                Resolution _resolution = _resolutions[resolutionHorSelection.selectionIndex];
                Screen.SetResolution(_resolution.width, _resolution.height, Screen.fullScreen);
            }

            public void SetTextureQuality()
            {
                QualitySettings.SetQualityLevel(textureQualityHorSelection.selectionIndex);
            }

            public void SetVSync()
            {
                QualitySettings.vSyncCount = vSyncToggle.toggleValue ? 1 : 0;
            }

            public void SetShadowQuality()
            {
                switch (shadowQualityHorSelection.selectionIndex)
                {
                    case 0:
                        QualitySettings.shadowResolution = ShadowResolution.Low;
                        break;
                    case 1:
                        QualitySettings.shadowResolution = ShadowResolution.Medium;
                        break;
                    case 2:
                        QualitySettings.shadowResolution = ShadowResolution.High;
                        break;
                    case 3:
                        QualitySettings.shadowResolution = ShadowResolution.VeryHigh;
                        break;
                }
            }

            #endregion

            #region Private Functions

            private void InitializeAvailableResolutions()
            {
                //Grabbing available screen resolutions
                _resolutions = Screen.resolutions;
                resolutionHorSelection.ClearSelectionOptions();

                int currentResolutionIndex = 0;

                //adding the available resolutions to the horizontal selection list
                for (int i = 0; i < _resolutions.Length; i++)
                {
                    string option = _resolutions[i].width + " x " + _resolutions[i].height;
                    resolutionHorSelection.AddSelectionOption(option);

                    if (_resolutions[i].width == Screen.currentResolution.width &&
                        _resolutions[i].height == Screen.currentResolution.height)
                    {
                        currentResolutionIndex = i;
                    }
                }

                //Setting the default value
                resolutionHorSelection.selectionIndex = currentResolutionIndex;
                resolutionHorSelection.RefreshShownValue();
            }

            private void SetShadowQualitySelectionIndex()
            {
                switch (QualitySettings.shadowResolution)
                {
                    case ShadowResolution.Low :
                        shadowQualityHorSelection.selectionIndex = 0;
                        break;
                    case ShadowResolution.Medium:
                        shadowQualityHorSelection.selectionIndex = 1;
                        break;
                    case ShadowResolution.High:
                        shadowQualityHorSelection.selectionIndex = 2;
                        break;
                    case ShadowResolution.VeryHigh:
                        shadowQualityHorSelection.selectionIndex = 3;
                        break;
                }
            }
            
            #endregion

            #endregion

            #region Audio Settings

            public void UpdateMasterVolume(float value)
            {
                audioMixer.SetFloat("Master Volume", .8f * value - 80);
            }

            public void ToggleMusic()
            {
                
            }

            public void UpdateMusicVolume(float value)
            {
                
            }

            public void ToggleSubtitles()
            {
                
            }

            #endregion
            
        }
    }
}