using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FractureBuilding : MonoBehaviour
{
    public GameObject fractured;
    public void Break()
    {
        Instantiate(fractured, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
