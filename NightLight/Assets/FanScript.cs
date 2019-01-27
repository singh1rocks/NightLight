using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanScript : MonoBehaviour
{
    public float speed = 0;
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(new Vector3(0, speed, 0));
    }
}
