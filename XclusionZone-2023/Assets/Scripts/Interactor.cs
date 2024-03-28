using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactor : MonoBehaviour
{
    private float Ray_Length = 10f;
    
    public LayerMask interactableLayerMask = 8;
    //UnityEvent onInteract;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if(Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward, out hit, Ray_Length, interactableLayerMask))
        {
            if(hit.collider.GetComponent<Interactable>() != false)
            {
                Debug.Log("1.");
                //onInteract = hit.collider.GetComponent<Interactable>().onInteract;
                if(Input.GetKeyDown(KeyCode.X))
                {
                    //onInteract.Invoke();
                    Debug.Log("2.");
                    hit.collider.GetComponent<Interactable>().OnInteract();
                    

                }
            }
        }
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * Ray_Length, Color.green, 0.01f);
    }
}
