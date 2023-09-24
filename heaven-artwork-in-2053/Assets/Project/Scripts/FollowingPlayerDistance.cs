using UnityEngine;

public class FollowingPlayerDistance : MonoBehaviour
{
    public Transform player;
    public Transform godPlatform;

    public int minimalDistance = 10;
    public int maximumDistance = 12;

    public bool isOn = false;

    private void Update()
    {
        if (isOn)
        {
            // Get distance and direction
            float distanceBetweenPlayerGod = Vector3.Distance(player.position, godPlatform.position);
            Vector3 directionOfPlatformPlayer = (player.position - godPlatform.position).normalized;

            if (distanceBetweenPlayerGod < minimalDistance)
            {
                godPlatform.position = Vector3.Lerp(godPlatform.position, godPlatform.position + directionOfPlatformPlayer * -1, Time.deltaTime);
            }
            if (distanceBetweenPlayerGod > maximumDistance)
            {
                godPlatform.position = Vector3.Lerp(godPlatform.position, godPlatform.position + directionOfPlatformPlayer, Time.deltaTime);
            }

            Debug.DrawLine(godPlatform.position, godPlatform.position + directionOfPlatformPlayer * 10, Color.red, 3f);
        }
    }
}
