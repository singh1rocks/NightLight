using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowSplat : MonoBehaviour
{
    public GameObject snow;
    // Start is called before the first frame update
    public void Start()
    {
        snow.GetComponent<ParticleSystem>().Stop();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            snow.GetComponent<ParticleSystem>().Play();
        }
    }
}
