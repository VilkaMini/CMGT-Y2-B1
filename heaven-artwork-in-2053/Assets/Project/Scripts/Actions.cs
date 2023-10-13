using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Actions
{
    // On entering heaven to pass information which heaven is entered
    public static Action<int> OnEnterHeaven;

    // Open the gates on level 1
    public static Action OpenGates;

    // Turn the light on in the museum
    public static Action<int> TurnLightOn;
}
