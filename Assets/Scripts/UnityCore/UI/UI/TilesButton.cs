using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UnityCore
{
    namespace UI
    {
        public class TilesButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
        {
            [HideInInspector] public Image buttonImage;
            [HideInInspector] public Image highlightImage;
            [HideInInspector] public Text buttonTitle;
            [HideInInspector] public Text buttonSubtitle;
            
            public TilesGroup tilesGroup;
            [Tooltip("Stay highlighted when selected?")]
            public bool enableSelection = true;
            //TODO make a separate tween script for scale change
            public bool changeScale;
            public Vector3 hoverScale = new Vector3(.9f,.9f,.9f);
            public float scaleDuration = 0.3f;
            
            private void Awake()
            {
                highlightImage = transform.GetChild(0).GetComponent<Image>();
                buttonImage = transform.GetChild(1).GetComponent<Image>();
                buttonTitle = transform.GetChild(2).GetComponent<Text>();
                if (transform.childCount > 3) 
                    buttonSubtitle = transform.GetChild(3).GetComponent<Text>();

                //tilesGroup.Subscribe(this);
            }

            public void OnPointerEnter(PointerEventData eventData)
            {
                tilesGroup.OnTileEnter(this);
            }

            public void OnPointerExit(PointerEventData eventData)
            {
                tilesGroup.OnTileExit(this);
            }

            public void OnPointerClick(PointerEventData eventData)
            {
                tilesGroup.OnTileSelected(this);
            }
        }
    }
}

