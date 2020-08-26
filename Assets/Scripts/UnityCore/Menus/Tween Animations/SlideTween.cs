using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Platinio.UI;

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
        rt.MoveUI(new Vector2(.07f, .75f), _canvas, duration);
    }
}
