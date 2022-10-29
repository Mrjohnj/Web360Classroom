using System.Collections;
using System.Collections.Generic;
using UnityEngine;


 

public class TestTubeHolder : MonoBehaviour
{
    GameObject item;
    void Start()
    {
        
                    
    }

    // Update is called once per frame
    void Update()
    {
        

    }





public void OnTriggerEnter(Collider other){
    

        switch(other.tag)
            {
                case "Holder":
                item = GameObject.Find("TestTube");
                item.GetComponent<Rigidbody>().useGravity = false;
                //Turn on Gravity Plane
                 item = GameObject.Find("Gravity");
                item.GetComponent<MeshCollider>().enabled = true;
                //Turn off Hold plane
                item = GameObject.Find("Hold");
                item.GetComponent<MeshCollider>().enabled = false;

                break;

                case "Gravity":
                item = GameObject.Find("TestTube");
                item.GetComponent<Rigidbody>().useGravity = true;
                //Turn on Hold Plane
                item = GameObject.Find("Hold");
                item.GetComponent<MeshCollider>().enabled = true;
                // Turn off Gravity Plane
                item = GameObject.Find("Gravity");
                item.GetComponent<MeshCollider>().enabled = false;

                break;

                
            }
        }







}
