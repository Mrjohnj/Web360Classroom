using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Timers;
using UnityEngine.SceneManagement;

public class Events : MonoBehaviour
{
     ParticleSystem ps;
    AudioSource pop;
     
     GameObject item;
     bool soundReady;
   // Get timer of Video to pause Video at certin points
   
    float videotimer;
  //Three points at which to pause the video if action as not been carried out
   public const int stopVideoAt1= 40;
    public const int stopVideoAt2= 55;
    public const int stopVideoAt3= 89;
    public const int stopVideoAt4= 95;
         
   
    
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        soundReady = false;        
         
         item = GameObject.Find("PopCube");
         pop= item.GetComponent<AudioSource>();  
    }

    // Update is called once per frame
    void Update()
    {        
        //Run a timer for how long video has been playing-Only Run if video is running
        item = GameObject.Find("360VideoPlayer");
        if(item.GetComponent<VSteam360VideoPop>().video == true){
            videotimer += Time.deltaTime;
            Debug.Log(videotimer);
            
            switch( Mathf.Round(videotimer)){
                case stopVideoAt1://Pause if user hasnt carried out Step 2
                item = GameObject.Find("Step2");
                if(!item.GetComponent<Toggle>().isOn){
                    pauseMedia();}
                break;
                case stopVideoAt2://Pause if user hasnt carried out Step 3
                 item = GameObject.Find("Step3");
                if(!item.GetComponent<Toggle>().isOn){
                    pauseMedia();}
                break;
                case stopVideoAt3://Pause if user hasnt carried out Step 4
                 item = GameObject.Find("Step4");
                if(!item.GetComponent<Toggle>().isOn){
                    pauseMedia();}
                break;
                case stopVideoAt4://Return to home screen when video is over
                 SceneManager.LoadScene("IntroScene");
                break;
                
            }
        }    
    }





public void OnTriggerEnter(Collider other){
    
        switch(other.tag)
            {
                case "Interactable":
                if(other.gameObject.HasTag("Magnesium"))
                {
                //Play ParticleSystem on Beaker to Visualise Hydrogen being giving off.
                ps.Play();
                startMedia();             
                
                //Turn on Toggle for step 2.
                item = GameObject.Find("Step2");
                item.GetComponent<Toggle>().isOn = true;
                //Instead of Deleting the peice of Magnesium it is hidden as there was an
                //issue where Colider on the Hand would be deleted and be unable to interact with other objects.
                other.GetComponent<MeshRenderer>().enabled = false;

                //item- Activate Hydrogen Trigger CC in Beaker so it can
                //now trigger PopCube on TestTube when it is held over Beaker
                item = GameObject.Find("Hydrogen Trigger");
                item.GetComponent<CapsuleCollider>().enabled = true;

                //item- Activate PopCube CC on TestTube
                item = GameObject.Find("PopCube");
                item.GetComponent<BoxCollider>().enabled = true;
                }
                break;

                case "BeakerHydrogen":
                startMedia();
                                              
                //Activate Liquid Volume on TestTube and #
                item = GameObject.Find("TestTubeHydrogen");
                item.GetComponent<MeshRenderer>().enabled = true; 

                //Turn on Toggle for step .
                item = GameObject.Find("Step3");
                item.GetComponent<Toggle>().isOn = true;

                //Allow Pop sound to be played
                soundReady = true;
                //Make sure Auido is off to allow activation
                pop.enabled = false;
                break;
                
               

                case "BunsenFlame":
                ps.Play();
                break;

                case "TaperFlame":
                if(soundReady == true){
                    startMedia();
                    soundReady = false;
                    pop.enabled = true;

                    //Turn on Toggle for step 4.
                    item = GameObject.Find("Step4");
                    item.GetComponent<Toggle>().isOn = true;
                   
                    
                    //Disable Gas FX so show its been used
                    item = GameObject.Find("TestTubeHydrogen");
                    item.GetComponent<MeshRenderer>().enabled = false; 
                    startMedia();                                      

                }
                break;

            }
        }


void pauseMedia(){
            //Pause Video and Sound
            item = GameObject.Find("360VideoPlayer");
            item.GetComponent<VSteam360VideoPop>().video = false;
            item.GetComponent<AudioSource>().Pause();
                 }

void startMedia(){
            //Resume Video and Sound
            item = GameObject.Find("360VideoPlayer");
            item.GetComponent<VSteam360VideoPop>().video = true;
            item.GetComponent<AudioSource>().UnPause();           
            }
}



    


