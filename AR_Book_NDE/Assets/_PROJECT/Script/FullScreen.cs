using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullScreen : MonoBehaviour
{
    void Start()
    {
        //Handheld.PlayFullScreenMovie("Video_1.mp4", Color.black, FullScreenMovieControlMode.CancelOnInput);
    }

    public void FullScreenOpen()
    {
        Handheld.PlayFullScreenMovie("Video_1.mp4");
    }

}