using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableScript : MonoBehaviour
{
    public bool canInteract;
    public int interactChoice;
    public ControlWorldScript control;
    public bool isLooking;

    void Start()
    {
        
    }

    void Update()
    {
        if (isLooking)
        {
            canInteract = true;
        }
        else
        {
            canInteract = false;
        }

        if (canInteract)
        {
            control.interactSymbol.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                Interact(interactChoice);
            }
        }
        else if (!canInteract)
        {
            control.interactSymbol.SetActive(false);
        }
    }

    public void Interact(int choice)
    {
        // Change scene
        if(choice == 1)
        {
            StartCoroutine(control.FadeBlackOutSquare());
        }
        if (choice == 2)
        {
            //Do something
        }
        if (choice == 3)
        {
            //Do something
        }
    }
}
