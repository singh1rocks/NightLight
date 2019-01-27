using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnder : MonoBehaviour, Iinteractable
{


    Dictionary<string, bool> PlayerInventory;
    public void doPlayerInteraction()
    {
        if (PlayerInventory["Dream0Key"])
        {
            LevelLoader ll = GameObject.Find("gameManager").GetComponent<LevelLoader>();
            ll.CompleteLevel();
            ll.TransisitionScene();
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerInventory = GameObject.Find("gameManager").GetComponent<Inventory>().PlayerItems;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
