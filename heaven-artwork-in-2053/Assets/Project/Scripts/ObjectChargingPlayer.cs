using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class ObjectChargingPlayer : MonoBehaviour
{
    // Initiate variables
    public Transform player;
    public Transform objectToCharge;
    public Collider sphereCollider;

    // Define distance to player
    public float distanceToPlayer = 0.0f;
    public float distanceThreshhold = 0.0f;

    public bool isOn = false;

    private void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();
        Actions.OpenGates += DeleteObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        isOn = true;
    }

    private void Update()
    {
        if (isOn)
        {
            distanceToPlayer = Vector3.Distance(player.position, objectToCharge.position);
            Vector3 directionOfObjectPlayer = (player.position - objectToCharge.position).normalized;
            if (distanceToPlayer > distanceThreshhold)
            {
                objectToCharge.position = Vector3.Lerp(objectToCharge.position, player.position, Time.deltaTime * distanceToPlayer * 0.1f);
            }
            if (distanceToPlayer < distanceThreshhold)
            {
                objectToCharge.position = Vector3.Lerp(objectToCharge.position, player.position, Time.deltaTime * distanceToPlayer * 0.1f);
            }
        }
    }

    private void DeleteObject()
    {
        Destroy(this);
    }
}
