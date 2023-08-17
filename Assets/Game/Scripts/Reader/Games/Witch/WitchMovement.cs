using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Reader.Games.ShootingGame
{
    public class WitchMovement : MonoBehaviour
    {
        [SerializeField] private Transform point1;
        [SerializeField] private Transform point2;
        [SerializeField] private float speed;
        
        private Vector2 _target;

        private void Start()
        {
            _target = point1.position;
        }

        private void Update()
        {
            Move();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            throw new NotImplementedException();
        }

        private void Move()
        {
            transform.position = Vector2.MoveTowards(transform.position, _target, speed * Time.deltaTime);
            
            if (Vector2.Distance(transform.position, _target) < 0.1f)
            {
                ChangeTarget();
            }
        }

        private void ChangeTarget()
        {
            _target = point2.position;
        }
    }
}

