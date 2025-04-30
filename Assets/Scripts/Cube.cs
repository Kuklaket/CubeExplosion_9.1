using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public Cube()
    {
        ChanceDuplication = 100;
    }

    public float ChanceDuplication { get; private set; }

    public void ReduceChance()
    {
        ChanceDuplication = ChanceDuplication * 0.5f;
        Debug.Log(ChanceDuplication);
    }

    public float SetChanceDuplication(float newChance)
    {
        ChanceDuplication = newChance;
        return ChanceDuplication;
    }

    public void SetScale(Vector3 oldScale)
    {
        float scaleModifier = 0.5f;
        transform.localScale = oldScale * scaleModifier;
    }

    public void RandomizeColor()
    {
        Renderer renderer = GetComponent<Renderer>();
        Material newMaterial = new Material(renderer.sharedMaterial);
        Color randomColor = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
        newMaterial.color = randomColor;
        renderer.material = newMaterial;
    }
}