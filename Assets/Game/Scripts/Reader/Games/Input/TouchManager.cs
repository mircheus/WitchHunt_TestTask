using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Reader.Games.ShootingGame
{
    public class TouchManager : MonoBehaviour
    {
        [SerializeField] private InputAction screenPosition;
        [SerializeField] private InputAction press;
        [SerializeField] private ShootSystem shootSystem;

        private Camera _mainCamera;

        private void Start()
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
            Vector2 position = _mainCamera.ScreenToWorldPoint(touchPosition);
            shootSystem.Shoot(position);
        }
    }
}

