using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.EventSystems;

public class VideoProcess : MonoBehaviour, IPointerDownHandler,IPointerUpHandler
{
    public VideoPlayer video;
    Slider process;
    bool slide = false;

    void Start()
    {
        process = GetComponent<Slider>();
    }

    public void OnPointerDown(PointerEventData a)
    {
        slide = true;
    }

    public void OnPointerUp(PointerEventData a)
    {
        float frame = (float)process.value * (float)video.frameCount;
        video.frame = (long)frame;
        slide = false;
    }



    void Update()
    {
        if (!slide)
        {
            process.value = (float)video.frame / (float)video.frameCount;
        }
    }
}
