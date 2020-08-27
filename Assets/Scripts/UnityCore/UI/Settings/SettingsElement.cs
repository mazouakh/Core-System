using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace UnityCore
{
    namespace Settings
    {
        public class SettingsElement : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler
        {
            [HideInInspector] public Image outlineImage;
            [HideInInspector] public Image highlightImage;

            public SettingsGroup settingsGroup;
            public Text elementText;

            #region Unity Functions

            private void Awake()
            {
                outlineImage = transform.GetChild(0).GetComponent<Image>();
                highlightImage = transform.GetChild(1).GetComponent<Image>();
            }

            #endregion

            #region Public Functions

            public void OnPointerEnter(PointerEventData eventData)
            {
                settingsGroup.OnElementEnter(this);
            }

            public void OnPointerExit(PointerEventData eventData)
            {
                settingsGroup.OnElementExit(this);
            }

            #endregion
        }
    }
}