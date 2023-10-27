using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Painting : MonoBehaviour
{
    // Initiate variables
    public int levelID;
    public GameObject player;
    public List<GameObject> spawnPoints;
    public List<string> messagesForLoading;

    public GameObject canvas;
    public GameObject button;
    public GameObject fancyText;
    public TextMeshProUGUI fancyTextT;

    public void EnterPainting()
    {
        // Check the painting tag and teleport the player to correct heaven location
        // Each heaven trigger produces updates to update the active heaven and turning the light in the museum to another light
        if (gameObject.tag == "Heaven1Painting")
        {
            TurnOnUI();
        }
        else if (gameObject.tag == "Heaven2Painting")
        {
            TurnOnUI();
        }
        else if (gameObject.tag == "Heaven3Painting")
        {
            TurnOnUI();
        }
    }

    public void EnterLevelClicked()
    {
        button.SetActive(false);
        fancyText.SetActive(true);
        StartCoroutine(EnterLevel(levelID, levelID+1));
    }

    void TurnOnUI()
    {
        canvas.SetActive(true);
    }
    public void TurnOffUI()
    {
        canvas.SetActive(false);
    }

    IEnumerator EnterLevel(int heavenID, int lightID)
    {
        for (int i = 0; i < 6; i++)
        {
            yield return new WaitForSeconds(1);
            fancyTextT.text = messagesForLoading[i] + "...";
        }
        player.transform.position = spawnPoints[heavenID].transform.position;
        Actions.OnEnterHeaven(heavenID);
        Actions.TurnLightOn(lightID);
    }

    
}
