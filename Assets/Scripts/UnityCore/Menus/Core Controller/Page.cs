using System;
using System.Collections;
using UnityEngine;

namespace UnityCore
{
    namespace Menu
    {
        public class Page : MonoBehaviour
        {
            public static readonly string FLAG_ON = "On";
            public static readonly string FLAG_OFF = "Off";
            public static readonly string FLAG_NONE = "None";

            public bool debug;
            public PageType type;
            public bool useAnimation;
            
            public string TargetState { get; private set; }

            private Animator _animator;

            #region Unity Functions

            private void OnEnable()
            {
                CheckAnimationIntegrity();
            }

            #endregion

            #region Public Functions

            public void Animate(bool _on)
            {
                if (useAnimation)
                {
                    _animator.SetBool("on", _on);

                    StopCoroutine("AwaitAnimation");
                    StartCoroutine("AwaitAnimation", _on);
                }
                else
                {
                    //if no animation required just turn off
                    if (!_on)
                    {
                        gameObject.SetActive(false);
                    }
                }
            }

            #endregion

            #region Private Functions

            private IEnumerator AwaitAnimation(bool _on)
            {
                TargetState = _on ? FLAG_ON : FLAG_OFF;
                
                //wait fore the animator to reach the target state
                while (!_animator.GetCurrentAnimatorStateInfo(0).IsName(TargetState))
                {
                    yield return null;
                }
                
                //wait for the animator to finish animating
                while (_animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
                {
                    yield return null;
                }

                TargetState = FLAG_NONE; // after finished transitioning set the state to none
                
                Log("Page ["+type+"] finished transitioning to "+(_on ? "on" : "off"));

                if (!_on)
                {
                    gameObject.SetActive(false); //if the page was supposed to be turned off disable the gameObject
                }
            }

            private void CheckAnimationIntegrity()
            {
                if (useAnimation)
                {
                    _animator = GetComponent<Animator>();
                    if (!_animator)
                    {
                        LogWarning("You opted to animate page["+type+"] but no animator component exists on the object.");
                    }
                }
            }
            
            private void Log(string _msg)
            {
                if (!debug) return;
                Debug.Log("[Page]: "+_msg);
            }

            private void LogWarning(string _msg)
            {
                if (!debug) return;
                Debug.LogWarning("[Page]: "+_msg); 
            }
            #endregion
        }
    }
}