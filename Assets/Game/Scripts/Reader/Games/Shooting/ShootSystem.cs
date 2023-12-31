using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Reader.Games.ShootingGame
{
    [RequireComponent(typeof(SlingshotAnimation))]
    public class ShootSystem : MonoBehaviour
    {
        [SerializeField] private Transform shootPoint;
        [SerializeField] private BulletPool bulletPool;
        
        private SlingshotAnimation _slingshotAnimation;
        private bool _isAbleToShoot = true;
        private float _clampedY = 0.2f;
        
        private void Start()
        {
            _slingshotAnimation = GetComponent<SlingshotAnimation>();
        }

        public void Shoot(Vector2 touchPosition)
        {
            if (_isAbleToShoot)
            {
                Vector2 shootPointPosition = shootPoint.position;
                Vector2 direction = (touchPosition - shootPointPosition).normalized;
                direction = ClampDirectionByY(direction);
                Bullet bullet = bulletPool.GetBullet();
                bullet.transform.position = shootPointPosition;
                bullet.SetDirection(direction);
                bullet.gameObject.SetActive(true);
                _slingshotAnimation.PlayShootAnimation();
                _isAbleToShoot = false;
            }
        }
        
        public void EnableShootAbility()
        {
            _isAbleToShoot = true;
        }

        private Vector2 ClampDirectionByY(Vector2 direction)
        {
            if (direction.y < _clampedY)
            {
                Vector2 newDirection = new Vector2(direction.x, _clampedY);
                return newDirection;
            }
            
            return direction;
        }
    }
}

