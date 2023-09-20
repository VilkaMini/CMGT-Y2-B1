using UnityEngine;
using System.Collections;

public class RotateBlendShapes : MonoBehaviour
{
    SkinnedMeshRenderer skinnedMeshRenderer;
    Mesh skinnedMesh;
    int blendShapeCount;

    int playIndex = 0;
    public float animationSpeed = 1.0f;

    void Start()
    {
        skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        skinnedMesh = skinnedMeshRenderer.sharedMesh;
        blendShapeCount = skinnedMesh.blendShapeCount;

        InvokeRepeating("AnimationControl", 0, 0.02f);
    }

    void AnimationControl()
    {
        // Sets last blendShape index to zero
        if (playIndex > 0)
        {
            skinnedMeshRenderer.SetBlendShapeWeight(playIndex - 1, 0f);
        }

        // If last index was the last blendShape, set it to 0 to repeat animation
        if (playIndex == 0)
        {
            skinnedMeshRenderer.SetBlendShapeWeight(blendShapeCount - 1, 0f);
        }

        // Set current blendShape to 100
        skinnedMeshRenderer.SetBlendShapeWeight(playIndex, 100f);

        playIndex++;

        if (playIndex > blendShapeCount - 1)
        {
            playIndex = 0;
        }
    }
}
