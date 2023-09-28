using UnityEditor.ShaderGraph.Drawing.Inspector.PropertyDrawers;
using UnityEngine;

public class GatesInteraction : MonoBehaviour
{
    public Animator gateAnimator;
    public AudioSource gateAudioSource;

    private bool soundPlayed = false;
    public void OpenGate()
    {
        // Play gate animation and sound if not played yet
        if (!soundPlayed)
        {
            gateAudioSource.Play();
            soundPlayed = true;
        }

        gateAnimator.SetTrigger("OpenGate");
        Actions.OnEnterHeaven(-1);
    }
}
