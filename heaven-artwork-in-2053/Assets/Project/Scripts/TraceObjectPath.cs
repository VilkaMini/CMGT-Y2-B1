using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraceObjectPath : MonoBehaviour
{
    // Define variables
    public List<List<Transform>> waypoints;
    public List<GameObject> waypointParents;
    public int activeLevel = -1;
    public int activeWaypoint = 0;
    public GameObject locomotionEnabler;

    public float speedToMove = 0.001f;
    public Transform player;

    private void Start()
    {
        // Initiate all the waypoints
        waypoints = new List<List<Transform>>();
        int waypointCounter = 0;
        foreach (GameObject waypointParent in waypointParents)
        {
            waypoints.Add(new List<Transform>());
            foreach (Transform waypoint in waypointParent.GetComponentInChildren<Transform>()) 
            {
                waypoints[waypointCounter].Add(waypoint);
            }
            waypointCounter++;
        }

        // Add level change handle action
        Actions.OnEnterHeaven += HandleLevelChange;
    }

    public void Update()
    {
        // Check if player is in the level
        if (activeLevel == 0)
        {
            // Disable joystick movement and startmoving player automatically
            locomotionEnabler.SetActive(false);
            MovePlayer();
        }
    }

    private void MovePlayer()
    {
        // Check if at waypoint location
        if (activeWaypoint < waypoints[activeLevel].Count-1)
        {
            CheckIfAtWaypoint();
        }

        // If at last check point, start teleporting back sequence
        if (waypoints[activeLevel].Count-1 == activeWaypoint)
        {
            if (activeLevel == 0)
            {
                StartCoroutine(WaitForGates());
            }
            activeLevel = -1;
        }
        // If not last checkpoint, move player to active
        else
        {
            MoveToActiveWaypoint();
        }
    }

    // Move the player to active waypoint
    private void MoveToActiveWaypoint()
    {
        player.transform.position = Vector3.MoveTowards(player.transform.position, waypoints[activeLevel][activeWaypoint].position, speedToMove);
    }

    // Check if at waypoint location
    private void CheckIfAtWaypoint()
    {
        if (player.position == waypoints[activeLevel][activeWaypoint].position)
        {
            activeWaypoint++;
        }
    }

    // Level changer, controls if the tracing is needed
    void HandleLevelChange(int levelId)
    {
        activeLevel = levelId;
    }

    // End of heaven1 coroutine to let the animation happend and then teleporting player back to museum
    IEnumerator WaitForGates()
    {
        yield return new WaitForSeconds(5);
        player.transform.position = new Vector3(23.751f, 125.22f, 4.920f);
        locomotionEnabler.SetActive(true);
    }
}
