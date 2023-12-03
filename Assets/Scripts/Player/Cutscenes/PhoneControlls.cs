using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using UnityEngine;

public class PhoneControlls : MonoBehaviour
{
    public TextMeshProUGUI thoughtDialogue;
    private float delay = 0.05f;
    private string fullText;
    private string currentText = "";
    public GameObject[] allButtons;
    private bool dialogueInUse;

    private bool enableSomethingAfterDialogue = false;
    private int buttonWithActionReady;
    private int latestBtnClicked;
    private int actionSelector = 0;
    private List<GameObject> enableObj, disableObj;

    public void Start()
    {
        enableObj = new List<GameObject>();
        disableObj = new List<GameObject>();
    }

    public void Update()
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
            if (enableSomethingAfterDialogue && (latestBtnClicked == buttonWithActionReady))
            {
                DoAction();
                enableSomethingAfterDialogue = false;
            }
            else
            {
                fullText = thought;
                dialogueInUse = true;
                StartCoroutine(ShowText());
            }
        }
    }

    public void DoAction()
    {
        //DisableObj and EnableObj
        if (actionSelector == 1)
        {
            //Debug.Log("Action");
            foreach (var obj in enableObj)
                obj.SetActive(true);
            foreach (var obj in disableObj)
                obj.SetActive(false);
            enableObj.Clear();
            disableObj.Clear();
        }
    }

    public void SelectEnableObj(GameObject enable)
    {
        enableObj.Add(enable);
    }
    public void SelectDisableObj(GameObject disable)
    {
        disableObj.Add(disable);
    }

    public void SelectWhatAction(int action)
    {
        actionSelector = action;
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

    public void EnableActionNextTimeBtnClicked(int thisButtonIndex)
    {
        if ((!dialogueInUse) || (latestBtnClicked == thisButtonIndex))
        {
            enableSomethingAfterDialogue = true;
            buttonWithActionReady = thisButtonIndex;
        }
    }

    public void ButtonInteractedWith(int thisButtonIndex)
    {
        if (!dialogueInUse)
        {
            latestBtnClicked = thisButtonIndex;
        }
    }




    public void DisabeOthButtons(int thisButtonIndex)
    {
        for (int i = 0; i < allButtons.Length; i++)
        { 
            if(i != thisButtonIndex)
            {
                allButtons[i].gameObject.SetActive(false);
            }
        }
    }

}
