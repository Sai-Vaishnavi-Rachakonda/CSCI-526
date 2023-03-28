using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    // public GameObject target;

    private Camera Camera;
    private float zoomOut = 13;
    private const float zoomIn=8.634074f; // Const do not change it

    void Start()
    {
        Camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z)){
            Camera.orthographicSize=zoomOut;
        }else if(Input.GetKeyUp(KeyCode.Z)){
            Camera.orthographicSize=zoomIn;
        }

    }
}
