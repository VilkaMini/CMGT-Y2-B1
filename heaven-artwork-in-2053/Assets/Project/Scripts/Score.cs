using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private TextMeshPro textMesh = null;

    private void Awake()
    {
        textMesh = GetComponent<TextMeshPro>();
    }

    public void ShowScore(int score)
    {
        textMesh.text = score.ToString();
    }
}
