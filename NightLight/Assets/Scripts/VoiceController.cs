using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceController : MonoBehaviour
{
    //Hard code every voice
    public AudioClip FireplaceClip;
    public AudioClip FreezingClip;
    public AudioClip GotobedClip;
    public AudioClip HandyKeyClip;
    public AudioClip ItWorkedClip;
    public AudioClip NeedAKeyClip;
    public AudioClip QuiteRightClip;
    public AudioClip SaveFromColdClip;
    public AudioClip WhereAmIClip;
    public AudioClip WonderWhoClip;
    public AudioClip PickThingsClip;

    AudioSource AS;

    // Start is called before the first frame update
    void Start()
    {
        AS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayVoice(AudioClip ac)
    {
        AS.PlayOneShot(ac);
    }
}
