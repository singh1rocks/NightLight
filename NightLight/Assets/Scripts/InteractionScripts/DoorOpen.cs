﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour, Iinteractable
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject ActualDoor;
    Dictionary<string, bool> PlayerInventory;
    TextDisplay txtDisplay;
    void Start()
    {
        txtDisplay = GameObject.FindGameObjectWithTag("TextDisplay").GetComponent<TextDisplay>();
        //PlayerInventory =  GameObject.FindGameObjectWithTag("GameManager").GetComponent<Inventory>().PlayerItems;
        PlayerInventory = GameObject.Find("gameManager").GetComponent<Inventory>().PlayerItems;
        //StartCoroutine(DoorOpenDuringTime());

    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void doPlayerInteraction()
    {
        if(PlayerInventory["Day1Key"])
        {
            StartCoroutine(DoorOpenDuringTime());
        }
        else
        {
            //Debug.Log("asd");
            txtDisplay.DisplayText("I need a key to open this door.");
        }
    }

    IEnumerator DoorOpenDuringTime()
    {
        for (float angle = 0.0f; angle < 120.0f; angle += 5.0f)
        {
            ActualDoor.transform.Rotate(new Vector3(0.0f, 5.0f, 0.0f));
            yield return new WaitForSeconds(0.05f);
        }
    }
    IEnumerator DoorCloseDuringTime()
    {
        for (float angle = 0.0f; angle < 120.0f; angle += 5.0f)
        {
            ActualDoor.transform.Rotate(new Vector3(0.0f, -5.0f, 0.0f));
            yield return new WaitForSeconds(0.05f);
        }
    }
}