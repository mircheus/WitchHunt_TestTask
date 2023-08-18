using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Reader.Games.ShootingGame
{
    [RequireComponent(typeof(SpriteSwitcher))]
    [RequireComponent(typeof(WitchAnimation))]
    public class WitchMovement : MonoBehaviour
    {
        [SerializeField] private Transform[] leftTargetPoints;
        [SerializeField] private Transform[] rightTargetPoints;
        [SerializeField] private int currentPointIndex;
        [SerializeField] private float speed;
        [SerializeField] private float speedDecrease;
        
        private bool _isMovingLeft;
        private Vector2 _target;
        private SpriteSwitcher _spriteSwitcher;
        private WitchAnimation _witchAnimation;
        private WitchHealth _witchHealth;
        
        public bool IsMovingLeft => _isMovingLeft;
        
        private void Start()
        {
            _spriteSwitcher = GetComponent<SpriteSwitcher>();
            _witchAnimation = GetComponent<WitchAnimation>();
            _witchHealth = GetComponent<WitchHealth>();
            currentPointIndex = 0;
            _target = leftTargetPoints[currentPointIndex].position;
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
            SetRandomTargetFrom(rightTargetPoints);
            ChangeSpriteAndAnimation();
        }

        private void ChangeDirectionToLeft()
        {
            _isMovingLeft = true;
            SetRandomTargetFrom(leftTargetPoints);
            ChangeSpriteAndAnimation();
        }

        private void SetRandomTargetFrom(Transform[] sidePoints)
        {
            int randomIndex = Random.Range(0, sidePoints.Length);
            _target = sidePoints[randomIndex].position;
        }

        private void ChangeSpriteAndAnimation()
        {
            _spriteSwitcher.ChangeSpriteLookDirection(); 
            _witchAnimation.PlayTurnAnimation();
            _witchHealth.ChangeSideCollider();
        }
    }
}

