using UnityEngine;

public class FollowingPlayerDistance : MonoBehaviour
{
    // Initiate variables
    public Transform player;
    public Transform godPlatform;

    // Define minimal and maximum distance
    public int minimalDistance = 10;
    public int maximumDistance = 12;

    public bool isOn = false;

    private void Start()
    {
        Actions.OnEnterHeaven += ActivateGodPlatform;
    }

    // Activates the god platform if right heaven is entered
    void ActivateGodPlatform(int heavenIndex)
    {
        if (heavenIndex == 2)
        {
            isOn = true;
        }
    }

    private void Update()
    {
        if (isOn)
        {
            // Get distance and direction
            float distanceBetweenPlayerGod = Vector3.Distance(player.position, godPlatform.position);
            Vector3 directionOfPlatformPlayer = (player.position - godPlatform.position).normalized;

            // Check for distance and change based on how close the palyer is and move closer or further
            if (distanceBetweenPlayerGod < minimalDistance)
            {
                Vector3 movementVector = new Vector3((godPlatform.position + directionOfPlatformPlayer * -1).x, godPlatform.position.y, (godPlatform.position + directionOfPlatformPlayer * -1).z);
                godPlatform.position = Vector3.Lerp(godPlatform.position, movementVector, Time.deltaTime);
            }
            if (distanceBetweenPlayerGod > maximumDistance)
            {
                Vector3 movementVector = new Vector3((godPlatform.position + directionOfPlatformPlayer).x, godPlatform.position.y, (godPlatform.position + directionOfPlatformPlayer).z);
                godPlatform.position = Vector3.Lerp(godPlatform.position, movementVector, Time.deltaTime);
            }
        }
    }
}
