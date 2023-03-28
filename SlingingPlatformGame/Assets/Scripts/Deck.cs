using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Deck : MonoBehaviour
{
    public int counter = 10;  // Initial value of counter
    // public Color highlightColor = Color.black;  // Color to use for highlight
    private Color originalColor;  // Original color of the game object
    // private Renderer renderer;  // Renderer component of the game object
    public Slingshot script;
    public string platformType;
    public TextMeshProUGUI countVal;
    public Animator animator;
    


    void Start()
    {
        GameObject slingshotObj = GameObject.Find("Slingshot");
        script = slingshotObj.GetComponent<Slingshot>();
        if(countVal != null){
            if(counter==-1){
                countVal.text =  "Unlock in Level 4";
            }
            else if(counter==-2){
                countVal.text =  "Unlock in Level 5";
            }
            else{
                countVal.text = counter.ToString();
            }

        //    countVal.text =  counter >-1? counter.ToString(): "Unlock in Level 4";
        }
        if(counter <=0 ){
            script.StopPlatform(platformType);
        } else {
            script.AddPlatform(platformType);
        }

        


    }

    // void OnMouseDown()
    // {
    //     if(counter > 0)
    //     {   
    //         Debug.Log(platformType.ToString());
    //         script.selectedPlatform = platformType;
    //         script.CreatePlatformFromIndex();
    //     }
    // }

    void ColorChange(){
        Debug.Log("updating color");
        if(counter == 0) {
            countVal.color = Color.red;
        } else {
            countVal.color = Color.black;
        }
    }

    public void checking(){
        if(counter > 0)
        {   
            Debug.Log(platformType.ToString());
            script.selectedPlatform = platformType;
            script.CreatePlatformFromIndex();
        }
    }

    public void DecreaseCount(){
        if(counter > 0){
            counter--;
            countVal.text = counter.ToString();
        }
        if (counter == 0){
            countVal.text = "0";
            script.StopPlatform(platformType);
        }
        ColorChange();
    }

    public void IncreaseCount(){
        counter++;
        countVal.text = counter.ToString();
        animator.SetTrigger("Change");
        script.AddPlatform(platformType);
        ColorChange();
    }



}
