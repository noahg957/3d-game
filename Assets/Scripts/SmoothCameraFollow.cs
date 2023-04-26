using System.Collections;
using System.Collections.Generic;

using UnityEngine;



public class SmoothCameraFollow : MonoBehaviour
{

    private Vector3 _offset;
    [SerializeField] private Transform target;
    [SerializeField] private float smoothTime;
    private Vector3 _currentVelocity = Vector3.zero;



    private void Awake()
    {
        Vector3 targetPosition = new Vector3(target.position.x,
            target.position.y, transform.position.z);

        _offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = target.position + _offset;
        targetPosition.z = transform.position.z; // keep the same z-coordinate as the camera's initial position
        transform.position = Vector3.SmoothDamp(transform.position,
            targetPosition, ref _currentVelocity, smoothTime);
    }

}

