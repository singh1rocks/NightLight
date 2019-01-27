using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorScript : MonoBehaviour, Iinteractable
{
    [SerializeField]
    GameObject Lever;
    [SerializeField]
    float AngleToTurn = 150.0f;
    bool isUsed = false;
    LevelLoader LL;
    GameObject lights;
    public void doPlayerInteraction()
    {
        if(!isUsed)
        {
            StartCoroutine(StartRotateTheLever());
            isUsed = true;
            LL.CompleteLevel();
            //turn on lights.
            lights.SetActive(true);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        LL = GameObject.Find("gameManager").GetComponent<LevelLoader>();
        lights = GameObject.Find("LightsToTurnOn");
    }

    IEnumerator StartRotateTheLever()
    {
        for (float alpha = 0.0f; alpha <= AngleToTurn; alpha += 5.0f)
        {
            Lever.transform.Rotate(new Vector3(0.0f, 0.0f, -5.0f));
            yield return new WaitForSeconds(0.05f);
        }

    }
}
