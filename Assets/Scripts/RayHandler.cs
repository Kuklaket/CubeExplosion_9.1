using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RayHandler : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private Camera _camera;
    [SerializeField] private Ray _ray;
    [SerializeField] private float _maxDistance = 10;

    public event Action<RaycastHit[]> RayCollisioned;

    private void OnEnable()
    {
        _playerInput.ScreenPressed += Raycast;
    }

    private void OnDisable()
    {
        _playerInput.ScreenPressed -= Raycast;
    }

    private void Raycast()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] hits = Physics.RaycastAll(_ray, Mathf.Infinity);
        Debug.DrawRay(_ray.origin, _ray.direction * _maxDistance, Color.magenta);

        if (hits.Length >= 1)
        {
            RayCollisioned?.Invoke(hits);         
        }
    }
}
