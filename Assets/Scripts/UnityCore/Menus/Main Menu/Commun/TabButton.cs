using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UnityCore
{
    namespace Menu
    { 
        public class TabButton : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler, IPointerClickHandler
        {
            public TabsGroup tabsGroup;
            [HideInInspector] public Text buttonText;
            [HideInInspector] public Image buttonImage;
            
            #region Unity Functions

            private void Awake()
            {
                buttonText = transform.GetComponentInChildren<Text>();
                buttonImage = GetComponent<Image>();
                //tabsGroup.Subscribe(this);
            }

            #endregion

            #region Public Functions

            #endregion

            public void OnPointerEnter(PointerEventData eventData)
            {
                tabsGroup.OnTabEnter(this);
            }
            
            public void OnPointerExit(PointerEventData eventData)
            {
                tabsGroup.OnTabExit(this);
            }

            public void OnPointerClick(PointerEventData eventData)
            {
                tabsGroup.OnTabSelected(this);
            }
        }
    }
}