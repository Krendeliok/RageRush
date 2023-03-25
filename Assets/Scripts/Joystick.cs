using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(RectTransform))]
public class Joystick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    private RectTransform _transform;
    private Vector2 _offset;

    [SerializeField]
    private float _dragTheshold = 0.6f;
    [SerializeField]
    private int _dragMovementDistance = 30;
    [SerializeField]
    private int _dragOffsetDistance = 100;

    public event Action<Vector2> OnMove;

    public void OnDrag(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            _transform,
            eventData.position,
            null,
            out _offset);
        _offset = Vector2.ClampMagnitude(_offset, _dragOffsetDistance) / _dragOffsetDistance;
        _transform.anchoredPosition = _offset * _dragMovementDistance;

        OnMove?.Invoke(CalculateMovementInput(_offset));
    }

    private Vector2 CalculateMovementInput(Vector2 offset)
    {
        float x = Mathf.Abs(offset.x) > _dragTheshold ? offset.x : 0;
        float y = Mathf.Abs(offset.y) > _dragTheshold ? offset.y : 0;
        return new Vector2(x, y);
    }

    public void OnPointerDown(PointerEventData eventData){}

    public void OnPointerUp(PointerEventData eventData)
    {
        _transform.anchoredPosition = Vector2.zero;
        OnMove?.Invoke(Vector2.zero);
    }

    private void Awake()
    {
        _transform = (RectTransform)transform;
    }
}
