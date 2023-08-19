using System;
using System.Collections;
using System.Collections.Generic;
using Game.Reader.Games.ShootingGame;
using UnityEngine;

namespace Game.Reader.Games.ShootingGame
{
    public class WitchFxPlayer : MonoBehaviour
    {
        [SerializeField] private ParticleSystem leftSideDamageFx;
        [SerializeField] private ParticleSystem rightSideDamageFx;

        private WitchMovement _witchMovement;

        private void Start()
        {
            _witchMovement = GetComponent<WitchMovement>();
        }

        public void PlayGetDamageFx()
        {
            if (_witchMovement.IsMovingLeft)
            {
                leftSideDamageFx.Play();
            }
            else
            {
                rightSideDamageFx.Play();
            }
        }
    }
}
