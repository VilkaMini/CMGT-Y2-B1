using UnityEngine;

public class GatesInteraction : MonoBehaviour
{
    public Animator gateAnimator1;
    public AudioSource gateAudioSource1;
    public GameObject player;
    public bool CheckForObject;
    public Transform objectToCheck;

    private bool soundPlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!CheckForObject)
            {
                OpenGate();
            }
        }
        if (other.gameObject.tag == "Trackable")
        {
            CheckForObject = false;
        }
    }

    public void OpenGate()
    {
        // Play gate animation and sound if not played yet
        if (!soundPlayed)
        {
            gateAudioSource1.Play();
            soundPlayed = true;
        }

        gateAnimator1.SetTrigger("OpenGate");
    }
}
