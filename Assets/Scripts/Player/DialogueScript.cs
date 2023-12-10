using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueScript : MonoBehaviour
{
    public TextMeshProUGUI thoughtDialogue;
    private float delay = 0.05f;
    public string fullText;
    private string currentText = "";
    public bool dialogueInUse;
    public bool sayOnActivate = false;
    public GameObject background;

    void Start()
    {
        if (!sayOnActivate)
        {
            thoughtDialogue = this.GetComponent<TextMeshProUGUI>();
        }
    }

    void OnEnable()
    {
        if(sayOnActivate)
        {
            ThinkSomething(fullText);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            fullText = "";
            currentText = "";
            thoughtDialogue.text = currentText;
            dialogueInUse = false;
        }
    }

    public void ThinkSomething(string thought)
    {
        if (!dialogueInUse)
        {
            fullText = thought;
            dialogueInUse = true;
            background.SetActive(true);
            StartCoroutine(ShowText());
        }
    }

    IEnumerator ShowText()
    {
        for (int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            thoughtDialogue.text = currentText;
            yield return new WaitForSeconds(delay);
        }
        yield return new WaitForSeconds(4f);
        currentText = "";
        thoughtDialogue.text = currentText;
        background.SetActive(false);
        dialogueInUse = false;
    }
}
