using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Reader.Games.ShootingGame
{
    [RequireComponent(typeof(WitchMovement))]
    public class WitchHealth : MonoBehaviour
    {
        [SerializeField] private int health;
        
        private WitchMovement _witchMovement;

        public event Action WitchDefeated;

        private void Awake()
        {
            _witchMovement = GetComponent<WitchMovement>();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out Bullet bullet))
            {
                TakeDamage(bullet.Damage);
                _witchMovement.DecreaseSpeed();
                bullet.gameObject.SetActive(false);
            }
        }

        private void TakeDamage(int damage)
        {
            health -= damage;

            if (health <= 0)
            {
                WitchDefeated?.Invoke();
            }
        }
    }
}

