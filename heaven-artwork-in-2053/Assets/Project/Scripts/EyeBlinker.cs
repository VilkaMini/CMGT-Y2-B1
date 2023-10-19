using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBlinker : MonoBehaviour
{
    public List<Renderer> eyeRenderers; //List of eye renderers.
    public Material openEyesMaterial;  //Material for open eyes.
    public Material closedEyesMaterial; //Material for closed eyes.

    [Header("Blink Properties")]
    public Vector2 blinkIntervalRange = new Vector2(3.0f, 8.0f);  //Range for time until next blink.
    public float blinkDuration = 0.1f; //Duration of the blink.

    private void Start()
    {
        GameObject[] eyes = GameObject.FindGameObjectsWithTag("Eye");
        foreach (GameObject eye in eyes)
        {
            eyeRenderers.Add(eye.GetComponent<Renderer>());
        }

        //All eyes need to have the open eyes material initially.
        foreach (var eyeRenderer in eyeRenderers)
        {
            eyeRenderer.material = openEyesMaterial;
        }

        foreach (var eyeRenderer in eyeRenderers)
        {
            StartCoroutine(RandomBlinkRoutine(eyeRenderer));
        }
    }

    private IEnumerator RandomBlinkRoutine(Renderer eyeRenderer)
    {
        while (true)
        {
            float randomBlinkInterval = Random.Range(blinkIntervalRange.x, blinkIntervalRange.y);
            yield return new WaitForSeconds(randomBlinkInterval);

            //Switch to closed eyes material.
            eyeRenderer.material = closedEyesMaterial;

            //Wait for the blink duration.
            yield return new WaitForSeconds(blinkDuration);

            //Switch back to open eyes material.
            eyeRenderer.material = openEyesMaterial;
        }
    }
}