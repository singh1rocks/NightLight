using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Freezer : MonoBehaviour
{
    public static float coldAmount { get; private set; }
    public bool isDead { get; private set; }
    public float dayCold = .1f;
    public float nightCold = .5f;
    public float warmAmount = .1f;
    public bool deathOn = true;
    public float frostInterval = 5;

    private bool inRoom;
    private Camera mainCamera;
    private FrostEffect frost;
    private DayNightClock clock;
    private float lastTime;

    // Start is called before the first frame update
    void Start()
    {
        coldAmount = 100;
        mainCamera = Camera.main;
        frost = mainCamera.GetComponent<FrostEffect>();
        frost.FrostAmount = 0;
        clock = GameObject.Find("Clock").GetComponent<DayNightClock>();
        lastTime = clock.timeOfDay;
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: write so that it changes depending on the passage of time
        if (clock.timeOfDay >= lastTime + frostInterval)
        {
            lastTime = clock.timeOfDay;
            if (inRoom)
            {
                if (clock.isDay)
                {

                    coldAmount += warmAmount;
                    frost.FrostAmount -= warmAmount;

                }
            }
            else
            {
                if (!clock.isDay)
                {
                    coldAmount -= nightCold;
                    frost.FrostAmount += nightCold;
                }
                else
                {
                    coldAmount -= dayCold;
                    frost.FrostAmount += dayCold;
                }
            }
        }
        if (coldAmount <= 0)
        {
            if (deathOn)
            {
                Scene currentScene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(currentScene.name);
            }
            else
            {
                isDead = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "RoomFloor")
            inRoom = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "RoomFloor")
            inRoom = false;
    }
}
