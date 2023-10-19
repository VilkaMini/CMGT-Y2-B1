using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Painting : MonoBehaviour
{
    // Initiate variables
    public GameObject player;
    public List<GameObject> spawnPoints;
    public Coroutine activeCoroutine;
    public bool activated = false;

    public GameObject canvas;
    public TextMeshProUGUI counter;
    public bool teleportInterupcted;

    public void EnterPainting()
    {
        if (!activated)
        {
            activated = true;
            teleportInterupcted = false;
            // Check the painting tag and teleport the player to correct heaven location
            // Each heaven trigger produces updatees to update the active heaven and turning the light in the museum to another light
            if (gameObject.tag == "Heaven1Painting")
            {
                activeCoroutine = StartCoroutine(EnterLevel(0, 1));
            }
            else if (gameObject.tag == "Heaven2Painting")
            {
                activeCoroutine = StartCoroutine(EnterLevel(1, 2));
            }
            else if (gameObject.tag == "Heaven3Painting")
            {
                activeCoroutine = StartCoroutine(EnterLevel(2, 2));
            }
        }
    }

    IEnumerator EnterLevel(int heavenID, int lightID)
    {
        canvas.SetActive(true);
        for (int i = 5; i > 0; i--)
        {
            counter.text = i.ToString();
            yield return new WaitForSeconds(1);
        }
        if (!teleportInterupcted)
        {
            player.transform.position = spawnPoints[heavenID].transform.position;
            Actions.OnEnterHeaven(heavenID);
            Actions.TurnLightOn(lightID);
        }
    }

    public void CancelEntering()
    {
        if (activated) {
            activated = false;
            StopCoroutine(activeCoroutine);
            canvas.SetActive(false);
            teleportInterupcted = true;
            activated = false;
        }
    }
}
