using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    public LineRenderer[] lineRenderers;
    public Transform[] stripPositions;
    public Transform center;
    public Transform idlePosition;

    public Vector3 currentPosition;

    public float maxLength;

    public float bottomBoundary;

    bool isMouseDown;

    public GameObject[] platformPrefab;

    public float platformPositionOffset;

    Rigidbody2D platform;
    Collider2D platformCollider;

    public float force;
    private Vector3 lr0;
    private Vector3 lr1;
    private GameObject player;
    void Start()
    {
        lineRenderers[0].positionCount = 2;
        lineRenderers[1].positionCount = 2;
        lineRenderers[0].SetPosition(0, stripPositions[0].position);
        lineRenderers[1].SetPosition(0, stripPositions[1].position);
        lr0 = transform.position;

        CreatePlatform();
    }

    void CreatePlatform()
    {
        platform = Instantiate(platformPrefab[UnityEngine.Random.Range(0,2)]).GetComponent<Rigidbody2D>();
        platformCollider = platform.GetComponent<Collider2D>();
        platformCollider.enabled = false;

        platform.isKinematic = true;

        ResetStrips();
    }

    void Update()
    {
        

        var lineRendererPosition = lineRenderers[0].GetPosition(0);
        var lineRendererPosition1 = lineRenderers[1].GetPosition(0);
        

        var nposSling = transform.position;
        var change = nposSling - lr0;
        
        if(!(transform.position.x-0.5<lineRendererPosition.x && transform.position.x+0.5>lineRendererPosition.x)){
            
            lineRenderers[0].SetPosition(0, new Vector3(lineRendererPosition.x+change.x,lineRendererPosition.y+change.y,lineRendererPosition.z+change.z));
            lineRenderers[1].SetPosition(0, new Vector3(lineRendererPosition1.x+change.x,lineRendererPosition1.y+change.y,lineRendererPosition1.z-change.z));
        }

        else if(!(transform.position.y-0.5<lineRendererPosition.y && transform.position.y+0.5>lineRendererPosition.y)){
            
            lineRenderers[0].SetPosition(0, new Vector3(lineRendererPosition.x+change.x,lineRendererPosition.y+change.y,lineRendererPosition.z+change.z));
            lineRenderers[1].SetPosition(0, new Vector3(lineRendererPosition1.x+change.x,lineRendererPosition1.y+change.y,lineRendererPosition1.z-change.z));
        }

        lr0 = transform.position;

        if (isMouseDown)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10;

            currentPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            currentPosition = center.position + Vector3.ClampMagnitude(currentPosition
                - center.position, maxLength);

            currentPosition = ClampBoundary(currentPosition);

            SetStrips(currentPosition);

            if (platformCollider)
            {
                platformCollider.enabled = true;
            }
        }
        else
        {
            ResetStrips();
        }
    }

    private void OnMouseDown()
    {
        isMouseDown = true;
    }

    private void OnMouseUp()
    {
        isMouseDown = false;
        Shoot();
        currentPosition = idlePosition.position;
    }

    void Shoot()
    {
        platform.isKinematic = false;
        Vector3 platformForce = (currentPosition - center.position) * force * -1;
        platform.velocity = platformForce;

        platform.GetComponent<Platform>().Release();

        platform = null;
        platformCollider = null;
        Invoke("CreatePlatform", 2);
    }

    void ResetStrips()
    {
        currentPosition = idlePosition.position;
        SetStrips(currentPosition);
    }

    void SetStrips(Vector3 position)
    {
        lineRenderers[0].SetPosition(1, position);
        lineRenderers[1].SetPosition(1, position);

        if (platform)
        {
            Vector3 dir = position - center.position;
            platform.transform.position = position + dir.normalized * platformPositionOffset;
            platform.transform.right = -dir.normalized;
        }
    }

    Vector3 ClampBoundary(Vector3 vector)
    {
        vector.y = Mathf.Clamp(vector.y, bottomBoundary, 1000);
        return vector;
    }
}
