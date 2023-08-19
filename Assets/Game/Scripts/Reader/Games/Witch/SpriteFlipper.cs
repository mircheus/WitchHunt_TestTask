using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Reader.Games.ShootingGame
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(WitchMovement))]
    public class SpriteFlipper : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;
        private WitchMovement _witchMovement;

        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _witchMovement = GetComponent<WitchMovement>();
        }

        public void ChangeSpriteLookDirection()
        {
            if (_witchMovement.IsMovingLeft)
            {
                UnflipSpriteByX();
            }
            else
            {
                FlipSpriteByX();
            }
        }

        private void FlipSpriteByX()
        {
            _spriteRenderer.flipX = true;
        }
        
        private void UnflipSpriteByX()
        {
            _spriteRenderer.flipX = false;
        }
    } 
}

