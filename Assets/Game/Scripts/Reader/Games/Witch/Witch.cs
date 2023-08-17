using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Reader.Games.ShootingGame
{
    [RequireComponent(typeof(WitchMovement))]
    public class Witch : MonoBehaviour
    {
        private WitchMovement _witchMovement;

        private void Awake()
        {
            _witchMovement = GetComponent<WitchMovement>();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out Bullet bullet))
            {
                _witchMovement.DecreaseSpeed();
                bullet.gameObject.SetActive(false);
            }
        }
    }
}

