using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartQuiz : MonoBehaviour
{
    public VideoController vid;
    public GameObject gam;
    // Start is called before the first frame update
    void Start()
    {
        gam = GameObject.Find("Video Player");
        vid = gam.GetComponent<VideoController>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((OVRInput.GetDown(OVRInput.Button.One) && !vid.playing && vid.videoClipIndex == vid.videoClips.Length - 1) /*|| (OVRInput.GetDown(OVRInput.Button.Two))*/)
        {
            SceneManager.LoadScene("quiz");
        }
    }
}
