using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedSleepScript : MonoBehaviour, Iinteractable
{
    Dictionary<string, bool> PlayerInventory;
    TextDisplay txtDisplay;
    public GameObject sleeperCam;
    public Camera mainCamera;
    private Camera layCam;
    LevelLoader ll;

    void Start()
    {
        txtDisplay = GameObject.FindGameObjectWithTag("TextDisplay").GetComponent<TextDisplay>();
        //PlayerInventory =  GameObject.FindGameObjectWithTag("GameManager").GetComponent<Inventory>().PlayerItems;
        PlayerInventory = GameObject.Find("gameManager").GetComponent<Inventory>().PlayerItems;
        ll = GameObject.Find("gameManager").GetComponent<LevelLoader>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void doPlayerInteraction()
    {
        
        //spawn the laying down object
        if (sleeperCam != null)
        {
            var newCamera = Instantiate(sleeperCam);
            newCamera.transform.position = new Vector3(gameObject.transform.position.x-1.7f, gameObject.transform.position.y + 1.5f, gameObject.transform.position.z);
            //translate it if necessary
            layCam = newCamera.GetComponentInChildren<Camera>();
        }
        //switch camera
        mainCamera.enabled = false;
        layCam.enabled = true;

        //wait for it to finish
        StartCoroutine(GoToSleep());
        
    }
    public IEnumerator GoToSleep()
    {
        yield return new WaitForSeconds(5);
        ll.TransisitionScene();
    }
}
