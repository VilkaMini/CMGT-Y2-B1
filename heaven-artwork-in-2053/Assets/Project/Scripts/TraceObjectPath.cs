using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.UIElements;
using UnityEngine.XR.Interaction.Toolkit;

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
            MovePlayer();
        }
    }

    private void MovePlayer()
    {
        poseTracking.trackingType = TrackedPoseDriver.TrackingType.RotationOnly;
        CheckIfAtWaypoint();
        ResetPlayerposition();

        if (waypoints.Count <= activeWaypoint)
        {
            activeLevel = -1;
            ResetPlayerposition();
            poseTracking.trackingType = TrackedPoseDriver.TrackingType.RotationAndPosition;
        }
        else
        {
            MoveToActiveWaypoint();
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

    void ResetPlayerposition()
    {
        poseTracking.m_CurrentPosition = Vector3.zero;
    }
}
