using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowManager : MonoBehaviour
{
    public float Speed;
    private Transform target;
    private Rigidbody _rigidbody;

    private Vector3 _resetPosition;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _resetPosition = transform.position;
    }

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void OnEnable()
    {
        transform.position = _resetPosition;
    }


    private void Update()
    {
        if(Vector3.Distance(transform.position,target.position)>1.0f )
        transform.position = Vector3.MoveTowards(transform.position, target.position,Speed*Time.deltaTime);
        
    }
}
