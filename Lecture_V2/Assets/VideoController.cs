using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour {

    public VideoPlayer videoPlayer;
    public VideoClip[] videoClips;
    public int videoClipIndex;
    public bool playing = true;
 
    // Use this for initialization
    void Start () {
        videoPlayer.clip = videoClips[0];
    }
	
	// Update is called once per frame
	void Update () {
        if (OVRInput.GetDown(OVRInput.Button.Three))
        {
            SetNextClip();
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SetNextClip();
        }
        playing = videoPlayer.isPlaying;
    }

    public void SetNextClip()
    {
        if (!videoPlayer.isPlaying && videoClipIndex < videoClips.Length - 1)
        {
            videoClipIndex++;

            //if (videoClipIndex >= videoClips.Length)
            //{
            //    videoClipIndex = videoClipIndex % videoClips.Length;
            //}

            videoPlayer.clip = videoClips[videoClipIndex];
            videoPlayer.Play();
        }
    }

    public void PlayPause()
    {
        if (videoPlayer.isPlaying) videoPlayer.Pause();
        else videoPlayer.Play();
    }
}
