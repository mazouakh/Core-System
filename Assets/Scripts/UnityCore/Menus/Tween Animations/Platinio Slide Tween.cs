using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Platinio.UI;

public class PlatinioSlideTween : MonoBehaviour
{
    public enum Direction
    {
        NONE,
        Left,
        Right,
        Up,
        Down
    }

    public Direction slideDirection;
    [Tooltip("The duration of the Tween")]
    [SerializeField] private float duration;
    [Tooltip("Smoothly snap all values to integers")]
    [SerializeField] private bool snapping;

    private RectTransform _canvas;
    private RectTransform rt;
    private Vector3 defaultPosition;

    #region UnityFunctions

    private void Awake()
    {
        rt = GetComponent<RectTransform>();
        _canvas = FindObjectOfType<Canvas>().GetComponent<RectTransform>();
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
                //transform.DOMove(new Vector3(-rt.rect.width, rt.position.y, 0), duration,snapping);
                rt.MoveUI(new Vector2(.35f, .53f), _canvas, duration);
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

    public void SwitchDirection()
    {
        switch (slideDirection)
        {
            case Direction.NONE :
                Debug.Log("You have selected the Direction as NONE for : " + gameObject);
                break;
            case Direction.Left :
                slideDirection = Direction.Right;
                break;
            case Direction.Right :
                slideDirection = Direction.Left;
                break;
            case Direction.Up :
                slideDirection = Direction.Down;
                break;
            case Direction.Down :
                slideDirection = Direction.Up;
                break;
        }  
    }

    public void ResetDefault()
    {
        rt.MoveUI(new Vector2(.35f, .53f), _canvas, duration);
    }
}
