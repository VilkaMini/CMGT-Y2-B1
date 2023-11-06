using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteObjectAfterTime : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float randomTime = Random.Range(5f, 20f);
        StartCoroutine(TimeTillDeath(randomTime));
    }

    IEnumerator TimeTillDeath(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
}
