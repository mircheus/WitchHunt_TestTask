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
        // [SerializeField] private GameObject mainParent;
        [SerializeField] private BulletPool bulletPool;
        // [SerializeField] private Bullet bulletPrefab;

        private SlingshotAnimation _slingshotAnimation;
        private bool _isAbleToShoot = true;
        
        private void Awake()
        {
            _slingshotAnimation = GetComponent<SlingshotAnimation>();
        }

        public void Shoot(Vector2 touchPosition)
        {
            if (_isAbleToShoot)
            {
                Vector2 shootPointPosition = shootPoint.position;
                Vector2 direction = (touchPosition - shootPointPosition).normalized;
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
    }
}

