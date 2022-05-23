using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNDropModule : DragItem
{
    /*
        해당 코드는 같은 카드를 고를 시 이벤트가 발생하는 기능을 구현했습니다.
        다른 카드를 고를 경우 제자리로 돌아가게 됩니다.
        DragItem에는 마우스 입력 관련 함수들이 정의되어 있습니다.
        DragNDropModule에는 DragItem를 상속하고 각각 이벤트가 정의 되어 있습니다.
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