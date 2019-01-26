using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IconDisplay : MonoBehaviour
{
    //Call ShowIconText() to display text;
    // Start is called before the first frame update
    TextMeshPro MyTextMesh;
    void Start()
    {
        MyTextMesh = gameObject.GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ShowIconText(string TextToShow)
    {
        MyTextMesh.text = TextToShow;
        ShowEverything();
    }

    public void StopShowText()
    {
        HideEverything();
    }
    void ShowEverything()
    {
        Color OriginalColor = MyTextMesh.color;
        MyTextMesh.color = new Color(OriginalColor.r, OriginalColor.g, OriginalColor.b, 1.0f);
    }

    void HideEverything()
    {
        Color OriginalColor = MyTextMesh.color;
        MyTextMesh.color = new Color(OriginalColor.r, OriginalColor.g, OriginalColor.b, 0.0f);
    }
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("asdf");
        if (other.gameObject.CompareTag("Player"))
        {
            ShowIconText("asdf");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StopShowText();
        }
    }
}
