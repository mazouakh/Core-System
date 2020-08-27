using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityCore.Audio;
using AudioType = UnityCore.Audio.AudioType;

namespace UnityCore
{
    namespace UI
    {
        public class SliderGroup : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
        {
            [SerializeField] private Color highlightColor;
            [SerializeField] private Color textDefaultColor;
            [SerializeField] private float tweenDuration;

            private AudioController _audioController;
            private Slider _slider;
            private Text _sliderText;
            private Image _fillImage;

            #region Unity Fucntions

            private void Start()
            {
                //Reference
                _audioController = AudioController.instance;
                _slider = GetComponent<Slider>();
                _sliderText = transform.Find("Text").GetComponent<Text>();
                _fillImage = transform.Find("Fill Area").Find("Fill").GetComponent<Image>();
                
                //Set slider value on start
                UpdateSliderText(false); //do not play value change audio on start
            }

            #endregion

            #region Public Functions

            public void UpdateSliderText(bool _canPlayAudio = true)
            {
                _sliderText.text = _slider.value + "%";
                //Tweening & Audio
                //Tweening text color
                _sliderText.DOColor(_slider.value <= 40 ? Color.white : textDefaultColor, tweenDuration);
                //Play Value Change Audio
                if (!_canPlayAudio) return;
                _audioController.PlayAudio(AudioType.SFX_MouseClick1);
            }

            public void OnPointerEnter(PointerEventData eventData)
            {
                HighlightSlider();
            }

            public void OnPointerExit(PointerEventData eventData)
            {
                ResetSliderColor();
            }

            public void HighlightSlider()
            {
                _fillImage.DOColor(highlightColor, tweenDuration);
            }

            public void ResetSliderColor()
            {
                _fillImage.DOColor(new Color(255, 255, 255, 255), tweenDuration);
            }

            #endregion
        }
    }
}