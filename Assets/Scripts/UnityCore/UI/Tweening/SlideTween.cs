using UnityEngine;
using DG.Tweening;

namespace UnityCore
{
    namespace Tweening
    {
        [RequireComponent(typeof(RectTransform))]
        public class SlideTween : MonoBehaviour, IAnimation
        {
            public enum Direction
            {
                NONE,
                Left,
                Right,
                Up,
                Down
            }
        
            [HideInInspector] public Direction slideDirection;
            [Tooltip("The Canvas this UI element belongs to")]
            [SerializeField] private RectTransform canvas;
            [Tooltip("The duration of the Tween")]
            [SerializeField] private float duration;
            [Tooltip("Smoothly snap all values to integers")]
            [SerializeField] private bool snapping;
            
            private RectTransform rt;
            private Vector3 defaultPosition;
        
            #region UnityFunctions
        
            private void Awake()
            {
                rt = GetComponent<RectTransform>();
                canvas = FindObjectOfType<Canvas>().GetComponent<RectTransform>();
                defaultPosition = rt.position;
            }
        
            #endregion
            
            public void PlayAnimation()
            {
                switch (slideDirection)
                {
                    case Direction.NONE :
                        Debug.Log("You have selected the Direction as NONE for : " + gameObject);
                        break;
                    case Direction.Left :
                        transform.DOMove(new Vector3(-rt.rect.width, rt.position.y, 0), duration,snapping);
                        break;
                    case Direction.Right :
                        transform.DOMove(new Vector3(Screen.currentResolution.width, rt.position.y, 0), duration,snapping);
                        break;
                    case Direction.Up :
                        transform.DOMove(new Vector3(-rt.position.x, rt.rect.height, 0), duration,snapping);
                        break;
                    case Direction.Down :
                        transform.DOMove(new Vector3(-rt.position.x, -Screen.currentResolution.height, 0), duration,snapping);
                        break;
                }    
            }
        
        
            public void ResetDefault()
            {
                rt.MoveUI(new Vector2(.07f, .75f), canvas, duration);
            }
        }
    }
}