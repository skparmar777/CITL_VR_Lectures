using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if ((OVRInput.GetDown(OVRInput.Button.One) && !VideoController.playing) || (OVRInput.GetDown(OVRInput.Button.Two)))
        {
            SceneManager.LoadScene("cave");
        }
    }
}
