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
        [SerializeField] private BoxCollider2D _leftSideCollider;
        [SerializeField] private BoxCollider2D _rightSideCollider;
        
        private WitchMovement _witchMovement;
        private WitchAnimation _witchAnimation;
        private WitchFxPlayer _witchFxPlayer;

        public event Action WitchDefeated;

        private void Awake()
        {
            _witchMovement = GetComponent<WitchMovement>();
            _witchAnimation = GetComponent<WitchAnimation>();
            _witchFxPlayer = GetComponent<WitchFxPlayer>();
            ChangeSideCollider();
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
        
        public void ChangeSideCollider()
        {
            if (_witchMovement.IsMovingLeft)
            {
                _leftSideCollider.enabled = true;
                _rightSideCollider.enabled = false;
            }
            else
            {
                _leftSideCollider.enabled = false;
                _rightSideCollider.enabled = true;
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
