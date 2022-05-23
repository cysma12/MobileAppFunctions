using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragItem : MonoBehaviour
{
    public string Names = "";

    [HideInInspector]
    public delegate void TrueEvent();
    public delegate void FalseEvent();
    public delegate void DragEvent();
    public delegate void MouseUpEvent();
    public delegate void MouseDownEvent();
    public delegate void ReturnColliderPosEvent(Transform pos, string name);

    public TrueEvent OnTrue;
    public FalseEvent OnFalse;
    public DragEvent OnDrag;
    public MouseUpEvent OnMouseButtonUp;
    public MouseDownEvent OnMouseButtonDown;
    public ReturnColliderPosEvent OnColliderPos;

    public  int Layer = 20;

    private Vector3 prePos;
    private Vector3 preClickPos;

    private Vector3 _colliderPos;

    private bool _isFixPos = false;
    private bool _isActive = false;

    private string _colliderName = "";

    private void Awake()
    {
        OnColliderPos += OnColliderPosEvent;
    }

    public void OnColliderPosEvent(Transform pos, string name)
    {
    }

    private void OnMouseDown()
    {
        if (OnMouseButtonDown != null) OnMouseButtonDown();
    }

    private void OnMouseUp()
    {
        _isFixPos = false;

        if (_isActive)
        {
            if (Names == _colliderName) { if (OnTrue != null) OnTrue(); }
            else { if (OnFalse != null) OnFalse(); }
        }
        else
        {
            if (OnFalse != null) OnFalse();
        }
        if (OnMouseButtonUp != null) OnMouseButtonUp();
    }

    private void OnMouseDrag()
    {
        if (!_isFixPos)
        {
            _isFixPos = true;
            prePos = transform.position;
            preClickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (GetComponent<SpriteRenderer>() != null)
                GetComponent<SpriteRenderer>().sortingOrder = Layer;
        }
        transform.position = prePos + (Camera.main.ScreenToWorldPoint(Input.mousePosition) - preClickPos);

        if (OnDrag != null) OnDrag();
    }

    private void OnMouseExit()
    {
        _isFixPos = false;
    }
       
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (OnColliderPos != null) OnColliderPos(collision.transform,collision.name);
        _colliderName = collision.name;
        _isActive = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (OnColliderPos != null) OnColliderPos(collision.transform, collision.name);
        _colliderName = collision.name;
        _isActive = false;
    }
}