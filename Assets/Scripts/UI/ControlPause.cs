using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPause : MonoBehaviour
{
    public PlayerMovement playerController;
    public PlayerAnScript playerBody;
    public PlayerCam playerCam;
    public GameObject pauseMenu;
    public bool isPaused, canPressKey;

    void Start()
    {
        isPaused = false;
        canPressKey = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && canPressKey)
        {
            print("RUNNING...");
            if(!isPaused)
            {
                isPaused = true;
            }
            else if(isPaused)
            {
                isPaused = false;
            }
            canPressKey = false;
            StartCoroutine(Wait());
        }

        if (isPaused)
        {
            playerController.isPaused = true;
            playerBody.isPaused = true;
            playerCam.enabled = false;
            pauseMenu.SetActive(true);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (!isPaused)
        {
            playerController.isPaused = false;
            playerBody.isPaused = false;
            playerCam.enabled = true;
            pauseMenu.SetActive(false);

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.1f);
        canPressKey = true;
    }
}
