using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DreamDoor : MonoBehaviour, Iinteractable
{
    VoiceController VC;

    public void doPlayerInteraction()
    {
        if(gameObject.GetComponent<DoorOpen>().isOpened)
            VC.PlayVoice(VC.WhereAmIClip);
    }

    // Start is called before the first frame update
    void Start()
    {
        VC = GameObject.FindGameObjectWithTag("Player").GetComponent<VoiceController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
