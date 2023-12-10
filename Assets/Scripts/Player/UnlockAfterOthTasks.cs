using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockAfterOthTasks : MonoBehaviour
{
    public Toggle task1, task2, task3;
    public GameObject[] enableAfter3Tasks;

    void Start()
    {
        
    }

    void Update()
    {
        if (task1.isOn && task2.isOn && task3.isOn)
        {
            foreach (GameObject item in enableAfter3Tasks)
            {
                item.SetActive(true);
            }
            Destroy(this);
        }
    }
}
