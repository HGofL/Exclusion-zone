using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactor : MonoBehaviour
{
    //public LayerMask interactableLayerMask = 8;
    //UnityEvent onInteract;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*RaycastHit hit;

        if(Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward, out hit, 2, interactableLayerMask))
        {
            if(hit.collider.GetComponent<Interactable>() ! = false)
            {
                onInteract = hit.collider.GetComponent<Interactable>().onInteract;
                if(Input.GetKeyDown(keyCode.E))
                {
                    onInteract.Invoke();
                }
            }
        }*/
    }
}
