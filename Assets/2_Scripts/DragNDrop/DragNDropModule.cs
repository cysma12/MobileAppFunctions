using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNDropModule : DragItem
{
    /*
        �ش� �ڵ�� ���� ī�带 �� �� �̺�Ʈ�� �߻��ϴ� ����� �����߽��ϴ�.
        �ٸ� ī�带 �� ��� ���ڸ��� ���ư��� �˴ϴ�.
        DragItem���� ���콺 �Է� ���� �Լ����� ���ǵǾ� �ֽ��ϴ�.
        DragNDropModule���� DragItem�� ����ϰ� ���� �̺�Ʈ�� ���� �Ǿ� �ֽ��ϴ�.
     */
     
    [SerializeField]
    private Transform _startPosition;
    private Transform _endPosition;

    private void Awake()
    {
        OnTrue += OnTrueEvent;
        OnFalse += OnFalseEvent;
        OnDrag += OnDragEvent;
    }


    public void OnTrueEvent()
    {
        Debug.Log("True Event"); 
    }

    public void OnFalseEvent()
    {
        Debug.Log("False Event");
        this.transform.DOLocalMove(_startPosition.localPosition, 0.5f);

    }

    public void OnDragEvent()
    {
        //Debug.Log("Drag Event");
    }

    public void OnMouseUpEvent()
    {

    }

}