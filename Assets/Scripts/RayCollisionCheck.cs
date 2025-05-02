using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RayCollisionCheck : MonoBehaviour
{
    [SerializeField] private RayHandler _rayHandler;

    public event Action<Collider> CorrectColliderHiting;

    private void OnEnable()
    {
        _rayHandler.RayCollisioned += ComponentNameCheked;
    }

    private void OnDisable()
    {
        _rayHandler.RayCollisioned -= ComponentNameCheked;
    }

    private void ComponentNameCheked(RaycastHit[] hits)
    {
            Cube cube;

        foreach (RaycastHit hit in hits)
        {
            cube = hit.collider.GetComponent<Cube>();

            if (cube != null)
            {
                Debug.Log("Найден объект Cube");
                CorrectColliderHiting?.Invoke(hit.collider);
                break;
            }           
        }      
    }
}
