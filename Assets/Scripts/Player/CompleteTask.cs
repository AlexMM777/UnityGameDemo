using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompleteTask : MonoBehaviour
{
    private bool inRange;
    public Toggle task;
    public GameObject interactIcon;
    public GameObject obj;
    public bool enableObjWhenGet;

    // Start is called before the first frame update
    void Start()
    {
        obj.gameObject.SetActive(false);
        task.isOn = false;
        inRange = false;
        interactIcon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange)
        {
            interactIcon.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                task.isOn = true;
                Destroy(this.gameObject);
                if(enableObjWhenGet)
                {
                    obj.SetActive(true);
                }
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
