using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayRestartBurn : MonoBehaviour
{
       public GameObject item;
    public void OnTriggerEnter(Collider other){   

        switch(other.tag)
            {
                case "Start":
                //Find and Enable Video and Audio
                item = GameObject.Find("360VideoPlayer");
                item.GetComponent<VSteam360VideoBurn>().enabled = true;
                item.GetComponent<AudioSource>().enabled = true;
                item.GetComponent<VSteam360VideoBurn>().video = true;
                
                //Remove Play button from View
                item = GameObject.Find("PlayScene");
                item.SetActive(false);
                          
                break;

                case "Restart":
                //Get Current Scene and reload it
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);
                break;
            }
    }
}


