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
    private  float zoomTimeLeft=0f;
    private const float zoomTime = 15f;


    void Start()
    {
        Camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.Z)){
        //     Camera.orthographicSize=zoomOut;
        // }else if(Input.GetKeyUp(KeyCode.Z)){
        //     Camera.orthographicSize=zoomIn;
        // }


        if(zoomTimeLeft>0){
            Camera.orthographicSize=zoomOut;
            zoomTimeLeft-=Time.deltaTime;
        }else{
            Camera.orthographicSize=zoomIn;
        }

        Renderer[] sceneRenderers = FindObjectsOfType<Renderer>();
         for (int i = 0; i < sceneRenderers.Length; i++)
             if (IsVisible(sceneRenderers[i]) && sceneRenderers[i].tag=="Lava" && sceneRenderers[i].name.StartsWith("Ground")){
                
                // var diff = transform.position.y - sceneRenderers[i].transform.position.y;
                // if(diff>14){
                //     transform.position = new Vector3(transform.position.x,transform.position.y +(diff - 13)* Time.deltaTime,transform.position.z);
                // }
                
             }
                 


    }

    //Testing Function 
    // @author:Chirag
    bool IsVisible(Renderer renderer) {
         Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
         return (GeometryUtility.TestPlanesAABB(planes, renderer.bounds)) ? true : false;
     }


    public void zoomSelected(){
        zoomTimeLeft+=zoomTime;
    }

}
