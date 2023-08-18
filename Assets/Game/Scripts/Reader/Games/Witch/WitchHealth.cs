using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Reader.Games.ShootingGame
{
    [RequireComponent(typeof(WitchMovement))]
    [RequireComponent(typeof(WitchAnimation))]
    [RequireComponent(typeof(WitchFxPlayer))]
    public class WitchHealth : MonoBehaviour
    {
        [SerializeField] private int health;
        
        private WitchMovement _witchMovement;
        private WitchAnimation _witchAnimation;
        private WitchFxPlayer _witchFxPlayer;

        public event Action WitchDefeated;

        private void Awake()
        {
            _witchMovement = GetComponent<WitchMovement>();
            _witchAnimation = GetComponent<WitchAnimation>();
            _witchFxPlayer = GetComponent<WitchFxPlayer>();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out Bullet bullet))
            {
                TakeDamage(bullet.Damage);
                _witchMovement.DecreaseSpeed();
                bullet.gameObject.SetActive(false); 
                _witchAnimation.PlayGetDamageAnimation();
                _witchFxPlayer.PlayGetDamageFx();
            }
        }

        private void TakeDamage(int damage)
        {
            health -= damage;

            if (health <= 0)
            {
                // WitchDefeated?.Invoke();
                Debug.Log("Witch defeated");
            }
        }
    }
}

