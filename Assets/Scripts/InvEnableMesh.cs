using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvEnableMesh : MonoBehaviour
{
    public GameObject enabled;
    public GameObject meshForItem;

    void Start()
    {
        
    }

    void Update()
    {
        if (enabled.activeSelf)
        {
            meshForItem.SetActive(true);
        }
    }
}
