using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    public float InteractDistance = 2.0f;
    private Freezer freeze;
    // Start is called before the first frame update
    void Start()
    {
        freeze = GameObject.Find("FPSController").GetComponent<Freezer>();
    }
    
    // Update is called once per frame
    void Update()
    {
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, transform.forward, InteractDistance);

        foreach (RaycastHit hit in hits)
        {
            Iinteractable[] doScripts = hit.transform.GetComponents<Iinteractable>();
            //check if it is interactible, and the player is interacting with it.
            if (doScripts != null && Input.GetKeyDown(KeyCode.F))
            {
                //if player is not frozen
                if (freeze != null && !freeze.isDead)
                    foreach (Iinteractable i in doScripts)
                    {
                        i.doPlayerInteraction();
                    }
            }
        }
    }
}
