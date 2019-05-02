using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public VideoController vid;
    public GameObject gam;
    // Use this for initialization
    void Start()
    {
        gam = GameObject.Find("Video Player");
        vid = gam.GetComponent<VideoController>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((OVRInput.GetDown(OVRInput.Button.One) && !vid.playing) || (OVRInput.GetDown(OVRInput.Button.Two)))
        {
            SceneManager.LoadScene("cave");
        }
    }
}
