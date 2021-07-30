using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class vdoPlayer : MonoBehaviour
{
    public VideoPlayer video;
    // Start is called before the first frame update
    private void OnEnable()
    {
        if (video != null) video.Play();
    }

    private void OnDisable()
    {
        if (video != null) video.Stop();
    }
}
