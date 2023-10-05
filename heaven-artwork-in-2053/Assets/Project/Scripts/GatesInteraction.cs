using System.Collections;
using UnityEditor.ShaderGraph.Drawing.Inspector.PropertyDrawers;
using UnityEngine;

public class GatesInteraction : MonoBehaviour
{
    public Animator gateAnimator;
    public AudioSource gateAudioSource;
    public GameObject player;

    private bool soundPlayed = false;


    private void Start()
    {
        Actions.OpenGates += OpenGate;    
    }

    public void OpenGate()
    {
        // Play gate animation and sound if not played yet
        if (!soundPlayed)
        {
            gateAudioSource.Play();
            soundPlayed = true;
        }

        gateAnimator.SetTrigger("OpenGate");
    }
}
