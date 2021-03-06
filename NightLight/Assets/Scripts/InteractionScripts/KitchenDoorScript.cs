﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenDoorScript : MonoBehaviour, Iinteractable
{
    [SerializeField]
    GameObject ActualDoor;
    Dictionary<string, bool> PlayerInventory;
    TextDisplay txtDisplay;
    public GameObject CombBox;
    bool isOpened = false;
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
        if (PlayerInventory["KitchenDoorOpened"])
        {
            if (!isOpened)
                StartCoroutine(DoorOpenDuringTime());
            else
                StartCoroutine(DoorCloseDuringTime());
        }
        else
        {
            //Debug.Log("asd");
            //txtDisplay.DisplayText("I need a key to open this door.");
            CombBox.SetActive(true);
        }
    }

    IEnumerator DoorOpenDuringTime()
    {
        for (float angle = 0.0f; angle < 120.0f; angle += 5.0f)
        {
            ActualDoor.transform.Rotate(new Vector3(0.0f, 5.0f, 0.0f));
            yield return new WaitForSeconds(0.05f);
        }
        isOpened = true;
    }
    IEnumerator DoorCloseDuringTime()
    {
        for (float angle = 0.0f; angle < 120.0f; angle += 5.0f)
        {
            ActualDoor.transform.Rotate(new Vector3(0.0f, -5.0f, 0.0f));
            yield return new WaitForSeconds(0.05f);
        }
        isOpened = false;
    }
    public void OpenCombDoor()
    {
        gameObject.GetComponent<AudioSource>().Play();
        StartCoroutine(DoorOpenDuringTime());
        PlayerInventory["KitchenDoorOpened"] = true;
    }
}
