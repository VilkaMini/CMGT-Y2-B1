using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painting : MonoBehaviour
{
    public GameObject player;
    public List<GameObject> spawnPoints;

    public void EnterPainting()
    {
        print(gameObject.name);
        if (gameObject.tag == "Heaven1Painting")
        {
            player.transform.position = spawnPoints[0].transform.position;
            Actions.OnEnterHeaven(0);
        }
        else if (gameObject.tag == "Heaven2Painting")
        {
            player.transform.position = spawnPoints[1].transform.position;
            Actions.OnEnterHeaven(0);
        }
        else if (gameObject.tag == "Heaven3Painting")
        {
            player.transform.position = spawnPoints[2].transform.position;
            Actions.OnEnterHeaven(2);
        }
    }
}
