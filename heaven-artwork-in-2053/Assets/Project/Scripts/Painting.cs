using System.Collections.Generic;
using UnityEngine;

public class Painting : MonoBehaviour
{
    // Initiate variables
    public GameObject player;
    public List<GameObject> spawnPoints;

    public void EnterPainting()
    {
        // Check the painting tag and teleport the player to correct heaven location
        // Each heaven trigger produces updatees to update the active heaven and turning the light in the museum to another light
        if (gameObject.tag == "Heaven1Painting")
        {
            player.transform.position = spawnPoints[0].transform.position;
            Actions.OnEnterHeaven(0);
            Actions.TurnLightOn(1);
        }
        else if (gameObject.tag == "Heaven2Painting")
        {
            player.transform.position = spawnPoints[1].transform.position;
            Actions.OnEnterHeaven(1);
            Actions.TurnLightOn(2);
        }
        else if (gameObject.tag == "Heaven3Painting")
        {
            player.transform.position = spawnPoints[2].transform.position;
            Actions.OnEnterHeaven(2);
        }
    }
}
