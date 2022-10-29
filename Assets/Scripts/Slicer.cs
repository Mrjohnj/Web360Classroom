using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EzySlice;
public class Slicer : MonoBehaviour
{
    public Material MaterialAfterSlice;
    public LayerMask sliceMask;
    //GameObject objectsToBeSliced;

    public bool isTouched;
    GameObject lowerHullGameobject;
    GameObject upperHullGameobject;

    
    

     private void Update()
    {     
        if (isTouched == true)
        {        
            isTouched = false;
            Collider[] objectsToBeSliced = Physics.OverlapBox(transform.position, new Vector3(1, 0.1f, 0.1f),
             transform.rotation, sliceMask);
                       
            foreach (Collider objectToBeSliced in objectsToBeSliced)
            {
                 //Select object to be cut and materal that will show on new sliced ends        
                SlicedHull slicedObject = SliceObject(objectToBeSliced.gameObject, MaterialAfterSlice);

                //Create two new objects, one on either side of cutting Plane
                upperHullGameobject = slicedObject.CreateUpperHull(objectToBeSliced.gameObject, MaterialAfterSlice);
                lowerHullGameobject = slicedObject.CreateLowerHull(objectToBeSliced.gameObject, MaterialAfterSlice);
                
                //Place uppand and Lower hull in position of original object
                upperHullGameobject.transform.position = objectToBeSliced.transform.position;
                lowerHullGameobject.transform.position = objectToBeSliced.transform.position;
               
               //Give the two new objects same Attibutes as original
                MakeItPhysical(upperHullGameobject);
                MakeItPhysical(lowerHullGameobject);

               //Delete original object
               Destroy(objectToBeSliced.gameObject);
            }
           
        
        }

    }
    private void MakeItPhysical(GameObject obj)
    {
        obj.AddComponent<MeshCollider>().convex = true;
        obj.AddComponent<Rigidbody>();    
        obj.gameObject.tag = "Interactable";
        obj.AddComponent<MultiTags>();
        obj.AddTag("Magnesium");
        obj.gameObject.layer = LayerMask.NameToLayer("Sliceable");
    }
    private SlicedHull SliceObject(GameObject obj, Material crossSectionMaterial = null)
    {
        // slice the provided object using the transforms of this object
        return obj.Slice(transform.position, transform.up, crossSectionMaterial);
    }

}
