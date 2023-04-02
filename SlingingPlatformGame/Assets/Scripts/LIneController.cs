using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LIneController : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private Transform target;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();

    }

 

    public void AssignTarget(Vector3 startPos, Transform newTarget)
    {
        Debug.Log(startPos);
        Debug.Log(newTarget.position);
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0,startPos);
        target = newTarget;
    }
    
    private void Update()
    {
        lineRenderer.SetPosition(1,target.position);
    }
}