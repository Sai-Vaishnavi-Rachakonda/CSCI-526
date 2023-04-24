using UnityEngine;
using TMPro;

public class bounceScript : MonoBehaviour {
    public GameObject bouncePowerup;
    public TextMeshProUGUI BounceTimer;

    private float bounceTimeLeft;
    private bool bounceBoolean = false;

    

    // void Update() {
        
    // }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("bounce-powerup")) {
            Destroy(collision.gameObject);
            bounceTimeLeft = 15f;
            bounceBoolean = true;
            bouncePowerup.SetActive(true);
            BounceTimer.enabled = true;
        }
        if (bounceBoolean) {
            bounceTimeLeft -= Time.deltaTime;
            if (bounceTimeLeft <= 0f) {
                bounceTimeLeft = 0f;
                bounceBoolean = false;
                bouncePowerup.SetActive(false);
                BounceTimer.enabled = false;
            }
            BounceTimer.text = "Bounce Powerup: " + bounceTimeLeft.ToString("F1");
        }
    }
}



// if(collision.CompareTag("bounce-powerup")){
            
            
//             bounceTimeLeft = 15f;
            
//             // GameObject Panel = GameObject.Find("Head");
//             // if (Panel){
//             //     GameObject shield = Panel.transform.Find("Shield").gameObject;
//             //     shield.SetActive(true);
//                 BounceTimer.enabled = true;
//                 while(bounceTimeLeft >= 0){
//                 bounceTimeLeft -= Time.deltaTime;
           
                
                
               
                

//                 BounceTimer.text = "Bounce Powerup: " + bounceTimeLeft.ToString("F1");
            
            
//         }
//         BounceTimer.enabled = false;
        
//     }