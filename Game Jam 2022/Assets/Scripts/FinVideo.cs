using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class FinVideo : MonoBehaviour
{
    public VideoPlayer video;
    private void Awake()
    {
        video = GetComponent<VideoPlayer>();
        video.Play();
        video.loopPointReached += CheckOver;
    }

    void CheckOver(VideoPlayer vp)
    {
        SceneManager.LoadScene(1);
    }

    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
