using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunMoonSystem : MonoBehaviour
{
    GameObject gameManager;
    DayNightClock clock;
    void Start()
    {
        gameManager = GameObject.Find("gameManager");
        clock = gameManager.GetComponent<DayNightClock>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v = new Vector3(clock.timeOfDay * (360/100), 0, 0);
        Quaternion q = Quaternion.Euler(v);
        gameObject.transform.rotation = q;
    }
}
