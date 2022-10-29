using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lead : MonoBehaviour

//Trigger events to change colour of Ball to show student if thay have matched the right metal to metal name
{
GameObject item;   
   

       
       private void OnTriggerEnter(Collider other)           
       
       
        {
        //Find Materal object
           item = GameObject.Find("LeadSphere");
            //Check if Metal has correct tag
            if (other.gameObject.HasTag("Lead"))
           {
                Debug.Log("Test");
               item.GetComponent<Renderer>().material.color = Color.green; 
                //Turn on Toggle for Identify Sodium .
                item = GameObject.Find("Step4");
                item.GetComponent<Toggle>().isOn = true;
               

           }//Show current metal is incorrect 
           else if(!other.gameObject.HasTag("Lead"))
           {
            item.GetComponent<Renderer>().material.color = Color.red;
           }
           
          
           
       }
        
    

    //This will just change the Sphere to a netural colour while student tries differnt metals in the box
    public void OnTriggerExit(Collider other){
    item = GameObject.Find("LeadSphere");
    item.GetComponent<Renderer>().material.color = Color.gray;
    }
}
