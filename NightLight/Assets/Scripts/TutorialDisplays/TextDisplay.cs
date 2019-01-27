using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    string TextToPut;
    float TimeToDisplay = 2.0f;
    [SerializeField]
    Text Words;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void DisplayText(string textToPut, float duration = 2.0f)
    {
        //Debug.Log(textToPut);
        //StopCoroutine(AnimateText(textToPut, duration));
        
        StartCoroutine(AnimateText(textToPut, duration));
        ShowEverything();
    }
    IEnumerator AnimateText(string textToPut, float duration)
    {
        string currentText = "";
        TextToPut = textToPut;
        int i = 0;

        while(i < textToPut.Length)
        {
            currentText += textToPut[i++];
            Words.text = currentText;
            //Debug.Log(i);
            yield return new WaitForSeconds(duration / textToPut.Length);
        }
        HideEverything();
    }
    void ShowEverything()
    {
        Color OpaqueColor = this.gameObject.GetComponent<Image>().color;
        this.gameObject.GetComponent<Image>().color = new Color(OpaqueColor.r, OpaqueColor.g, OpaqueColor.b, 80.0f / 255.0f);
        foreach(Text t in GetComponentsInChildren<Text>())
        {
            Color TextOpaqueColor = t.color;
            t.color = new Color(TextOpaqueColor.r, TextOpaqueColor.g, TextOpaqueColor.b, 1.0f);
        }
    }

    void HideEverything()
    {
        Color OpaqueColor = this.gameObject.GetComponent<Image>().color;
        this.gameObject.GetComponent<Image>().color = new Color(OpaqueColor.r, OpaqueColor.g, OpaqueColor.b, 0.0f);
        foreach (Text t in GetComponentsInChildren<Text>())
        {
            Color TextOpaqueColor = t.color;
            t.color = new Color(TextOpaqueColor.r, TextOpaqueColor.g, TextOpaqueColor.b, 0.0f);
        }
    }
}
