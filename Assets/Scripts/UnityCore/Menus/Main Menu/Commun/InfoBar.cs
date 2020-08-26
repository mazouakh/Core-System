using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

namespace UnityCore
{
    namespace Menu
    {
        public class InfoBar : MonoBehaviour
        {
            [Tooltip("If not Enabled on start, leave the first string empty since it wont be taken into account")]
            [SerializeField] private bool enabled;
            [SerializeField] private bool continuousDisplay;
            [SerializeField] private bool verticalDisplay;
            //[SerializeField] private float textOffset;
            
            public InfoBarItem infoBarItem;
            [Range(0,10)]
            public float speed = 3;
            public string[] messages;
        
            private float _width;
            private float _height;
            private InfoBarItem _currentItem;
            private int index;
            private RectTransform rt;
            
        
            #region Unity Functions
        
            private void Start()
            {
                _width = GetComponent<RectTransform>().rect.width;
                _height = GetComponent<RectTransform>().rect.height;

                if (enabled) AddInfoBarItem(messages[0]);
            }
        
            private void Update()
            {
                if(!enabled) return;
                if (!verticalDisplay)
                {
                    if (continuousDisplay) // if all messages should be displayed inline continuously
                    {
                        if (_currentItem == null || _currentItem.GetXPosition <= -_currentItem.GetWidth)
                        {
                            if (index < messages.Length - 1)
                            {
                                index++;
                            }
                            else index = 0;
                            AddInfoBarItem(messages[index]); //add a new item and display it
                        }
                    }
                    else //if each message should be displayed on its own
                    {
                        if (_currentItem == null || _currentItem.GetXPosition <= -_width - _currentItem.GetWidth)
                        {
                            if (index < messages.Length - 1)
                            {
                                index++;
                            }
                            else index = 0;
                            AddInfoBarItem(messages[index]); //add a new item and display it
                        }
                    }
                }
                else
                {
                    if (continuousDisplay) // if all messages should be displayed inline continuously
                    {
                        if (_currentItem == null || _currentItem.GetYPosition >= -_height + _currentItem.GetHeight)
                        {
                            //Debug.Log(_currentItem.GetYPosition + "compared to: "+ (-_height + _currentItem.GetHeight));
                            if (index < messages.Length - 1)
                            {
                                index++;
                            }
                            else index = 0;
                            AddInfoBarItem(messages[index]); //add a new item and display it
                        }
                    }
                    else //if each message should be displayed on its own
                    {
                        if (_currentItem == null || _currentItem.GetYPosition >= _height + _currentItem.GetHeight)
                        {
                            if (index < messages.Length - 1)
                            {
                                index++;
                            }
                            else index = 0;
                            AddInfoBarItem(messages[index]); //add a new item and display it
                        }
                    }
                }
                
            }

            
            #endregion

            #region Public Functions

            public void ToggleText()
            {
                foreach (Transform child in transform)
                {
                    Destroy(child.gameObject);
                }
                index = 0;
                enabled = !enabled;
            }

            #endregion
            
            #region Private Functions

            private void AddInfoBarItem(string message)
            {
                if (verticalDisplay)
                {
                    _currentItem = Instantiate(infoBarItem, transform);
                    //TODO figure out a way to add the offset without getting the odd spacing behaviour on lower resolution
                    // _currentItem = Instantiate(infoBarItem, 
                    //     new Vector3(GetComponent<RectTransform>().position.x, transform.position.y -_height - textOffset,0),
                    //     quaternion.identity, transform);
                }
                else
                {
                    _currentItem = Instantiate(infoBarItem, transform);
                }
                
                _currentItem.Initialize(_width, speed, !verticalDisplay? (continuousDisplay? message + "  |  " : message) : message);
            }

            #endregion
        }
    }
}