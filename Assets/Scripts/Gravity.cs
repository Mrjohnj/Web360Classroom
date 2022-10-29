using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
     public Rigidbody rb;
    // Start is called before the first frame update
    void Start() {
         rb = GetComponent<Rigidbody>();
     }
   
    public void OnTriggerEnter(Collider other){
    if(other.tag == "Hand" )
    {
        rb.useGravity = true;   
    }
    }
}
