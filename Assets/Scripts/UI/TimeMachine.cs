using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeMachine : MonoBehaviour
{
    public TextMeshProUGUI machineText;
    private float delay = 0.05f;
    public string fullText;
    private string currentText = "";
    private bool dialogueInUse;
    private bool inRange;
    public string[] options;
    public GameObject[] timePeriods;
    private int selected;
    public Image transitionScreen;

    void Start()
    {
        selected = 1;
        SaySomething(options[selected]);
    }

    void Update()
    {
        /*if (Input.GetKeyDown("space"))
        {
            fullText = "";
            currentText = "";
            machineText.text = currentText;
            dialogueInUse = false;
        }*/

        if (inRange)
        {
            if (Input.GetKeyDown("space"))
            {
                Debug.Log("space");
                for (int i = 0; i < options.Length; i++)
                {
                    StartCoroutine(Transition());
                    if (i == selected)
                    {
                        timePeriods[i].SetActive(true);
                    }
                    else
                    {
                        timePeriods[i].SetActive(false);
                    }
                }
            }
            if (Input.GetKeyDown("right"))
            {
                selected++;
                if (selected >= options.Length)
                {
                    selected = 0;
                }
                SaySomething(options[selected]);
            }
            if (Input.GetKeyDown("left"))
            {
                selected--;
                if (selected < 0)
                {
                    selected = options.Length - 1;
                }
                SaySomething(options[selected]);
            }
        }
    }

    public void SaySomething(string thought)
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
            machineText.text = currentText;
            yield return new WaitForSeconds(delay);
        }
        //yield return new WaitForSeconds(1.3f);
        //currentText = "";
        currentText = fullText;
        machineText.text = currentText;
        dialogueInUse = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Player"))
        {
            inRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == ("Player"))
        {
            inRange = false;
        }
    }

    IEnumerator Transition(bool fade = true, int fadeSpeed = 1)
    {
        Color color = transitionScreen.color;
        float fadeAmount;
        if (fade)
        {
            while (transitionScreen.color.a < 1)
            {
                fadeAmount = color.a + (fadeSpeed * Time.deltaTime);
                color = new Color(color.r, color.g, color.b, fadeAmount);
                transitionScreen.color = color;    
            }
            StartCoroutine(Transition(false));
            yield return null;
        }
        else
        {
            while(transitionScreen.color.a > 0)
            {
                fadeAmount = color.a - (fadeSpeed * Time.deltaTime);
                color = new Color(color.r, color.g, color.b, fadeAmount);
                transitionScreen.color = color;
                yield return null;
            }
        }
    }
}