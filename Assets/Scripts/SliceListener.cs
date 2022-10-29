using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Timers;

public class SliceListener : MonoBehaviour
{
    GameObject item;
    float timer = 2;
    Toggle m_Toggle;
    public Slicer slicer;
     void Update() {
       
            timer -= Time.deltaTime;
    }

     

    private void OnTriggerEnter(Collider other)
    {
       if(timer<0){
           timer =0.5f;
           slicer.isTouched = true;      
        if(other.gameObject.HasTag("Magnesium"))
                {//Tict Step 1 Box
            item = GameObject.Find("Step1");
            item.GetComponent<Toggle>().isOn = true; 
                }       
    } 
    }    
}
