using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day1KeyScript : MonoBehaviour, Iinteractable
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
        PlayerInventory["Day1Key"] = true;
        txtDisplay.DisplayText("A key. Cool...");
        gameObject.GetComponent<AudioSource>().Play();
        gameObject.SetActive(false);
    }

}
