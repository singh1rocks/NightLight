using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Dictionary<string, bool> PlayerItems;
    // Start is called before the first frame update
    private void Awake()
    {
        PlayerItems = new Dictionary<string, bool>();
    }
    void Start()
    {
        PlayerItems.Add("Day1Key", false);
        PlayerItems.Add("Day2DreamKey", false);
        PlayerItems.Add("Day1MatchBox", false);
        PlayerItems.Add("KitchenDoorOpened", false);
        PlayerItems.Add("Dream0Key", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
