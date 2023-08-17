using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Reader.Games.ShootingGame
{
    public class ShootSystem : MonoBehaviour
    {
        [SerializeField] private Transform shootPoint;
        [SerializeField] private GameObject mainParent;
        [SerializeField] private BulletStorage bulletStorage;
        [SerializeField] private Bullet bulletPrefab;
    
        public void Shoot(Vector2 touchPosition)
        {
            Vector2 position = shootPoint.position;
            Vector2 direction = (touchPosition - position).normalized;
            Bullet bullet = bulletStorage.GetBullet();
            // Bullet bullet = Instantiate(bulletPrefab, mainParent.transform);
            // Debug.Log(bullet == null);
            bullet.transform.position = shootPoint.position;
            bullet.SetDirection(direction);
            bullet.gameObject.SetActive(true);
        }
    }
}

