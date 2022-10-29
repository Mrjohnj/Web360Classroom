using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationReset : MonoBehaviour

{
   GameObject item;
    //public Rigidbody clone;
    public GameObject original;
   //public Transform originalPos;
    Vector3 originalPos;
    

    
     void Start()
    {
        //Get Original Position of GameObject
        originalPos = gameObject.transform.position;
    }
    
    public void OnTriggerEnter(Collider other){
            //If the GameObject falls off the table
            // or Floats away and collides with Wall
            // it will return to the Original Position
        if(other.gameObject.tag == "Wall"){
            original.transform.position=originalPos;
        }

    }
}
