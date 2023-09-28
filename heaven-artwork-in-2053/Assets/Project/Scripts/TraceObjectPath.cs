using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.UIElements;

public class TraceObjectPath : MonoBehaviour
{
    public List<Transform> waypoints;
    public List<Transform> resetObjects;
    public int activeLevel = -1;
    public int activeWaypoint = 0;
    public TrackedPoseDriver poseTracking;

    public float speedToMove = 0.001f;
    public Transform player;

    private void Start()
    {
        Actions.OnEnterHeaven += HandleLevelChange;
        Actions.OnEnterHeaven += ResetChildrenPosition;
    }

    public void Update()
    {
        if (activeLevel == 0)
        {
            poseTracking.trackingType = TrackedPoseDriver.TrackingType.RotationOnly;
            print("Even Before: " + activeWaypoint);

            if (waypoints.Count <= activeWaypoint)
            {
                print("Before: " + activeWaypoint);
                activeLevel = -1;
                poseTracking.trackingType = TrackedPoseDriver.TrackingType.RotationAndPosition;
            }
            else
            {
                print("After: " + activeWaypoint);
                CheckIfAtWaypoint();
                MoveToActiveWaypoint();
            }
        }
    }

    private void MoveToActiveWaypoint()
    {
        player.transform.position = Vector3.MoveTowards(player.transform.position, waypoints[activeWaypoint].position, speedToMove);
    }

    private void CheckIfAtWaypoint()
    {
        if (player.position == waypoints[activeWaypoint].position)
        {
            activeWaypoint++;
        }
    }

    void HandleLevelChange(int levelId)
    {
        activeLevel = levelId;
    }

    void ResetChildrenPosition(int i)
    {
        foreach (Transform t in resetObjects) 
        {
            t.position = player.position;
        }
    }
}
