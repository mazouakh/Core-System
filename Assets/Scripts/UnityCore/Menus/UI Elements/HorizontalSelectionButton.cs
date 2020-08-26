using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UnityCore
{
    namespace Menu
    {
        public class HorizontalSelectionButton : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
        {
            [SerializeField] private HorizontalSelection _horSelect;
            private Image _image;

            #region Unity Functions

            void Awake()
            {
                _image = GetComponent<Image>();
            }

            #endregion

            #region Public Functions

            public void OnPointerEnter(PointerEventData eventData)
            {
                _horSelect.HighlightArrow(_image);
            }

            public void OnPointerExit(PointerEventData eventData)
            {
                _horSelect.ResetArrow(_image);
            }

            #endregion
        }
    }
}

