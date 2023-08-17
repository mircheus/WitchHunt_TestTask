using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Reader.Games.Shooting
{
    public class ShootSystem : MonoBehaviour
    {
        [SerializeField] private Transform shootPoint;
        // [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private GameObject mainParent;
        [SerializeField] private BulletStorage bulletStorage;
    
        public void Shoot(Vector2 touchPosition)
        {
            Vector2 position = shootPoint.position;
            Vector2 direction = (touchPosition - position).normalized;
            // Bullet bullet = Instantiate(bulletPrefab, position, Quaternion.identity, mainParent.transform);
            // bullet.SetDirection(direction);
        }
    }
}

