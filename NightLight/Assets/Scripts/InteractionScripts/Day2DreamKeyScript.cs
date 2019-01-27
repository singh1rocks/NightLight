using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day2DreamKeyScript : MonoBehaviour, Iinteractable
{
    Dictionary<string, bool> PlayerInventory;
    //TextDisplay txtDisplay;
    VoiceController VC;

    void Start()
    {
        VC = GameObject.FindGameObjectWithTag("Player").GetComponent<VoiceController>();
        //txtDisplay = GameObject.FindGameObjectWithTag("TextDisplay").GetComponent<TextDisplay>();
        //PlayerInventory =  GameObject.FindGameObjectWithTag("GameManager").GetComponent<Inventory>().PlayerItems;
        PlayerInventory = GameObject.Find("gameManager").GetComponent<Inventory>().PlayerItems;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void doPlayerInteraction()
    {
        PlayerInventory["Day2DreamKey"] = true;
        //gameObject.GetComponent<AudioSource>().Play();
        VC.PlayVoice(VC.PickThingsClip);
        //txtDisplay.DisplayText("Another key. Cool...");
        VC.PlayVoice(VC.HandyKeyClip);
        gameObject.SetActive(false);
    }

}
