using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandeler : MonoBehaviour
{
   //OnClick Scene Loader 
    public void LoadScene(string sceneName) 
    {
       SceneManager.LoadScene(sceneName);        
    }
}
