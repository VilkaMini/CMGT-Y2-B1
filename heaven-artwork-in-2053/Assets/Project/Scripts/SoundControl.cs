using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour
{
    public AudioSource heaven1;
    public AudioSource heaven2;

    private void Start()
    {
        Actions.OnEnterHeaven += PlaySounds;
    }

    private void PlaySounds(int heavenID)
    {
        if (heavenID == -1)
        {
            heaven1.Stop();
            heaven2.Stop();
        }
        if (heavenID == 0)
        {
            heaven1.Play();
        }
        if (heavenID == 1)
        {
            heaven2.Play();
        }
    }
}
