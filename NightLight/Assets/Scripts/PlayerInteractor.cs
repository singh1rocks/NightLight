using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    public float InteractDistance = 2.0f;
    //private Freezer freeze;
    // Start is called before the first frame update
    void Start()
    {
        //freeze = GameObject.Find("freezer").GetComponent<Freezer>();
    }
    
    // Update is called once per frame
    void Update()
    {
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, transform.forward, InteractDistance);

        foreach (RaycastHit hit in hits)
        {
            Iinteractable doScript = hit.transform.GetComponent<Iinteractable>();
            //check if it is interactible, and the player is interacting with it.
            if (doScript != null && Input.GetKeyDown(KeyCode.F))
            {
                //if player is not frozen
                doScript.doPlayerInteraction();
            }
        }
    }
}
