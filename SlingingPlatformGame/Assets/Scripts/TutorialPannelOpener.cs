using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPannelOpener : MonoBehaviour
{
    public GameObject Pannel;
    // Start is called before the first frame update
    public void openPannel()
    {
        if (Pannel != null)
        {
            Pannel.SetActive(!Pannel.activeSelf);
        }
    }
}
