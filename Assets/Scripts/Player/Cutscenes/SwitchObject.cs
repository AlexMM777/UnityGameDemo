using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchObject : MonoBehaviour
{
    public GameObject staticObj;
    public bool setActive;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Switch()
    {
        staticObj.SetActive(setActive);
        Destroy(this.gameObject);
    }
}
