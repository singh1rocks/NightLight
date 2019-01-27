using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dream0KeyScript : MonoBehaviour, Iinteractable
{
    Dictionary<string, bool> PlayerInventory;
    TextDisplay txtDisplay;

    void Start()
    {
        txtDisplay = GameObject.FindGameObjectWithTag("TextDisplay").GetComponent<TextDisplay>();
        //PlayerInventory =  GameObject.FindGameObjectWithTag("GameManager").GetComponent<Inventory>().PlayerItems;
        PlayerInventory = GameObject.Find("gameManager").GetComponent<Inventory>().PlayerItems;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void doPlayerInteraction()
    {
        PlayerInventory["Dream0Key"] = true;
        txtDisplay.DisplayText("Another key. Cool...");
        gameObject.SetActive(false);
    }

}
