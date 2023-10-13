using UnityEngine;

public class RotateBlendShapes : MonoBehaviour
{
    // Define variables
    SkinnedMeshRenderer skinnedMeshRenderer;
    Mesh skinnedMesh;
    int blendShapeCount;

    int playIndex = 0;
    public float animationSpeed = 1.0f;

    void Start()
    {
        // Gets skinnedmeshrendered component to get the blend shapes
        skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        skinnedMesh = skinnedMeshRenderer.sharedMesh;
        blendShapeCount = skinnedMesh.blendShapeCount;

        // Repeat the rotation of blendshapes for continuous animation
        InvokeRepeating("AnimationControl", 0, 0.02f);
    }

    // Animate the blendshapes object
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
