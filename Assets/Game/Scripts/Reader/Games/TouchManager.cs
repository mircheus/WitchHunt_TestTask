using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TouchManager : MonoBehaviour
{
    [SerializeField] private InputAction screenPosition;
    [SerializeField] private InputAction press;

    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        screenPosition.Enable();
        press.Enable();
        press.performed += TouchPressed;
    }
    
    private void OnDisable()
    {
        screenPosition.Disable();
        press.Disable();
        press.performed -= TouchPressed;
    }
    
    private void TouchPressed(InputAction.CallbackContext context)
    {
        Vector2 touchPosition = screenPosition.ReadValue<Vector2>();
        RaycastHit2D hit = Physics2D.Raycast(_mainCamera.ScreenToWorldPoint(touchPosition), Vector2.zero, Mathf.Infinity);
        
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.gameObject.name);
        }
    }
}
