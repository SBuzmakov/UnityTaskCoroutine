using System;
using UnityEngine;

public class Input : MonoBehaviour
{
    public event Action OnMouseButtonPressed;

    private void Update()
    {
        PressMouseButton0();
    }
    
    private void PressMouseButton0()
    {
        if (UnityEngine.Input.GetKeyDown(KeyCode.Mouse0)) 
            OnMouseButtonPressed?.Invoke();
    }
}
