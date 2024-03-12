using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeMachine : MonoBehaviour
{
    public TextMeshProUGUI machineText;
    public Image transitionScreen;
    public GameObject interactIcon;
    public AudioClip teleportAudioClip;
    private AudioSource audioSource;
    private float delay = 0.05f;
    public string fullText;
    private string currentText = "";
    private bool dialogueInUse;
    private bool inRange;
    public string[] options;
    public GameObject[] timePeriods;
    private int selected;
    
    void Start()
    {
        selected = 1;
        SaySomething(options[selected]);
        interactIcon.SetActive(false);
        audioSource = GetComponent<AudioSource>();
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
            interactIcon.SetActive(true);
            if (Input.GetKeyDown("space"))
            {
                audioSource.PlayOneShot(teleportAudioClip);
                StartCoroutine(Transition(true, 2f));
                /*for (int i = 0; i < options.Length; i++)
                {
                    if (i == selected)
                    {
                        timePeriods[i].SetActive(true);
                    }
                    else
                    {
                        timePeriods[i].SetActive(false);
                    }
                }*/
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
        else
        {
            interactIcon.SetActive(false);
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

    IEnumerator Transition(bool fade, float fadeSpeed)
    {
        Color color = transitionScreen.color;
        float fadeAmount;
        if (fade)
        {
            while (transitionScreen.color.a < 1)
            {
                fadeAmount = transitionScreen.color.a + (fadeSpeed * Time.deltaTime);
                color = new Color(color.r, color.g, color.b, fadeAmount);
                transitionScreen.color = color;
                yield return null;
            } 
            for (int i = 0; i < options.Length; i++)
            {
                if (i == selected)
                {
                    timePeriods[i].SetActive(true);
                }
                else
                {
                    timePeriods[i].SetActive(false);
                }
            }
            StartCoroutine(Transition(false, 0.5f));
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