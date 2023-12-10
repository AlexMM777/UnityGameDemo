using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ScannerVision : MonoBehaviour
{
    public PlayerScanner catcherPlayerScript;
    public Transform catcher;
    private float speed = 10f;
    private bool catching;
    public bool isCatched = false;
    private GameObject otherObj;

    bool isScaling = false;

    void Start()
    {
        catching = false;
    }

    void Update()
    {
        if (catching)
        {
            var step = speed * Time.deltaTime;
            otherObj.transform.position = Vector3.MoveTowards(otherObj.transform.position, catcher.position, step);
            StartCoroutine(scaleOverTime(otherObj.transform, new Vector3(0, 0, 0), 1.5f));

            if (Vector3.Distance(otherObj.transform.position, catcher.position) < 0.001f)
            {
                isCatched = true;
                otherObj.GetComponent<CompleteTask>().task.isOn = true;
                foreach (GameObject item in otherObj.GetComponent<CompleteTask>().enableObjects)
                {
                    item.gameObject.SetActive(true);
                }
                foreach (GameObject item in otherObj.GetComponent<CompleteTask>().disableObjects)
                {
                    item.gameObject.SetActive(false);
                }
                catching = false;
            }
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Catchable"))
        {
            if (catcherPlayerScript.GetComponent<PlayerScanner>().scanning)
            {
                Catch(other.gameObject);
            }
        }
    }

    public void Catch(GameObject other)
    {
        other.GetComponent<BoxCollider>().enabled = false;
        other.GetComponent<RotateObj>().enabled = false;
        other.GetComponent<Animator>().enabled = false;
        otherObj = other;
        catching = true;
    }

    

    IEnumerator scaleOverTime(Transform objectToScale, Vector3 toScale, float duration)
    {
        //Make sure there is only one instance of this function running
        if (isScaling)
        {
            yield break; ///exit if this is still running
        }
        isScaling = true;

        float counter = 0;

        //Get the current scale of the object to be moved
        Vector3 startScaleSize = objectToScale.localScale;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            objectToScale.localScale = Vector3.Lerp(startScaleSize, toScale, counter / duration);
            yield return null;
        }
        isScaling = false;
    }
}
