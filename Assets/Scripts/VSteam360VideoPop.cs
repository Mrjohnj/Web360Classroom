using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VSteam360VideoPop : MonoBehaviour
{
    public string url;
    VideoPlayer vidplayer;
       public bool video;
    // Start is called before the first frame update
    void Start()
    {
        vidplayer = GetComponent<VideoPlayer>();
        vidplayer.url = System.IO.Path.Combine (Application.streamingAssetsPath,"PopTest.mp4");
               
    }

    // Update is called once per frame
    void Update()
    {
      

      if(!video){
          vidplayer.Pause();
          
      }else if(video){
          vidplayer.Play();
          
      }


    }

   
    }
