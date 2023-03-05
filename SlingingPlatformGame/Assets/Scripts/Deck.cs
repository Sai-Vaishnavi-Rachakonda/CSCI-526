using UnityEngine;
using TMPro;

public class Deck : MonoBehaviour
{
    public int counter = 10;  // Initial value of counter
    private TextMesh textMesh;
    // public Color highlightColor = Color.black;  // Color to use for highlight
    private Color originalColor;  // Original color of the game object
    private Renderer renderer;  // Renderer component of the game object
    public Slingshot script;
    public string platformType="default";
    public TextMeshProUGUI countVal;


    void Start()
    {
        GameObject slingshotObj = GameObject.Find("Slingshot");
        script = slingshotObj.GetComponent<Slingshot>();
        if(countVal != null){
           countVal.text =  counter >-1? counter.ToString(): "Unlock in Level 3";
        }
        if(counter <=0 ){
            script.StopPlatform(platformType);
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
    }

    public void IncreaseCount(){
            counter++;
            countVal.text = counter.ToString();

    }



}
