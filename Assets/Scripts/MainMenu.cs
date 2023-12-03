using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
	public GameObject main, settings, exit;
	public AudioMixer audioMixer;

	void Start()
	{
		main.SetActive(true);
		settings.SetActive(false);
	}

	public void LoadScene(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}

	public void Enable(GameObject enable)
    {
		enable.SetActive(true);
    }
	public void Disable(GameObject disable)
	{
		disable.SetActive(false);
	}

	public void SetMasterVolume(float masterVolume)
	{
		audioMixer.SetFloat("masterVol", masterVolume);
	}

	public void SetQuality(int qualityIndex)
    {
		QualitySettings.SetQualityLevel(qualityIndex);
    }

	public void SetFullscreen(bool isFullscreen)
    {
		Screen.fullScreen = isFullscreen;
    }
}
