using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSky : MonoBehaviour
{
    public Material skybox1;

    void OnEnable()
    {
        RenderSettings.skybox = skybox1;
    }
}