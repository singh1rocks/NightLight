using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Dictionary<string, bool> PlayerItems;
    // Start is called before the first frame update
    void Start()
    {
        PlayerItems = new Dictionary<string, bool>();
        PlayerItems.Add("Day1Key", false);
        PlayerItems.Add("Day1MatchBox", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
