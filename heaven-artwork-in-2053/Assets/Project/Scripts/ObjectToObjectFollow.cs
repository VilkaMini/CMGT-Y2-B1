using UnityEngine;

public class ObjectToObjectFollow : MonoBehaviour
{
    public Transform follower;
    public Transform objectToFollow;

    public float minimalDistance = 2.0f;
    public float followSpeed = 0.05f;

    public bool isFollowing = false;

    private void Update()
    {
        if (isFollowing)
        {
            // Get distance and direction
            float distanceBetween = Vector3.Distance(follower.position, objectToFollow.position);

            // Check for distance and change based on how close the palyer is and move closer or further
            if (distanceBetween > minimalDistance)
            {
                follower.position = Vector3.Lerp(follower.position, objectToFollow.position, Time.deltaTime * followSpeed);
            }
        }
    }
}
