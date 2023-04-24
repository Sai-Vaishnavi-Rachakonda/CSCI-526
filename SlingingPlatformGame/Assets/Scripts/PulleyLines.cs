using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulleyLines : MonoBehaviour
{

    [SerializeField] 
    private List<Rigidbody2D> weights;
    
    private List<LIneController> allLines;

    [SerializeField] 
    private LIneController preFab;

    private void Awake()
    {
        allLines = new List<LIneController>();
        for (int i = 0; i < weights.Count; i++)
        {
            LIneController newLine = Instantiate(preFab);
            allLines.Add(newLine);
            newLine.AssignTarget(transform.position,weights[i].transform);
            // newLine.gameObject.SetActive(false);
        }

    }
    
}
