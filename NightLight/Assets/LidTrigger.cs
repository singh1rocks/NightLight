using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LidTrigger : MonoBehaviour
{
    public float speed;
    public GameObject lid;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            lid.GetComponent<Rigidbody>().AddForce(new Vector3(speed, speed * 2, speed - 3));
        }
    }
}
