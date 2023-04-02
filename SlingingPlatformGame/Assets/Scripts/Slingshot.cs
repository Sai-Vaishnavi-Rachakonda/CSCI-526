using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using TMPro;

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
    public ArrayList remainingPlatforms = new ArrayList {"default", "ice", "bounce","bomb"};

    public float targetTimeAfterPlatformIsOver=45f,waitForMessage=2f;
    public static long timeLine;
    public TextMeshProUGUI Timer;


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

        if (SceneManager.GetActiveScene().name == "Level 3")
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
        if (remainingPlatforms.Contains(PlatformName))
        {
            remainingPlatforms.Remove(PlatformName);
        }
    }

    public void AddPlatform(string PlatformName){
        if (!remainingPlatforms.Contains(PlatformName))
        {
            remainingPlatforms.Add(PlatformName);
            if(selectedPlatform == "")
            {
                selectedPlatform = PlatformName;
                CreatePlatform();
            }
        }
    }


    void CreatePlatform()
    {
        Debug.Log("lets "+selectedPlatform);
        if (!remainingPlatforms.Contains(selectedPlatform))
        {
            if (remainingPlatforms.Count != 0) {
                selectedPlatform = (string)remainingPlatforms[0];
            }
            else {
                selectedPlatform = "";
            }
        }
        switch (selectedPlatform)
        {
            
            case "default":
            {
                platform = Instantiate(platformPrefab[0]).GetComponent<Rigidbody2D>();
                break;
            }
        
            case "ice":
            {
                platform = Instantiate(platformPrefab[1]).GetComponent<Rigidbody2D>();
                break;
            }
        
            case "bounce":
            {
                platform = Instantiate(platformPrefab[2]).GetComponent<Rigidbody2D>();
                break;
            }
            case "bomb":
            {
                platform = Instantiate(platformPrefab[3]).GetComponent<Rigidbody2D>();
                break;
            }
            default:
            {
                platform = null;
                break;
            }
        }
        //var platformPrefabLen = platformPrefab.Length;
        //platform = Instantiate(platformPrefab[UnityEngine.Random.Range(0,platformPrefabLen)]).GetComponent<Rigidbody2D>();
        if(platform) {
            platformCollider = platform.GetComponent<Collider2D>();
            if (platformCollider && selectedPlatform=="bomb")
            {
                platformCollider.enabled = true;  // @author: Chirag
            }else if(platformCollider){
                platformCollider.enabled = false;  // @author: Chirag
            }

            platform.isKinematic = true;
        }
        

        ResetStrips();
    }

    void Update()
    {
        // @author: Chirag

        lineRenderers[0].SetPosition(0,new Vector3(center.position.x+0.4f,center.position.y-0.06f,center.position.z));
        lineRenderers[1].SetPosition(0,new Vector3(center.position.x-0.4f,center.position.y-0.06f,center.position.z));
        lineRenderers[0].SetPosition(1,idlePosition.position);
        lineRenderers[1].SetPosition(1,idlePosition.position);
        // var lineRendererPosition = lineRenderers[0].GetPosition(0);
        // var lineRendererPosition1 = lineRenderers[1].GetPosition(0);
        

        // var nposSling = transform.position;
        // var change = nposSling - lr0;
        
        // if(!(transform.position.x-0.5<lineRendererPosition.x && transform.position.x+0.5>lineRendererPosition.x)){
            
        //     lineRenderers[0].SetPosition(0, new Vector3(lineRendererPosition.x+change.x,lineRendererPosition.y+change.y,lineRendererPosition.z+change.z));
        //     lineRenderers[1].SetPosition(0, new Vector3(lineRendererPosition1.x+change.x,lineRendererPosition1.y+change.y,lineRendererPosition1.z-change.z));
        // }

        // else if(!(transform.position.y-0.5<lineRendererPosition.y && transform.position.y+0.5>lineRendererPosition.y)){
            
        //     lineRenderers[0].SetPosition(0, new Vector3(lineRendererPosition.x+change.x,lineRendererPosition.y+change.y,lineRendererPosition.z+change.z));
        //     lineRenderers[1].SetPosition(0, new Vector3(lineRendererPosition1.x+change.x,lineRendererPosition1.y+change.y,lineRendererPosition1.z-change.z));
        // }

        // lr0 = transform.position;

        if (isMouseDown)
        {

            //Strip issue is coming due to this code
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10;

            currentPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            currentPosition = center.position + Vector3.ClampMagnitude(currentPosition
                - center.position, maxLength);

            currentPosition = ClampBoundary(currentPosition);

        
            Debug.Log("Current: "+currentPosition);
            Debug.Log("Mouse: "+mousePosition);
            Debug.Log("Max: "+maxLength);

            SetStrips(currentPosition);

            if (platformCollider && selectedPlatform=="Bomb")
            {
                platformCollider.enabled = true;  // @author: Chirag
            }else if(platformCollider){
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
        if (remainingPlatforms.Count == 0) 
        {
            targetTimeAfterPlatformIsOver -= Time.deltaTime;
            if (targetTimeAfterPlatformIsOver<=0.0f){
                if(waitForMessage==2f)
                    openRestartPannel();
                else if(waitForMessage<=0.0f){
                    Buttonscript.timePerParse.Stop();
                    timeLine = Buttonscript.timePerParse.ElapsedTicks/10000000;
                    Buttonscript.timePerParse.Reset();
                    Buttonscript.dbObj.setTimeLine(timeLine);
                    Buttonscript.dbObj.setOutcome(0);
                    Buttonscript.dbObj.setReasonOfLevelEnd("out of platforms");
                    Buttonscript.dbObj.setOrbsCollected();
                    FinishLine.postToDatabase(Buttonscript.dbObj);
                    Buttonscript.dbObj.resetPlatformCords();
                    Buttonscript.dbObj.resetPlatformCount();
                    Buttonscript.dbObj.resetPlatformShoot();
                    Buttonscript.dbObj.resetreasonOfLevelEnd();
                    Buttonscript.dbObj.resetOrbsCollected();
                    Buttonscript.dbObj.resetCheckpoint();
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                    Buttonscript.timePerParse.Start();
                    if (Buttonscript.timePerParse!= null && Timer != null && Buttonscript.timePerParse.Elapsed != null &&  Buttonscript.timePerParse.Elapsed.ToString("mm\\:ss")!= ""){
                        Timer.text = Buttonscript.timePerParse.Elapsed.ToString("mm\\:ss"); 
                    }
                    targetTimeAfterPlatformIsOver=45f;
                    waitForMessage=2f;
                }
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
            platform.GetComponent<Platform>().Release(selectedPlatform);

            platform = null;
            platformCollider = null;
            platform = new Rigidbody2D();
            Invoke("CreatePlatform", 2);

            GameObject deckObj = GameObject.Find("SelectPlatform");
            if (deckObj)
            {
                GameObject parentObject = deckObj.transform.Find(selectedPlatform).gameObject;
                Deck scriptObj = parentObject.GetComponent<Deck>();
                scriptObj.DecreaseCount();
            }
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
        bottomBoundary = -100000000000000; //temporarty CHANGE
        vector.y = Mathf.Clamp(vector.y, bottomBoundary, 1000);
        
        return vector;
    }
}