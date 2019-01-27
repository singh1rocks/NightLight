using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day1KeyScript : MonoBehaviour, Iinteractable
{
    Dictionary<string, bool> PlayerInventory;
    //TextDisplay txtDisplay;
    VoiceController VC;
    void Start()
    {
        //txtDisplay = GameObject.FindGameObjectWithTag("TextDisplay").GetComponent<TextDisplay>();
        VC = GameObject.FindGameObjectWithTag("Player").GetComponent<VoiceController>();
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
        //txtDisplay.DisplayText("A key. Cool...");
        VC.PlayVoice(VC.PickThingsClip);
        VC.PlayVoice(VC.HandyKeyClip);
        //gameObject.GetComponent<AudioSource>().Play();
        gameObject.SetActive(false);
    }

}
