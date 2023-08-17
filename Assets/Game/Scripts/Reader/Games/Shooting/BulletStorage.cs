using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Reader.Games.Shooting
{
    public class BulletStorage : MonoBehaviour
    {
        [SerializeField] private Bullet[] bullets;
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private int bulletCount;
        [SerializeField] private GameObject mainParent;

        private void Start()
        {
            InitializeStorage();
        }

        public Bullet GetBullet()
        {
            foreach (Bullet bullet in bullets)
            {
                if (bullet.gameObject.activeSelf == false)
                {
                    return bullet;
                }
            }

            return null;
        }

        private void InitializeStorage()
        {
            bullets = new Bullet[bulletCount];
            
            for(int i = 0; i < bulletCount; i++)
            {
                bullets[i] = Instantiate(bulletPrefab, transform);
                Debug.Log("Bullet created");
            }
        }
    }
}

