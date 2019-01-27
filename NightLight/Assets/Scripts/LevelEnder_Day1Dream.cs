using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnder_Day1Dream : MonoBehaviour
{


    Dictionary<string, bool> PlayerInventory;

    public void OnTriggerStay(Collider other)
    {
        LevelLoader l2 = GameObject.Find("gameManager").GetComponent<LevelLoader>();
        l2.CompleteLevel();
        l2.TransisitionScene();
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
