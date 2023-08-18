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
                _witchMovement.DecreaseSpeed();
                bullet.gameObject.SetActive(false);
                _witchAnimation.PlayGetDamageAnimation();
                _witchFxPlayer.PlayGetDamageFx();
                
                if (IsSpeedEqualZero())
                {
                    WitchDefeated?.Invoke();                    
                }
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

        private bool IsSpeedEqualZero() 
        {
            return _witchMovement.Speed == 0;
        }
    }
}

