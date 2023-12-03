using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueScript : MonoBehaviour
{
    public TextMeshProUGUI thoughtDialogue;
    private float delay = 0.05f;
    public string fullText;
    private string currentText = "";
    private bool dialogueInUse;

    void Start()
    {
        thoughtDialogue = this.GetComponent<TextMeshProUGUI>();
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
        yield return new WaitForSeconds(1.3f);
        currentText = "";
        thoughtDialogue.text = currentText;
        dialogueInUse = false;
    }
}
