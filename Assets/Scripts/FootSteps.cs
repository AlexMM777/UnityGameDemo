using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    public GameObject playerController, playerBody;
    public AudioSource audioSource;
    public AudioClip[] stoneSteps, grassSteps, dirtSteps, woodSteps, carpetSteps;
    public int stoneIndex, grassIndex, dirtIndex, woodChipIndex, woodIndex, carpetIndex;
    public AudioClip[] chosenSounds;
    public bool isOnGround;
    public AudioClip finalChosen;
    public bool isOnObj;

    // Start is called before the first frame update
    void Start()
    {
        finalChosen = stoneSteps[Random.Range(0, stoneSteps.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        isOnGround = playerController.GetComponent<PlayerMovement>().grounded;

        if(!isOnObj) {
            //Debug.Log("Is on terrain");
            if (isOnGround)
            {
                if (playerBody.GetComponent<TerrainTextureDetector>().surfaceIndex == stoneIndex)
                {
                    //Debug.Log("Stone");
                    chosenSounds = stoneSteps;
                    ChooseRandom();
                }
                if (playerBody.GetComponent<TerrainTextureDetector>().surfaceIndex == grassIndex)
                {
                    //Debug.Log("Grass");
                    chosenSounds = grassSteps;
                    ChooseRandom();
                }
                if (playerBody.GetComponent<TerrainTextureDetector>().surfaceIndex == dirtIndex)
                {
                    //Debug.Log("Dirt");
                    chosenSounds = dirtSteps;
                    ChooseRandom();
                }
                if (playerBody.GetComponent<TerrainTextureDetector>().surfaceIndex == woodChipIndex)
                {
                    //Debug.Log("WoodChip");
                    chosenSounds = grassSteps;
                    ChooseRandom();
                }
                if (playerBody.GetComponent<TerrainTextureDetector>().surfaceIndex == woodIndex)
                {
                    //Debug.Log("Wood");
                    chosenSounds = woodSteps;
                    ChooseRandom();
                }
                if (playerBody.GetComponent<TerrainTextureDetector>().surfaceIndex == carpetIndex)
                {
                    //Debug.Log("Carpet");
                    chosenSounds = carpetSteps;
                    ChooseRandom();
                }
            }
        }
    }
    

    public void ChooseRandom()
    {
        //audioSource.clip = chosenSounds[Random.Range(0, chosenSounds.Length)];
        finalChosen = chosenSounds[Random.Range(0, chosenSounds.Length)];
        //audioSource.Play();
    }

    private void Step()
    {
        audioSource.PlayOneShot(finalChosen);
    }

}
