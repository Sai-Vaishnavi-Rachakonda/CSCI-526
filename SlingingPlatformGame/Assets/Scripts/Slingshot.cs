using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class Slingshot : MonoBehaviour
{
    public LineRenderer[] lineRenderers;
    public Transform[] stripPositions;
    public Transform center;
    public Transform idlePosition;

    public Vector3 currentPosition;

    public float maxLength;

    public float bottomBoundary;
    public float topBoundary = Screen.height;

    bool isMouseDown;

    public GameObject[] platformPrefab;

    public float platformPositionOffset;

    Rigidbody2D platform;
    Collider2D platformCollider;

    public float force;
    private Vector3 lr0;
    private Vector3 lr1;
    private GameObject player;

    public string selectedPlatform = "default";
    public ArrayList StoppedPlatforms = new ArrayList();
    public ArrayList PlatformNames = new ArrayList {"default", "ice"};

    public float targetTimeAfterPlatformIsOver=10f,waitForMessage=5f;


    LineRenderer lineRenderer;  //LineRenderer for projectile trajectory prediction
    void Start()
    {
        lineRenderers[0].positionCount = 2;
        lineRenderers[1].positionCount = 2;
        lineRenderers[0].SetPosition(0, stripPositions[0].position);
        lineRenderers[1].SetPosition(0, stripPositions[1].position);
        lr0 = transform.position;

        GameObject canvasObj = GameObject.Find("Canvas2");
        if (canvasObj)
        {
            GameObject Pannel = canvasObj.transform.Find("RestartingPanel").gameObject;
            if (Pannel != null)
            {
                Pannel.SetActive(false);
            }
        }

        if (SceneManager.GetActiveScene().name == "Level 2")
        {
            selectedPlatform = "ice";
        }

        CreatePlatform();
    }

    public void CreatePlatformFromIndex()
    {
        platform.gameObject.SetActive(false);
        platform = null;
        platformCollider = null;
        platform = new Rigidbody2D();
        CreatePlatform();
    }

    public void StopPlatform(string PlatformName){
        if (!StoppedPlatforms.Contains(PlatformName))
        {
            StoppedPlatforms.Add(PlatformName);
        }
    }


    void CreatePlatform()
    {
        switch (selectedPlatform)
        {
            case "default":
            {
                if (!StoppedPlatforms.Contains(selectedPlatform))
                {
                    platform = Instantiate(platformPrefab[0]).GetComponent<Rigidbody2D>();
                }
                break;
            }
        
            case "ice":
            {
                if (!StoppedPlatforms.Contains(selectedPlatform))
                {
                    platform = Instantiate(platformPrefab[1]).GetComponent<Rigidbody2D>();
                }
                break;
            }
        
            case "weightedPlatform":
            {
                if (!StoppedPlatforms.Contains(selectedPlatform))
                {
                    platform = Instantiate(platformPrefab[2]).GetComponent<Rigidbody2D>();
                }
                break;
            }
            default:
            {
                platform = Instantiate(platformPrefab[0]).GetComponent<Rigidbody2D>();
                break;
            }
        }
        //var platformPrefabLen = platformPrefab.Length;
        //platform = Instantiate(platformPrefab[UnityEngine.Random.Range(0,platformPrefabLen)]).GetComponent<Rigidbody2D>();
        if(platform) {
            platformCollider = platform.GetComponent<Collider2D>();
            platformCollider.enabled = false;

            platform.isKinematic = true;
        }

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
                platformCollider.enabled = false;  // @author: Chirag
            }

            Vector3 platformForce = (currentPosition - center.position) * force * -1;

            //Simulating the trajectory of the projectile
            Vector3[] positions = new Vector3[5];
            for (int i = 0; i < positions.Length; i++)
            {
                float t = i / (float)positions.Length;
                positions[i] = currentPosition + platformForce * t + Physics.gravity * t * t / 2f;
            }

            //Drawing the trajectory line using a LineRenderer component
            // lineRenderer = GetComponent<LineRenderer>();
            // lineRenderer.positionCount = positions.Length;
            PathPoints.instance.Clear();
            for (int i = 0; i < positions.Length; i++)
            {
                // lineRenderer.SetPosition(i, positions[i]);
                PathPoints.instance.CreateCurrentPathPoint(positions[i]);
            }

        }
        else
        {
            // lineRenderer.positionCount = 0;  //Reset the trajectory predicting linerenderer
            ResetStrips();
        }

        //when all platforms are used
        if (StoppedPlatforms.Count == PlatformNames.Count)
        {
            targetTimeAfterPlatformIsOver -= Time.deltaTime;
            if (targetTimeAfterPlatformIsOver<=0.0f){
                if(waitForMessage==5f)
                    openRestartPannel();
                else if(waitForMessage<=0.0f)
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                waitForMessage-=Time.deltaTime;
            }
        }
    }

    void openRestartPannel()
    {
        GameObject canvasObj = GameObject.Find("Canvas2");
        if (canvasObj)
        {
            GameObject Pannel = canvasObj.transform.Find("RestartingPanel").gameObject;
            if (Pannel != null)
            {
                Pannel.SetActive(true);
            }
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
        if(platform)
        {
            platform.isKinematic = false;
            Vector3 platformForce = (currentPosition - center.position) * force * -1;
            platform.velocity = platformForce;    

            platform.GetComponent<Platform>().Release();
        }

        platform = null;
        platformCollider = null;
        platform = new Rigidbody2D();
        Invoke("CreatePlatform", 2);

        GameObject deckObj = GameObject.Find("PlatformPanel");
        if (deckObj)
        {
            GameObject parentObject = deckObj.transform.Find(selectedPlatform).gameObject;
            Deck scriptObj = parentObject.GetComponent<Deck>();
            scriptObj.DecreaseCount();
        }
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