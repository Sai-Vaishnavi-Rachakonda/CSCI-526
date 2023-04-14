using UnityEngine;

public class bombplatform : MonoBehaviour
{
    //to make the explosion image dissappearß
    private void Update()
    {
        Destroy(this.gameObject,0.5f);
    }
}

