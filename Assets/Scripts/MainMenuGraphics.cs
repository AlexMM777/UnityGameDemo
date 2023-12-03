using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenuGraphics : MonoBehaviour
{
    public TMP_Dropdown graphics;

    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.SetQualityLevel(0);
        PlayerPrefs.SetInt("GraphicQuality", 0);
        graphics.value = PlayerPrefs.GetInt("GraphicQuality");
        //Debug.Log("MainMenuGraphics graphics.value: " + graphics.value);
        //Debug.Log("MainMenuGraphics Start: " + PlayerPrefs.GetInt("GraphicQuality"));
        Destroy(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
