using System.Collections.Generic;
using UnityEngine;

public class SpotlightController : MonoBehaviour
{
    // Define all lights
    public List<Light> spotlights;
    
    private void Start()
    {
        // Add to light action
        Actions.TurnLightOn += ControlLights;
    }

    void ControlLights(int lightID)
    {
        // For each light in list
        for (int i=0; i<spotlights.Count; i++)
        {
            // Check if light is the one that is commanded to be turned on if not turn of light
            if (lightID == i)
            {
                spotlights[i].enabled = true;
            }
            else
            {
                spotlights[i].enabled = false;
            }
        }
    }
}
