using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class FlameColour : MonoBehaviour
{
    ParticleSystem ps;
    GameObject item;
    void Start() {
    ps = GetComponent<ParticleSystem>();
    
    }
    private void OnCollisionEnter(Collision other)
     {
         //Turn on Toggle for trying to burn metal .
                item = GameObject.Find("Step1");
                item.GetComponent<Toggle>().isOn = true;
        if(other.gameObject.HasTag("Copper"))
        {
         ps.startColor =  Color.blue;   
        }
        else if(other.gameObject.HasTag("Sodium"))
        {
            ps.startColor  =  Color.yellow ;  
        }
        else if(other.gameObject.HasTag("Lead"))
        {
            ps.startColor  =  Color.red ;  
        }
        
    }
}

