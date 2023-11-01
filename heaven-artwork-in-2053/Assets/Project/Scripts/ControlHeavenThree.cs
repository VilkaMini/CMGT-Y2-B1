using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlHeavenThree : MonoBehaviour
{
    public Transform player;
    public GameObject locomotionController;
    public RotateBlendShapes godAnimation;
    public AudioSource godAudio;

    private void Start()
    {
        Actions.OnEnterHeaven += StartHeaven;
    }

    void StartHeaven(int heavenID)
    {
        if (heavenID == 2) 
        {
            locomotionController.SetActive(false);
            StartCoroutine(HeavenSequence());
        }
    }


    IEnumerator HeavenSequence()
    {
        godAudio.Play();
        yield return new WaitForSeconds(5);
        godAnimation.InvokeOnCommand();
        yield return new WaitForSeconds(15);
        player.transform.position = new Vector3(23.751f, 125.22f, 4.920f);
        locomotionController.SetActive(true);
    }
}
