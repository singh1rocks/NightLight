using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireplaceLit : MonoBehaviour, Iinteractable
{
    [SerializeField]
    GameObject FireParticle;
    Dictionary<string, bool> PlayerInventory;
    TextDisplay txtDisplay;
    AudioSource AS;
    void Start()
    {
        txtDisplay = GameObject.FindGameObjectWithTag("TextDisplay").GetComponent<TextDisplay>();
        //PlayerInventory =  GameObject.FindGameObjectWithTag("GameManager").GetComponent<Inventory>().PlayerItems;
        PlayerInventory = GameObject.Find("gameManager").GetComponent<Inventory>().PlayerItems;
        AS = gameObject.GetComponent<AudioSource>();
    }
    public void doPlayerInteraction()
    {
        if (PlayerInventory["Day1MatchBox"])
        {
            FireParticle.GetComponent<ParticleSystem>().Play();
            AS.Play();
            txtDisplay.DisplayText("Warmth, I think that's all I need right now...");
            LevelLoader ll = GameObject.Find("gameManager").GetComponent<LevelLoader>();
            ll.CompleteLevel();
        }
        else
            txtDisplay.DisplayText("I need something to light the fireplace...");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
