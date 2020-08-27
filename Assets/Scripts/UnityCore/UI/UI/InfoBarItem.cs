using UnityEngine;
using UnityEngine.UI;

namespace UnityCore
{
    namespace UI
    {
        public class InfoBarItem : MonoBehaviour
        {
            public bool verticalScroll;

            private float _infoBarSize;
            private float _speed;
            private RectTransform rt;
            private Text _message;
            

            public float GetXPosition => rt.anchoredPosition.x; //this is the same as a property with a get that returns this value
            public float GetYPosition => rt.anchoredPosition.y; //this is the same as a property with a get that returns this value
            public float GetWidth => rt.rect.width;
            public float GetHeight => rt.rect.height;

            #region Unity Functions

            private void Awake()
            {
                _message = GetComponent<Text>();
            }

            private void Update()
            {
                rt.position += (verticalScroll? Vector3.up : Vector3.left) * (_speed * 100 * Time.deltaTime); //move the text item
                DestroyMessage();
            }

            #endregion
    
            #region Public Functions

            public void Initialize(float infoBarSize, float speed, string message)
            {
                _infoBarSize = infoBarSize;
                _speed = speed;
                rt = GetComponent<RectTransform>();
                _message.text = message;
            }

            public void DestroyMessage()
            {
                // destroy the game object if we reach the end of the text
                if (!verticalScroll)
                {
                    if (GetXPosition <= -_infoBarSize - GetWidth - 100) //the 100 is an offset to make sure a new text is instantiated before this one gets destroyed
                    {
                        Destroy(gameObject);
                    }
                }
                else
                {
                    if (GetYPosition >= GetHeight + 100) //the 100 is an offset to make sure a new text is instantiated before this one gets destroyed
                    {
                        Destroy(gameObject);
                    }
                }
                
            }

            #endregion
        }
    }
}