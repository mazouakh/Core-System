using System;
using System.Collections;
using UnityEngine;

namespace UnityCore
{
    namespace Menu
    {
        public class PageController : MonoBehaviour
        {
            public static PageController instance;

            public bool debug;
            public PageType entryPage;
            public Page[] pages;

            private Hashtable _pagesHash;

            #region Unity Functions

            private void Awake()
            {
                if (!instance)
                {
                    Configure();
                    DontDestroyOnLoad(gameObject);
                }
                else
                    Destroy(gameObject);
            }

            private void Start()
            {
                //pages = FindObjectsOfType<Page>();
            }

            #endregion
            
            #region Public Functions
            
            public void TurnPageOn(PageType _type)
            {
                if (_type == PageType.None) return;
                if (!PageExists(_type))
                {
                    LogWarning("The page you're trying to turn on ["+_type+"] has not been registered.");
                    return;
                }

                Page _page = GetPage(_type);
                _page.gameObject.SetActive(true);
                _page.Animate(true);
            }
            public void TurnPageOff(PageType _off, PageType _on = PageType.None, bool waitForAnimation = false)
            {
                if (_off == PageType.None) return;
                if (!PageExists(_off))
                {
                    LogWarning("The page you're trying to turn off ["+_off+"] has not been registered.");
                    return;
                }

                Page _offPage = GetPage(_off);
                if (_offPage.gameObject.activeSelf)
                {
                    _offPage.Animate(false); //turn off the page
                }

                if (_on != PageType.None) //if we have a page we want to turn on after
                {
                    if (waitForAnimation)
                    {
                        Page _onPage = GetPage(_on);
                        StopCoroutine("WaitForPageExit");
                        StartCoroutine(WaitForPageExit(_onPage, _offPage));
                    }
                    else
                    {
                        TurnPageOn(_on);
                    }
                }
            }
            
            public bool PageIsOn(PageType _type)
            {
                if (!PageExists(_type))
                {
                    LogWarning("YOu are trying to detect if the page ["+_type+"] is on, but it has not been registered.");
                    return false;
                }

                return GetPage(_type).IsOn;
            }
            
            #endregion

            #region Private Functions

            private void Configure()
            {
                instance = this;
                _pagesHash = new Hashtable();
                RegisterAllPages();

                if (entryPage != PageType.None)
                {
                    TurnPageOn(entryPage);
                }
            }
            
            private IEnumerator WaitForPageExit(Page _on, Page _off)
            {
                while (_off.TargetState != Page.FLAG_NONE)
                {
                    yield return null;
                }
                
                TurnPageOn(_on.type);
            }

            private void RegisterAllPages()
            {
                foreach (Page _page in pages)
                {
                    RegisterPage(_page);
                }
            }

            private void RegisterPage(Page _page)
            {
                if (PageExists(_page.type))
                {
                    LogWarning("You are trying to register page["+ _page.type+"] that has already been registered.");
                    return;
                }
                
                _pagesHash.Add(_page.type, _page);
                Log("Registered new page ["+_page.type+"]");
            }

            private Page GetPage(PageType _type)
            {
                if (!PageExists(_type))
                {
                    LogWarning("You are trying to get page ["+_type+"] that has not been registered.");
                    return null;
                }
                return (Page)_pagesHash[_type];
            }

            private bool PageExists(PageType _type)
            {
                return _pagesHash.ContainsKey(_type);
            }

            private void Log(string _msg)
            {
                if (!debug) return;
                Debug.Log("[Page Controller]: "+_msg);
            }

            private void LogWarning(string _msg)
            {
                if (!debug) return;
                Debug.LogWarning("[Page Controller]: "+_msg); 
            }
            
            #endregion

            
        }
    }
}