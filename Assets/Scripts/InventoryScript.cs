using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    public List<GameObject> invObjects;
    public GameObject inventoryScreen, playerController;
    public Transform[] inventory;
    public GameObject equipped;
    public Transform locOfImage;
    public GameObject pauseMenu;

    void Start()
    {
        inventoryScreen.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        for (int x = 0; x < invObjects.Count; x++)
        {
            invObjects[x].transform.position = inventory[x].position;
            invObjects[x].SetActive(true);
        }

        if (inventoryScreen.activeSelf)
        {
            if (Input.GetKeyDown("i") || Input.GetKeyDown(KeyCode.Escape))
            {
                inventoryScreen.SetActive(false);
                playerController.GetComponent<FirstPersonAIO>().canMove = true;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Time.timeScale = 1;
            }
        }
        else if (Input.GetKeyDown("i"))
        {
            inventoryScreen.SetActive(true);
            playerController.GetComponent<FirstPersonAIO>().canMove = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
        }
        

        if (pauseMenu.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                pauseMenu.SetActive(false);
                playerController.GetComponent<FirstPersonAIO>().canMove = true;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Time.timeScale = 1;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && !inventoryScreen.activeSelf)
        {
            pauseMenu.SetActive(true);
            playerController.GetComponent<FirstPersonAIO>().canMove = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
        }
    }

    public void Unequip()
    {
        GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag("equipped");
        foreach (GameObject go in gameObjectArray)
        {
            go.SetActive(false);
        }
    }

    public void Equip(int x)
    {
        if (x >= 0 && x < invObjects.Count)
        {
            equipped = invObjects[x].transform.GetChild(0).gameObject;
            invObjects[x].transform.GetChild(0).gameObject.transform.position = locOfImage.position;
            invObjects[x].transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
