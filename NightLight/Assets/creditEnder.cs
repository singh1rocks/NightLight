using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creditEnder : MonoBehaviour
{
    LevelLoader LL;
    // Start is called before the first frame update
    void Start()
    {
        LL = GameObject.Find("gameManager").GetComponent<LevelLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(TimeToGo());

    }

    private IEnumerator TimeToGo()
    {
        yield return new WaitForSeconds(7f);
        LL.CompleteLevel();
        LL.TransisitionScene();
    }
}
