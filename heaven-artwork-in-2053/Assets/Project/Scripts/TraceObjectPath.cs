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
        ResetPlayerposition();

        rightHand.SetActive(false);
        leftHand.SetActive(false);

        poseTracking.trackingType = TrackedPoseDriver.TrackingType.RotationOnly;
        CheckIfAtWaypoint();

        if (waypoints[activeLevel].Count <= activeWaypoint)
        {
            activeLevel = -1;
            poseTracking.trackingType = TrackedPoseDriver.TrackingType.RotationAndPosition;
            rightHand.SetActive(true);
            leftHand.SetActive(true);
        }
        else
        {
            MoveToActiveWaypoint();
        }
    }

    private void MoveToActiveWaypoint()
    {
        player.transform.position = Vector3.MoveTowards(player.transform.position, waypoints[activeLevel][activeWaypoint].position, speedToMove);
        print("Waypoint" + activeWaypoint);
        print("Level" + activeLevel);
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
        mainCamera.transform.localPosition = Vector3.zero;
    }
}
