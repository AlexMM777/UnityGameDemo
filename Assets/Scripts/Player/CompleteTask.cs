using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompleteTask : MonoBehaviour
{
    private bool inRange;
    public Toggle task;
    public GameObject interactIcon;
    public bool enableObjWhenGet;
    public bool disableObjWhenGet;
    public GameObject[] enableObjects;
    public GameObject[] disableObjects;

    // Start is called before the first frame update
    void Start()
    {   
        task.isOn = false;
        inRange = false;
        interactIcon.SetActive(false);
    }

    void Update()
    {
        if (inRange)
        {
            interactIcon.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                task.isOn = true;
                interactIcon.SetActive(false);
                if (enableObjWhenGet)
                {
                    foreach (GameObject item in enableObjects)
                    {
                        item.gameObject.SetActive(true);
                    }
                }
                if(disableObjWhenGet)
                {
                    foreach (GameObject item in disableObjects)
                    {
                        item.gameObject.SetActive(false);
                    }
                }
                Destroy(this.gameObject);
            }
        }
        else
        {
            interactIcon.SetActive(false);
        }
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
}
