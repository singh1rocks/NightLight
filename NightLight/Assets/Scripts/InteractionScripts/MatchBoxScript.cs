using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchBoxScript : MonoBehaviour, Iinteractable
{
    Dictionary<string, bool> PlayerInventory;
    VoiceController VC;
    //TextDisplay txtDisplay;

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
        gameObject.GetComponent<AudioSource>().Play();
        PlayerInventory["Day1MatchBox"] = true;
        VC.PlayVoice(VC.WonderWhoClip);
        //txtDisplay.DisplayText("A Match box. Cool, maybe I can light the fireplace now...");
        gameObject.SetActive(false);
    }
}
