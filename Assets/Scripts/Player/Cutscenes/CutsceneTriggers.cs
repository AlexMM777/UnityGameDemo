using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class CutsceneTriggers : MonoBehaviour
{
    Animator m_Animator;
    AudioSource m_Source;
    public GameObject phone;
    public GameObject playerTarget, cutscenePlayer, cutsceneStuff, playerController;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
        m_Source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GetPhone()
    {
        m_Source.Play();
        phone.SetActive(true);
        StartCoroutine(DoSomethingAfterTime(2, "getPhone", true));
    }

    public void PutDownPhone()
    {
        StartCoroutine(DoSomethingAfterTime(0, "getPhone", false));
        StartCoroutine(PutDownPhoneTimed());
    }

    IEnumerator DoSomethingAfterTime(float time, string action, bool active)
    {
        yield return new WaitForSeconds(time);
        m_Animator.SetBool(action, active);
    }

    IEnumerator PutDownPhoneTimed()
    {
        yield return new WaitForSeconds(3);
        phone.SetActive(false);
    }
    
    private void LookLeft()
    {
        m_Animator.SetTrigger("lookLeft");
    }

    private void StandUp()
    {
        StartCoroutine(Move(cutscenePlayer.transform.position, playerTarget.transform.position, 1f));
    }

    IEnumerator Move(Vector3 beginPos, Vector3 endPos, float time)
    {
        for (float t = 0; t < 1; t += Time.deltaTime / time)
        {
            cutscenePlayer.transform.position = Vector3.Lerp(beginPos, endPos, t);
            yield return null;
        }
        playerController.SetActive(true);
        Destroy(cutsceneStuff);
    }
}
