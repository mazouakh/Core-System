using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityCore.Audio;
using AudioType = UnityCore.Audio.AudioType;

namespace UnityCore
{
    namespace Menu
    {
        //IMPORTANT : the On & Off button needs to call HighlightToggle OnCLick to update toggle color once the value has changed
        
        public class HorizontalSelection : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
        {
            public List<string> selectionOptions;
            [HideInInspector] public int selectionIndex;

            [SerializeField] private Color defaultColor;
            [SerializeField] private Color highlightColor;
            [SerializeField] private float tweenDuration;

            private AudioController _audioController;
            private Text _selectionText;

            #region Unity Functions

            void Start()
            {
                //References
                _audioController = AudioController.instance;
                _selectionText = transform.GetChild(2).GetComponent<Text>();
                
                RefreshShownValue();
            }

            #endregion

            
            
            #region Public Functions

            public void NextSelection()
            {
                if (selectionIndex < selectionOptions.Count - 1)
                    selectionIndex++;
                else
                    selectionIndex = 0;

                _selectionText.text = selectionOptions[selectionIndex];
                
                //Play Toggle Audio
                _audioController.PlayAudio(AudioType.SFX_MouseClick1);
            }
            
            public void PreviousSelection()
            {
                if (selectionIndex > 0)
                    selectionIndex--;
                else
                    selectionIndex = selectionOptions.Count - 1;

                _selectionText.text = selectionOptions[selectionIndex];
                
                //Play Toggle Audio
                _audioController.PlayAudio(AudioType.SFX_MouseClick1);
            }

            public void AddSelectionOption(string optionText)
            {
                if (selectionOptions == null)
                {
                    selectionOptions = new List<string>();
                }
                selectionOptions.Add(optionText);
            }
            public void ClearSelectionOptions()
            {
                foreach (string option in selectionOptions)
                {
                    selectionOptions.Remove(option);
                }
            }

            public void RefreshShownValue()
            {
                if (_selectionText == null) return;
                if (selectionOptions.Count == 0) return; //to avoid being called before SettingMenu fills the list with the available resolutions
                _selectionText.text = selectionOptions[selectionIndex];
            }

            public void OnPointerEnter(PointerEventData eventData)
            {
                _selectionText.DOColor(highlightColor, tweenDuration);
            }

            public void OnPointerExit(PointerEventData eventData)
            {
                _selectionText.DOColor(defaultColor, tweenDuration);
            }

            public void HighlightArrow(Image arrowImage)
            {
                arrowImage.DOColor(highlightColor, tweenDuration);
            }
            public void ResetArrow(Image arrowImage)
            {
                arrowImage.DOColor(defaultColor, tweenDuration);
            }
            
            #endregion
        }
    }
}

