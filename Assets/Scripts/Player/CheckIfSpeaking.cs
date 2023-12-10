using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckIfSpeaking : MonoBehaviour
{
    public DialogueScript dialogueScript;
    public Image transitionScreen;
    public GameObject playerController, playerBody;
    private bool gotEnabled = false;
    public GameObject exitBtn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gotEnabled)
        {
            if (!dialogueScript.dialogueInUse)
            {
                playerController.GetComponent<PlayerMovement>().moveSpeed = 0;
                playerController.GetComponent<PlayerMovement>().runningSpeed = 0;
                playerBody.GetComponent<Animator>().enabled = false;
                StartCoroutine(FadeToScreen(true, 0.4f));
            }
        }
    }

    void OnEnable()
    {
        gotEnabled = true;
    }

    IEnumerator FadeToScreen(bool fade, float fadeSpeed)
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
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            exitBtn.SetActive(true);
        }
    }
}
