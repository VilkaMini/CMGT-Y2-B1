using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painting : MonoBehaviour
{
    public GameObject player;

    public void EnterPainting()
    {
        print(gameObject.name);
        if (gameObject.name == "Heaven1Painting")
        {
            player.transform.position = new Vector3(-20, player.transform.position.y, 15);
        }
        else if (gameObject.name == "Heaven2Painting")
        {
            player.transform.position = new Vector3(0, player.transform.position.y, 15);
        }
        else if (gameObject.name == "Heaven3Painting")
        {
            player.transform.position = new Vector3(20, player.transform.position.y, 15);
        }
    }
}
