using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour {

    public VideoPlayer videoPlayer;
    public VideoClip[] videoClips;
    public int videoClipIndex;

    // Use this for initialization
    void Start () {
        videoPlayer.clip = videoClips[0];
    }
	
	// Update is called once per frame
	void Update () {
        if (OVRInput.Get(OVRInput.RawButton.Y)) SetNextClip();
        if (OVRInput.Get(OVRInput.RawButton.X)) PlayPause();

        if (Input.GetKey(KeyCode.Space)) SetNextClip();
        if (Input.GetKey(KeyCode.Tab)) PlayPause();
    }

    public void SetNextClip()
    {
        videoClipIndex++;

        if (videoClipIndex >= videoClips.Length)
        {
            videoClipIndex = videoClipIndex % videoClips.Length;
        }

        videoPlayer.clip = videoClips[videoClipIndex];
        videoPlayer.Play();
    }

    public void PlayPause()
    {
        if (videoPlayer.isPlaying) videoPlayer.Pause();
        else videoPlayer.Play();
    }
}
