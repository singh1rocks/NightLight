﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Freezer : MonoBehaviour
{
    public float coldAmount = 20f;
    public bool isDead;
    public float dayCold = .01f;
    public float nightCold = .05f;
    public float warmAmount = .01f;
    public bool deathOn = true;
    public float frostInterval = 2;

    private bool inRoom;
    private Camera mainCamera;
    private FrostEffect frost;
    private DayNightClock clock;
    private float lastTime;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        frost = mainCamera.GetComponent<FrostEffect>();
        frost.FrostAmount = 0;
        clock = GameObject.Find("gameManager").GetComponent<DayNightClock>();
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
                if (clock.isDay && frost.FrostAmount > 0)
                {

                    coldAmount += 10 * warmAmount;
                    frost.FrostAmount -= warmAmount;
                    if (frost.FrostAmount < 0)
                        frost.FrostAmount = 0;

                }
            }
            else
            {
                {
                    if (!clock.isDay)
                    {
                        coldAmount -= 10 * nightCold;
                        if (frost.FrostAmount < .4f)
                            frost.FrostAmount += nightCold;
                    }
                    else
                    {
                        coldAmount -= 10 * dayCold;
                        if (frost.FrostAmount < .4f)
                            frost.FrostAmount += dayCold;
                    }
                }
            }
        }
        if (coldAmount <= 0)
        {
            if (deathOn)
            {
                UnityEngine.SceneManagement.Scene currentScene = SceneManager.GetActiveScene();
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
