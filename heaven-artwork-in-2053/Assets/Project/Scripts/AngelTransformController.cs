using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelTransformController : MonoBehaviour
{
    public ObjectToObjectFollow objectFollowControler = null;
    public AudioSource manScreamingAudio;
    public AudioSource babyCryingAudio;
    public ParticleSystem bloodPart;

    public FractureBuilding buildingToBreak = null;
    private bool hasTouched = false;

    public void Start()
    {
        objectFollowControler = GetComponent<ObjectToObjectFollow>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            objectFollowControler.isFollowing = true;
        }
    }

    public void AngelTouched()
    {
        if (!hasTouched)
        {
            bloodPart.Play();
            hasTouched = true;
            buildingToBreak.Break();
            manScreamingAudio.Play();
            babyCryingAudio.Play();
            StartCoroutine(DeleteAfterTime(2));
        }
    }

    IEnumerator DeleteAfterTime(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
}
