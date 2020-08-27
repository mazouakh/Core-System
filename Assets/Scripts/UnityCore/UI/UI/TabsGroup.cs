using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityCore.Audio;
using AudioType = UnityCore.Audio.AudioType;

namespace UnityCore
{
    namespace UI
    {
        public class TabsGroup : MonoBehaviour
        {
            public enum NextTabDirection
            {
                NONE,
                Left,
                Right
            }
            
            public List<TabButton> tabButtons;
            public List<GameObject> menusToSwap;
            public Color imageIdleColor;
            public Color imageActiveColor;
            public Color textIdleColor;
            public Color textActiveColor;
            [SerializeField] private float tweenDuration = .5f;

            public  NextTabDirection nextTabDirection { get; private set; }

            private AudioController _audioController;
            private MenuController _menuController;
            private TabButton _selectedTab;
            private int _oldSelectedTabIndex;
            private bool _canPlayAudio;

            #region Unity functions
        
            private void Start()
            {
                _audioController = AudioController.instance; 
                _menuController = MenuController.instance;
                
                OnTabSelected(tabButtons[0], false);// set the home tab as selected by default on start
                                                                //canPlayAudio false so that on start we do not play "Selected" Audio
            }
        
            #endregion
            
            #region Public Functions
            
            public void OnTabEnter(TabButton tabButton)
            {
                ResetTabs();
                if (_selectedTab == null || tabButton != _selectedTab)
                {
                    //Tweening
                    tabButton.buttonImage.DOColor(imageActiveColor, tweenDuration);
                    tabButton.buttonText.DOColor(textActiveColor, tweenDuration);
                }
                
            }
        
            public void OnTabExit(TabButton tabButton)
            {
                ResetTabs();
            }
        
            public void OnTabSelected(TabButton tabButton, bool _canPlayAudio = true)
            {
                //if we're clicking on the tab  that is already selected
                if (_selectedTab == tabButton ) return;

                //check if we're clicking on the next or previous button
                if (_selectedTab != null)
                {
                    _oldSelectedTabIndex = _selectedTab.transform.GetSiblingIndex();
                    if (_selectedTab.transform.GetSiblingIndex() < tabButton.transform.GetSiblingIndex())
                    {
                        nextTabDirection = NextTabDirection.Left;
                    }else if(_selectedTab.transform.GetSiblingIndex() > tabButton.transform.GetSiblingIndex())

                    {
                        nextTabDirection = NextTabDirection.Right;
                    }
                    else
                    {
                        nextTabDirection = NextTabDirection.NONE;
                    }
                }
                
                _selectedTab = tabButton;
                ResetTabs();
                
                //Swap between Menus
                if (_oldSelectedTabIndex != tabButton.transform.GetSiblingIndex()) //if we're not clicking on the current tab
                {
                    _menuController.DisableMenu(menusToSwap[_oldSelectedTabIndex]); //disable the current tab
                    int index = tabButton.transform.GetSiblingIndex();
                    for (int i = 0; i < menusToSwap.Count; i++)
                    {
                        if (i == index)
                        {
                            _menuController.ActivateMenu(menusToSwap[i]);
                        }
                    }
                }
                
                
                //Tweening & Audio
                //Tweening
                tabButton.buttonImage.DOColor(imageActiveColor, tweenDuration);
                tabButton.buttonText.DOColor(textActiveColor, tweenDuration);
                //Tab Selection Audio
                if (!_canPlayAudio) return;
                _audioController.PlayAudio(AudioType.SFX_UIClick1);
            }
            #endregion
        
            #region Private Functions
        
            
            private void ResetTabs()
            {
                foreach (TabButton tabButton in tabButtons)
                {
                    if (_selectedTab!=null && tabButton == _selectedTab) continue; // dont reset the currently selected tab
                    
                    //Tweening
                    tabButton.buttonImage.DOColor(imageIdleColor, tweenDuration);
                    tabButton.buttonText.DOColor(textIdleColor, tweenDuration);
                }
            }
        
            #endregion
        }
    }
}