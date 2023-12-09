using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScanner : MonoBehaviour
{
    public bool hasGun;
    public GameObject armHolder, upperArm, scanner;
    public Transform targetDefault, targetToCam, defaultArmLoc, upArmLoc;
    private bool isRightHolding, isLeftHolding;
    private GameObject[] guns;


    void Start()
    {
        isRightHolding = false;
        hasGun = false;
    }

    void Update()
    {
        if (isRightHolding && hasGun)
        {
            armHolder.GetComponent<PersonLookAtTarget>().target = targetToCam.transform;
            upperArm.transform.position = upArmLoc.position;
            upperArm.transform.rotation = upArmLoc.rotation;
            if (isLeftHolding)
            {
                scanner.SetActive(true);
            }
            else
            {
                scanner.SetActive(false);
            }
        }
        else
        {
            armHolder.GetComponent<PersonLookAtTarget>().target = targetDefault.transform;
            upperArm.transform.position = defaultArmLoc.position;
            upperArm.transform.rotation = defaultArmLoc.rotation;
        }

        if (Input.GetMouseButtonDown(1))
        {
            guns = GameObject.FindGameObjectsWithTag("Gun");
            foreach (GameObject gun in guns)
            {
                if (gun.activeSelf == true)
                {
                    hasGun = true;
                }
            }
            isRightHolding = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            isRightHolding = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            isLeftHolding = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isLeftHolding = false;
        }
    }
}
