using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimationOnTriggerEnter : MonoBehaviour
{
    public GameObject playerCam, playerAnCam, playerController, aI, player;
    public string[] dialogue;
    public bool isFrozen, scene;
    public Vector3 location, updatingLoc;
    public int sentences;

    void Start()
    {
        
    }

    void Update()
    {
        
        if (isFrozen)
        {
            location = updatingLoc;
            playerController.GetComponent<FirstPersonAIO>().canMove = false;
            playerController.transform.position = updatingLoc;
            aI.GetComponent<AIScript>().showBar = true;
            aI.GetComponent<AIScript>().map.SetActive(false);
            //aI.SetActive(false);
        }
        else
        {
            updatingLoc = playerController.transform.position;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!scene)
            {
                Destroy(GameObject.Find("Tutorial"));
                isFrozen = true;
                player.GetComponent<PlayerAnScript>().m_Animator.SetBool("isGoingRight", false);
                player.GetComponent<PlayerAnScript>().m_Animator.SetBool("isCrouching", false);
                player.GetComponent<PlayerAnScript>().m_Animator.SetBool("isGoingForward", false);
                player.GetComponent<PlayerAnScript>().m_Animator.SetBool("isGoingLeft", false);
                player.GetComponent<PlayerAnScript>().m_Animator.SetBool("isGoingBack", false);
                player.GetComponent<PlayerAnScript>().canMove = false;
                StartCoroutine(playAn());
            }
        }
    }

    IEnumerator playAn()
    {
        scene = true;
        player.SetActive(false);
        playerCam.SetActive(false);
        playerAnCam.SetActive(true);
        playerAnCam.GetComponent<Animator>().SetTrigger("camLook");
        yield return new WaitForSeconds(5);
        for (int x = 0; x < dialogue.Length; x++)
        {
            aI.GetComponent<AIScript>().message.text = dialogue[x];
            yield return new WaitForSeconds(3);
        }
        isFrozen = false;
        aI.GetComponent<AIScript>().message.text = "";
        aI.GetComponent<AIScript>().showBar = false;
        aI.GetComponent<AIScript>().hideBar = true;
        aI.GetComponent<AIScript>().map.SetActive(true);
        playerController.GetComponent<FirstPersonAIO>().canMove = true;
        player.GetComponent<PlayerAnScript>().canMove = true;
        playerCam.SetActive(true);
        playerAnCam.SetActive(false);
        player.SetActive(true);
        Destroy(this);

    }
}
