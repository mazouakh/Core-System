using System;
using UnityEngine;

namespace UnityCore
{
    namespace Menu
    {
        public class TestMenu : MonoBehaviour
        {
            public PageController pageController;
            
#if UNITY_EDITOR
            private void Update()
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    pageController.TurnPageOn(PageType.Loading);
                }
                if (Input.GetKeyDown(KeyCode.G))
                {
                    pageController.TurnPageOff(PageType.Loading);
                }
                if (Input.GetKeyDown(KeyCode.H))
                {
                    pageController.TurnPageOff(PageType.Loading, PageType.Menu);
                }
                if (Input.GetKeyDown(KeyCode.J))
                {
                    pageController.TurnPageOff(PageType.Loading, PageType.Menu, true);
                }
            }

#endif
        }
    }
}