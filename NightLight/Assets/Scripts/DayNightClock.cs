using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightClock : MonoBehaviour
{
    /// <summary>
    /// Represents the time since the scene was loaded (dawn).
    /// 0 is dawn and 100 is the end of the night. 
    /// The transistion from day to night is determined by the dayNightRatio.
    /// </summary>
    public int timeOfDay = 0;
    public bool isDay = true;
    //The ratio of day/night. The same as "percent of time is day time"
    public float dayNightRatio = .5f;
    public float secondsPerCycle = 360f;
    void Awake()
    {
        //Don't destroy when loading a new Scene
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeOfDay = (int)(Time.timeSinceLevelLoad * (100f / secondsPerCycle) % 100);

        if (timeOfDay <= dayNightRatio * 100)
        {
            isDay = true;
        }
        else
        {
            isDay = false;
        }
    }
    /// <summary>
    /// Returns seconds until dusk or zero if it is night time
    /// </summary>
    /// <returns></returns>
    public float GetSecondsTillDusk()
    {
        if (isDay)
        {
            return ((dayNightRatio * 100f) - (float)timeOfDay) * (secondsPerCycle / 100f);
        }
        else
        {
            return 0;
        }
    }
    /// <summary>
    /// Returns seconds until dawn or zero if it is day time
    /// </summary>
    /// <returns></returns>
    public float GetSecondsTillDawn()
    {
        if (!isDay)
        {
            return (100 - timeOfDay) * (secondsPerCycle / 100);
        }
        else
        {
            return 0;
        }
    }
    //does not work. if needed, will fix.
    //public void SetToNight()
    //{
    //    timeOfDay = (int) dayNightRatio * 100;
    //}
}
