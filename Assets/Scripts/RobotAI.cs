using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RobotAI : MonoBehaviour
{
    public GameObject aI;
    public GameObject robot;
    public GameObject key;
    public UnityEngine.AI.NavMeshAgent robotNavMesh;
    public Transform[] waypoints;
    public Animator m_Animator;
    public int x;

    void Start()
    {
        x = 0;
        aI.GetComponent<AIScript>().message.text = "\"I see you're awake now...\"";
        StartCoroutine(wait());
        key.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown("z"))
        {
            StopCoroutine(wait());
            StartCoroutine(leave());
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(5);
        aI.GetComponent<AIScript>().message.text = "\"I apologize for the inconvinience, but this is the only way we could get here.\"";
        yield return new WaitForSeconds(5);
        aI.GetComponent<AIScript>().message.text = "\"I left you a key somewere in the cell with you.\"";
        yield return new WaitForSeconds(5);
        aI.GetComponent<AIScript>().message.text = "\"It should be easy to find.\"";
        yield return new WaitForSeconds(5);
        aI.GetComponent<AIScript>().message.text = "\"I'll be waiting out here Rol.\"";
        yield return new WaitForSeconds(3);
        StartCoroutine(leave());
    }

    IEnumerator leave()
    {
        yield return null;
        aI.GetComponent<AIScript>().message.text = "";
        //Destroy(robot.GetComponent<LookAtTarget>());
        m_Animator.SetBool("isWalking", true);
        robotNavMesh.SetDestination(waypoints[x].position);
        yield return new WaitForSeconds(2);
        Destroy(GameObject.Find("RobotBorder"));
        //Destroy(GameObject.Find("Tutorial"));
        key.SetActive(true);
        robot.SetActive(false);
        yield return null;
        Destroy(this);
    }
}
