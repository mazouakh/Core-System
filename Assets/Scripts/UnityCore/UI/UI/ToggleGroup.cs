using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityCore.Audio;
using AudioType = UnityCore.Audio.AudioType;

namespace UnityCore
{
    namespace UI
    {
        public class ToggleGroup : MonoBehaviour
        {
            [SerializeField] private Sprite onSprite;
            [SerializeField] private Sprite offSprite;
            [SerializeField] private Color onTextColor;
            [SerializeField] private Color offTextColor;
            [SerializeField] private Color highlightColor;
            [SerializeField] private float tweenDuration = .5f;
            
            public bool toggleValue;

            private AudioController _audioController;
            
            private Button _onButton;
            private Button _offButton;
            private Image _onButtonImage;
            private Image _offButtonImage;
            private Text _onButtonText;
            private Text _offButtonText;
        
            #region Unity Functions
        
            private void Start()
            {
                //References
                _audioController = AudioController.instance;
                
                _onButton = transform.GetChild(0).Find("On Button").GetComponent<Button>();
                _offButton = transform.GetChild(0).Find("Off Button").GetComponent<Button>();
                _onButtonImage = _onButton.transform.GetChild(0).GetComponent<Image>();
                _onButtonText = _onButton.transform.GetChild(1).GetComponent<Text>();
                _offButtonImage = _offButton.transform.GetChild(0).GetComponent<Image>();
                _offButtonText = _offButton.transform.GetChild(1).GetComponent<Text>();
                
                //set default value
                RefreshToggleValue();
            }
        
            #endregion
        
            #region Public Functions
        
            public void SetToggleOn()
            {
                if (toggleValue) return;
                
                toggleValue = true;
                
                //Tweening & Audio
                _onButtonImage.sprite = onSprite;
                _onButtonText.color = onTextColor;
                _offButtonImage.sprite = offSprite;
                _offButtonText.color = offTextColor;
                
                //Play Toggle Audio
                _audioController.PlayAudio(AudioType.SFX_MouseClick1);
            }
            
            public void SetToggleOff()
            {
                if (!toggleValue) return;
                
                toggleValue = false;
                
                //Tweening & Audio
                _onButtonImage.sprite = offSprite;
                _onButtonText.color = offTextColor;
                _offButtonImage.sprite = onSprite;
                _offButtonText.color = onTextColor;
                
                //Play Toggle Audio
                _audioController.PlayAudio(AudioType.SFX_MouseClick1);
            }
        
            public void RefreshToggleValue()
            {
                if (toggleValue)
                    SetToggleOn();
                else
                    SetToggleOff();
            }

            public void HighlightToggle()
            {
                if (toggleValue)
                {
                    //
                    _onButtonImage.DOColor(highlightColor, tweenDuration);
                    _offButtonText.DOColor(highlightColor, tweenDuration);
                    //reset others
                    _offButtonImage.DOColor(Color.white, tweenDuration);
                    _onButtonText.DOColor(Color.white, tweenDuration);
                }
                else
                {
                    _offButtonImage.DOColor(highlightColor, tweenDuration);
                    _onButtonText.DOColor(highlightColor, tweenDuration);
                    //Reset others
                    _onButtonImage.DOColor(Color.white, tweenDuration);
                    _offButtonText.DOColor(Color.white, tweenDuration);
                }
            }
            
            public void ResetToggleColor()
            {
                if (toggleValue)
                {
                    _onButtonImage.DOColor(Color.white, tweenDuration);
                    _offButtonText.DOColor(offTextColor, tweenDuration);
                    //Reset others
                    _offButtonImage.DOColor(Color.white, tweenDuration);
                    _onButtonText.DOColor(onTextColor, tweenDuration);
                }
                else
                {
                    _offButtonImage.DOColor(Color.white, tweenDuration);
                    _onButtonText.DOColor(offTextColor, tweenDuration);
                    //Reset others
                    _onButtonImage.DOColor(Color.white, tweenDuration);
                    _offButtonText.DOColor(onTextColor, tweenDuration);
                }
            }
            
            
        
            #endregion
        }
    }
}