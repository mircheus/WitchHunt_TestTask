using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Reader.Games.ShootingGame
{
    public class WitchMovement : MonoBehaviour
    {
        [SerializeField] private Transform[] leftMovingPoints;
        [SerializeField] private Transform[] rightMovingPoints;
        [SerializeField] private int currentPointIndex;
        [SerializeField] private float speed;
        [SerializeField] private float speedDecrease;
        
        private bool _isMovingLeft;
        private Vector2 _target;

        private void Start()
        {
            currentPointIndex = 0;
            _target = leftMovingPoints[currentPointIndex].position;
            _isMovingLeft = true;
        }

        private void Update()
        {
            Move();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out Point point))
            {
                ChangeTarget();
            }
        }

        public void DecreaseSpeed()
        {
            speed -= speedDecrease;
            
            if (speed <= 0)
            {
                speed = 0;
            }
        }

        private void Move()
        {
            transform.position = Vector2.MoveTowards(transform.position, _target, speed * Time.deltaTime);
        }

        private void ChangeTarget()
        {
            if (_isMovingLeft)
            {
                ChangeDirectionToRight();
            }
            else
            {
                ChangeDirectionToLeft();
            }
        }
        
        private void ChangeDirectionToRight()
        {
            _isMovingLeft = false;
            int randomIndex = Random.Range(0, rightMovingPoints.Length);
            _target = rightMovingPoints[randomIndex].position;
        }

        private void ChangeDirectionToLeft()
        {
            _isMovingLeft = true;
            int randomIndex = Random.Range(0, leftMovingPoints.Length);
            _target = leftMovingPoints[randomIndex].position;
        }
    }
}

