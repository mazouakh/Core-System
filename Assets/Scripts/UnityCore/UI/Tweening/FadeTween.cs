using System.Collections;
using UnityEngine;

namespace UnityCore
{
    namespace Tweening
    {
        [RequireComponent(typeof(CanvasGroup))]
        public class FadeTween : MonoBehaviour, IAnimation
        {
            [SerializeField] private float fadeInDuration;
            [SerializeField] private float fadeOutDuration;
        
            private CanvasGroup fadeCanvasGroup;
            private float elapsedTime;
        
            #region Unity Functions
        
            private void Awake()
            {
                fadeCanvasGroup = GetComponent<CanvasGroup>();
            }
        
            #endregion
            
            public void PlayAnimation()
            {
                StartCoroutine(DoFadeIn()); 
            }
        
            public void ResetDefault()
            {
                StartCoroutine(DoFadeOut());
            }
            
            private IEnumerator DoFadeOut()
            {
                while(fadeCanvasGroup.alpha > 0)
                {
                    
                    elapsedTime += Time.deltaTime;
                    fadeCanvasGroup.alpha = Mathf.Clamp01(1.0f - (elapsedTime / fadeOutDuration));
                    yield return null;
                }
        
                elapsedTime = 0;
                fadeCanvasGroup.interactable = false;
                fadeCanvasGroup.blocksRaycasts = false;
                yield return null;
            }
            private IEnumerator DoFadeIn()
            {
                while(fadeCanvasGroup.alpha < 1)
                {
                    
                    elapsedTime += Time.deltaTime;
                    fadeCanvasGroup.alpha = Mathf.Clamp01(0f + (elapsedTime / fadeInDuration));
                    yield return null;
                }
                elapsedTime = 0;
                fadeCanvasGroup.interactable = true;
                fadeCanvasGroup.blocksRaycasts = true;
                yield return null;
            }
        }
    }
}