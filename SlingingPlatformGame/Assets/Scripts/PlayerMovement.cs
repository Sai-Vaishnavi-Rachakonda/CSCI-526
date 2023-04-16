using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float jump=500f ;
    private float powerupJump = 750f;
    private float initialJump;
    private float move;
    public bool isJumping;

    private bool isJumpPowerupActive = false;
    private float jumpPowerupEndTime = 0f;
    private float jumpPowerupDuration = 15f;

    private Rigidbody2D rb;
    GameObject Slingshot,Camera, FinishLine; // @author: Chirag

    private Collision2D currentPlatform;  // @author: Chirag
    public Vector3 respawnPosition;
    public player_script ps;
    public GameObject key;

    Vector3 playerPosition;
    int count=0;

    private List<GameObject> BounceToRespawn = new List<GameObject>();
    private List<Vector3> BouncePositions = new List<Vector3>();
    private List<bool> isBounceRespawning = new List<bool>();

    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        // @author: Chirag
        Slingshot = GameObject.Find("Slingshot");
        Camera = GameObject.Find("Main Camera");  
        FinishLine = GameObject.Find("Finish");
        respawnPosition = transform.position;
        initialJump = jump;

        playerPosition = respawnPosition;

        GameObject[] respawnableBounce = GameObject.FindGameObjectsWithTag("bounce-powerup");
        foreach (GameObject obj in respawnableBounce) {
            BounceToRespawn.Add(obj);
            BouncePositions.Add(obj.transform.position);
            isBounceRespawning.Add(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(speed * move, rb.velocity.y);

        if(isJumpPowerupActive && Time.time < jumpPowerupEndTime)
        {
            jump = powerupJump;
        }
        else
        {
            jump = initialJump;
            GameObject Panel = GameObject.Find("Head");
            if (Panel){
                GameObject bounce = Panel.transform.Find("bounce")?.gameObject;
                bounce?.SetActive(false);
            }
        }

        
        if(move!=0){
            if(playerPosition.x==transform.position.x)
                count++;
            else
                count=0;
            if(count>100) // Why 200? its temp
                rb.velocity = new Vector2(speed * move, -12f);
            
        }else{
            count=0;
            
        }
        playerPosition=transform.position;
        
        if ((Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.UpArrow)) && !isJumping)
        {
            Collider2D platformCollider = Physics2D.OverlapBox(transform.position - new Vector3(0, 0.6f), new Vector2(0.8f, 0.1f), 0);
            // Debug.Log(platformCollider.gameObject.name);
            if (platformCollider != null && platformCollider.gameObject.name == "Platform 3(Clone)")
            {
                // The platform is a bouncy platform
                // Set the player's jump height accordingly
                // float jumpVelocity = Mathf.Sqrt((float)(1.5 * jump));
                rb.AddForce(new Vector2(rb.velocity.x, jump*1.5f));
                isJumping=true;
            }
            else
            {
                // The platform is not a bouncy platform
                // Use the default jump height
                rb.AddForce(new Vector2(rb.velocity.x, jump));
                isJumping=true;
            }
            
        }else if(Input.GetKeyDown(KeyCode.DownArrow)){
            rb.AddForce(new Vector2(rb.velocity.x, jump*-0.5f));
        }


        // @author: Chirag
        if(Camera.transform.position.x+1<=transform.position.x){ // moving forward
            var diff = transform.position.x - Camera.transform.position.x;
            var finishLinePosition = FinishLine.transform.position.x;
            if(Camera.transform.position.x+(9.055924)<finishLinePosition) // Camera Size: 8.055924
                Camera.transform.position = new Vector3(Camera.transform.position.x + Time.deltaTime*diff, Camera.transform.position.y, Camera.transform.position.z);
            
        }else if(Camera.transform.position.x-1>=transform.position.x){ // moving backward
            var diff = Camera.transform.position.x - transform.position.x;
            if(Camera.transform.position.x>=0) // Initial position of camera aprox 0
                Camera.transform.position = new Vector3(Camera.transform.position.x - 1.2f*Time.deltaTime*diff, Camera.transform.position.y, Camera.transform.position.z);
        }
        if(Camera.transform.position.y+0.3<transform.position.y){
            var diff = transform.position.y - Camera.transform.position.y;
            Camera.transform.position = new Vector3(Camera.transform.position.x, Camera.transform.position.y + Time.deltaTime*diff, Camera.transform.position.z);
        }else if(Camera.transform.position.y-0.1>=transform.position.y){ // moving backward
            var diff = Camera.transform.position.y - transform.position.y;

            // Testing camera movement
            Camera.transform.position = new Vector3(Camera.transform.position.x, Camera.transform.position.y - Time.deltaTime*diff, Camera.transform.position.z);

            


            // if(SceneManager.GetActiveScene().name=="Level 5"){
            //     if((transform.position.x>=45 && transform.position.x<=65) || transform.position.x>76){
            //         Camera.transform.position = new Vector3(Camera.transform.position.x, Camera.transform.position.y - Time.deltaTime*diff*6, Camera.transform.position.z);
            //     }
            //     else if(Camera.transform.position.y>=1.1)
            //         Camera.transform.position = new Vector3(Camera.transform.position.x, Camera.transform.position.y - Time.deltaTime*diff, Camera.transform.position.z);
            // }else if(SceneManager.GetActiveScene().name=="Level 7"){    
            //     if(transform.position.x>=45)
            //         Camera.transform.position = new Vector3(Camera.transform.position.x, Camera.transform.position.y - Time.deltaTime*diff*6, Camera.transform.position.z);
            //     else if(Camera.transform.position.y>=1.1)
            //         Camera.transform.position = new Vector3(Camera.transform.position.x, Camera.transform.position.y - Time.deltaTime*diff, Camera.transform.position.z);
                
            // }else if(Camera.transform.position.y>=1.1) // Initial position of camera aprox 0
            //     Camera.transform.position = new Vector3(Camera.transform.position.x, Camera.transform.position.y - Time.deltaTime*diff, Camera.transform.position.z);
        }
        if(currentPlatform!=null){
            if(SceneManager.GetActiveScene().name!="Level 0"){}
                //Slingshot.transform.position = new Vector3(currentPlatform.transform.position.x, currentPlatform.transform.position.y+2f, 0); 
        }

        if(ps.shieldBoolean && ps.shieldTimeLeft<=0){
            ps.shieldBoolean=false;
            GameObject shield = GameObject.FindGameObjectWithTag("shieldIndication");
            if(shield){
                shield.SetActive(false);
            }
            // TODO if player is in lava and time expires?
        }else if(ps.shieldBoolean){
            ps.shieldTimeLeft-=Time.deltaTime;
        }
        

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            // @author:  Chirag
            if(other.transform.position.x+2.28>transform.position.x && other.transform.position.x-2.28<=transform.position.x){
                if(other.transform.position.y+1.1>transform.position.y && other.transform.position.y-0.1<=transform.position.y){
                    Slingshot.transform.position = new Vector3(other.transform.position.x, other.transform.position.y+2f, 0);
                    currentPlatform = other;
                }
            }
        }

        else if (other.gameObject.CompareTag("Checkpoint Flag"))
        {
            // Debug.Log("entred");
            respawnPosition = transform.position;
        }
        
        else if (other.gameObject.CompareTag("Lava")  && !ps.shieldBoolean)
        {
            isJumping = false;
            transform.position = respawnPosition;
            transform.rotation = Quaternion.identity;
            Slingshot.transform.position = new Vector3(respawnPosition.x+1f, respawnPosition.y+1.2f, 0); 
            var list = ps.keysArray.ToArray();
            for (int i = 0; i < list.Length; i+=2)
            {
                Instantiate(key, new Vector3(list[i],list[i+1],0), Quaternion.identity);
            }
            ps.updateScore();
            LivesCounter.health -= 1;
            
        }else if (other.gameObject.CompareTag("Lava")){
            isJumping=false;
            if(other.transform.position.x+2.28>transform.position.x && other.transform.position.x-2.28<=transform.position.x){
                if(other.transform.position.y+1.1>transform.position.y && other.transform.position.y-0.1<=transform.position.y){
                    Slingshot.transform.position = new Vector3(other.transform.position.x, other.transform.position.y+2f, 0);
                    currentPlatform = other;
                }
            }
        }

        //Testing features
        else if (other.gameObject.CompareTag("Enemy")){
            if(transform.position.y>other.gameObject.transform.position.y){
                Destroy(other.gameObject);
            }else if(!ps.shieldBoolean){
                isJumping = false;
                transform.position = respawnPosition;
                transform.rotation = Quaternion.identity;
                Slingshot.transform.position = new Vector3(respawnPosition.x+1f, respawnPosition.y+1.2f, 0); 
                var list = ps.keysArray.ToArray();
                for (int i = 0; i < list.Length; i+=2)
                {
                    Instantiate(key, new Vector3(list[i],list[i+1],0), Quaternion.identity);
                }
                ps.updateScore();
                LivesCounter.health -= 1; 
            }
        }

        else if ((other.gameObject.CompareTag("Enemy")||other.gameObject.CompareTag("WeightedPulley")) && !ps.shieldBoolean)
        {
            isJumping = false;
            transform.position = respawnPosition;
            transform.rotation = Quaternion.identity;
            Slingshot.transform.position = new Vector3(respawnPosition.x+1f, respawnPosition.y+1.2f, 0); 
            var list = ps.keysArray.ToArray();
            for (int i = 0; i < list.Length; i+=2)
            {
                Instantiate(key, new Vector3(list[i],list[i+1],0), Quaternion.identity);
            }
            ps.updateScore();
            LivesCounter.health -= 1; 
        }
        else if(other.gameObject.CompareTag("bounce-powerup"))
        {
            //Destroy(other.gameObject);
            for (int i = 0; i < BounceToRespawn.Count; i++) {
                if(other.gameObject.name == BounceToRespawn[i].name) {
                    BounceToRespawn[i].SetActive(false);
                    isBounceRespawning[i] = true;
                }
            }
            Debug.Log("Called active");
            GameObject Panel = GameObject.Find("Head");
            if (Panel){
                GameObject bounce = Panel.transform.Find("bounce").gameObject;
                bounce.SetActive(true);
            }
            CollectJumpPowerup();
            StartCoroutine(RespawnBouncePowerUps());
            
        }
    }


    IEnumerator RespawnBouncePowerUps() {
        // Wait for 15 seconds
        yield return new WaitForSeconds(15);
        // Reset the positions of the objects to their original positions and set them active again
        for (int i = 0; i < BounceToRespawn.Count; i++) {
            if (isBounceRespawning[i]) {
                isBounceRespawning[i] = false;
                BounceToRespawn[i].transform.position = BouncePositions[i];
                BounceToRespawn[i].SetActive(true);
            }
        }

    }

    private void OnParticleCollision(GameObject other) {
        
        if (other.gameObject.CompareTag("LavaRain") && !ps.shieldBoolean){
            isJumping = false;
            transform.position = respawnPosition;
            transform.rotation = Quaternion.identity;
            Slingshot.transform.position = new Vector3(respawnPosition.x+1f, respawnPosition.y+1.2f, 0); 
            var list = ps.keysArray.ToArray();
            for (int i = 0; i < list.Length; i+=2)
            {
                Instantiate(key, new Vector3(list[i],list[i+1],0), Quaternion.identity);
            }
            ps.updateScore();
            LivesCounter.health -= 1;
        }
    }
    

    private void OnCollisionExit2D(Collision2D other)
    {
        // Debug.Log(other.gameObject);
        if (other.gameObject.CompareTag("Ground"))
        {
            // isJumping = true;
        }
    }
    
    // This function is called when the player collects the jump power-up
    public void CollectJumpPowerup()
    {
        // Set the power-up to active and set the end time
        isJumpPowerupActive = true;
        jumpPowerupEndTime = Time.time + jumpPowerupDuration;

        // Play a sound effect or show a message to indicate that the power-up has been collected
        Debug.Log("Jump Power-up collected!");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Checkpoint Flag"))
        {
            Debug.Log("Checkpoint entred");
            // Debug.Log("entred");
            respawnPosition = transform.position;
            Slingshot.transform.position = new Vector3(respawnPosition.x+1f, respawnPosition.y+1f, 0);
            GameObject[] flags = GameObject.FindGameObjectsWithTag("Flag Color");

            foreach (GameObject flag in flags){
                if(Math.Abs(flag.transform.position.x-transform.position.x)<10){
                    SpriteRenderer flagRendered = flag.GetComponent<SpriteRenderer>();
                    flagRendered.color = Color.green;
                }
                
            }

            
            
            // isJumping = false;
            var flagbox = collision.gameObject.GetComponent<BoxCollider2D>();
            flagbox.enabled = false;
            Buttonscript.dbObj.setCheckpoint();
            // isJumping = false;
            ps.clearKeysArray();

        }

    }
}