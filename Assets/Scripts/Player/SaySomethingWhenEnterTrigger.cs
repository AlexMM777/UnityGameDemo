using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaySomethingWhenEnterTrigger : MonoBehaviour
{
    public DialogueScript dialogue;
    public string sentence;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Player"))
        {
            dialogue.ThinkSomething(sentence);
        }
    }
}
