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
        [SerializeField] private GameObject mainParent;
        [SerializeField] private BulletPool bulletPool;
        [SerializeField] private Bullet bulletPrefab;

        private SlingshotAnimation _slingshotAnimation;
        
        private void Awake()
        {
            _slingshotAnimation = GetComponent<SlingshotAnimation>();
        }

        public void Shoot(Vector2 touchPosition)
        {
            Vector2 position = shootPoint.position;
            Vector2 direction = (touchPosition - position).normalized;
            Bullet bullet = bulletPool.GetBullet();
            // Bullet bullet = Instantiate(bulletPrefab, mainParent.transform);
            // Debug.Log(bullet == null);
            bullet.transform.position = shootPoint.position;
            bullet.SetDirection(direction);
            bullet.gameObject.SetActive(true);
            _slingshotAnimation.PlayShootAnimation();
        }
    }
}

