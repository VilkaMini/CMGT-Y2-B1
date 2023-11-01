using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GatesInteraction : MonoBehaviour
{
    public Animator gateAnimator1;
    public AudioSource gateAudioSource1;
    public GameObject player;
    public GameObject playerOrigin;
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
            StartCoroutine(WaitForGates());
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

    IEnumerator WaitForGates()
    {
        OpenGate();
        yield return new WaitForSeconds(5);
        playerOrigin.transform.position = new Vector3(23.751f, 125.22f, 4.920f);
        Actions.OnEnterHeaven(-1);
    }
        
}
