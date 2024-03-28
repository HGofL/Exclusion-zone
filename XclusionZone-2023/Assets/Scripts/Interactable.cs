using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Interactable : MonoBehaviour
{
    //public UnityEvent onInteract;
    
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Not Here");

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Not Here Update");

    }

    public void OnInteract()
    {
        Debug.Log("3.");
    }

    public void OnTriggerEnter(Collider other)
    {
        
    }

    public void OnTriggerExit(Collider other)
    {
        

    }
}
