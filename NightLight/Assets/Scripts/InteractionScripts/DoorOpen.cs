using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour, Iinteractable
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject ActualDoor;
    Dictionary<string, bool> PlayerInventory;
    VoiceController VC;
    AudioSource AS;
    public bool DoorCanOpen;
    public bool isOpened;
    private static bool hasSaidThing;
    void Start()
    {
        VC = GameObject.FindGameObjectWithTag("Player").GetComponent<VoiceController>();
        //PlayerInventory =  GameObject.FindGameObjectWithTag("GameManager").GetComponent<Inventory>().PlayerItems;
        PlayerInventory = GameObject.Find("gameManager").GetComponent<Inventory>().PlayerItems;
        //StartCoroutine(DoorOpenDuringTime());
        AS = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }



    public void doPlayerInteraction()
    {
        

        if (DoorCanOpen == true)
        {
            AS.Play();
            StartCoroutine(DoorOpenDuringTime());
            isOpened = true;
            if (!hasSaidThing)
            {
                VC.PlayVoice(VC.FreezingClip);
                hasSaidThing = true;
            }
        }
        else if (PlayerInventory["Day1Key"])
        {
            AS.Play();
            if (!hasSaidThing)
            {
                VC.PlayVoice(VC.FreezingClip);
                hasSaidThing = true;
            }
            if (!isOpened)
            {
                StartCoroutine(DoorOpenDuringTime());
            }
            else
                StartCoroutine(DoorCloseDuringTime());
        }
        else if (PlayerInventory["Day2Key"])
        {
            AS.Play();
            if (!hasSaidThing)
            {
                VC.PlayVoice(VC.FreezingClip);
                hasSaidThing = true;
            }
            if (!isOpened)
            {
                StartCoroutine(DoorOpenDuringTime());

            }
            else
                StartCoroutine(DoorCloseDuringTime());
        }
        else if (PlayerInventory["Day2DreamKey"])
        {
            AS.Play();
            if (!hasSaidThing)
            {
                VC.PlayVoice(VC.FreezingClip);
                hasSaidThing = true;
            }
            if (!isOpened)
            {
                VC.PlayVoice(VC.FreezingClip);
                StartCoroutine(DoorOpenDuringTime());
            }
            else
                StartCoroutine(DoorCloseDuringTime());
        }
        else
        {
            //Debug.Log("asd");
            //txtDisplay.DisplayText("I need a key to open this door.");
            VC.PlayVoice(VC.NeedAKeyClip);
        }
    }

    IEnumerator DoorOpenDuringTime()
    {
        isOpened = true;
        for (float angle = 0.0f; angle < 120.0f; angle += 5.0f)
        {
            ActualDoor.transform.Rotate(new Vector3(0.0f, 5.0f, 0.0f));
            yield return new WaitForSeconds(0.05f);
        }
        
    }
    IEnumerator DoorCloseDuringTime()
    {
        isOpened = false;

        for (float angle = 0.0f; angle < 120.0f; angle += 5.0f)
        {
            ActualDoor.transform.Rotate(new Vector3(0.0f, -5.0f, 0.0f));
            yield return new WaitForSeconds(0.05f);
        }
    }
}
