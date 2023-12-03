using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AIScript : MonoBehaviour
{
    public GameObject interact, topBar, bottomBar, map, playerController, gameOverScreen;
    public TextMeshProUGUI message;
    public bool showBar, hideBar;

    //DO NOT DELETE THIS SCRIPT!!!
    void Start()
    {
        topBar.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);
        bottomBar.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);
        //StartCoroutine(ShowBars());
        //StartCoroutine(HideBars());
    }


    void Update()
    {
        if (showBar)
        {
            StartCoroutine(ShowBars());
        }
        if (hideBar)
        {
            StartCoroutine(HideBars());
        }
        //Debug.Log("showBar is: " + showBar);
        //Debug.Log("hideBar is: " + hideBar);
        if (playerController.GetComponent<Player>().dead == true)
        {
            gameOverScreen.SetActive(true);
            playerController.GetComponent<FirstPersonAIO>().canMove = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
        }
    }

    IEnumerator ShowBars()
    {
        for (int x = 0; x <= 35; x++)
        {
            yield return new WaitForSeconds(0.005f);
            topBar.GetComponent<RectTransform>().sizeDelta = new Vector2(0, x);
            bottomBar.GetComponent<RectTransform>().sizeDelta = new Vector2(0, x);
        }
    }

    IEnumerator HideBars()
    {
        StopCoroutine(ShowBars());
        yield return null;
        /*for (int y = 0; y <= 35; y++)
        {
            Debug.Log("Size is : " + y);
            yield return new WaitForSeconds(0.005f);
            topBar.GetComponent<RectTransform>().sizeDelta = new Vector2(0, -y);
            bottomBar.GetComponent<RectTransform>().sizeDelta = new Vector2(0, -y);
        }*/
        topBar.SetActive(false);
        bottomBar.SetActive(false);
    }
}
