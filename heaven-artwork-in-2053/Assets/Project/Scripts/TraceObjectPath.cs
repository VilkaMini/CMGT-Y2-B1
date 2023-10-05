using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.UIElements;
using UnityEngine.XR.Interaction.Toolkit;

public class TraceObjectPath : MonoBehaviour
{
    public List<List<Transform>> waypoints;
    public List<GameObject> waypointParents;
    public List<Transform> resetObjects;
    public int activeLevel = -1;
    public int activeWaypoint = 0;
    public TrackedPoseDriver poseTracking;

    public GameObject mainCamera;
    public GameObject rightHand;
    public GameObject leftHand;

    public float speedToMove = 0.001f;
    public Transform player;

    private void Start()
    {
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
        Actions.OnEnterHeaven += HandleLevelChange;
    }

    public void Update()
    {
        if (activeLevel != -1)
        {
            MovePlayer();
        }
    }

    private void MovePlayer()
    {
        CheckIfAtWaypoint();

        if (waypoints[activeLevel].Count <= activeWaypoint)
        {
            if (activeLevel == 0)
            {
                Actions.OpenGates();
                StartCoroutine(WaitForGates());
            }
            activeLevel = -1;
        }
        else
        {
            MoveToActiveWaypoint();
        }
    }

    private void MoveToActiveWaypoint()
    {
        player.transform.position = Vector3.MoveTowards(player.transform.position, waypoints[activeLevel][activeWaypoint].position, speedToMove);
    }

    private void CheckIfAtWaypoint()
    {
        if (player.position == waypoints[activeLevel][activeWaypoint].position)
        {
            activeWaypoint++;
        }
    }

    void HandleLevelChange(int levelId)
    {
        activeLevel = levelId;
    }

    void ResetPlayerposition()
    {
        poseTracking.m_CurrentPosition = Vector3.zero;
        mainCamera.transform.localPosition = Vector3.zero;
    }

    IEnumerator WaitForGates()
    {
        yield return new WaitForSeconds(3);
        player.transform.position = new Vector3(23.751f, 125.22f, 4.920f);
        rightHand.SetActive(true);
        leftHand.SetActive(true);
    }
}
