using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public event Action OnScreenPressed;

    private void Update()
    {
        Pressed();
    }

    public void Pressed()
    {
        if (Input.GetMouseButtonDown(0))
            OnScreenPressed?.Invoke();
    }
}
