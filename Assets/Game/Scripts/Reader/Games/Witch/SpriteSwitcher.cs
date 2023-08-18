using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Reader.Games.ShootingGame
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(WitchMovement))]
    public class SpriteSwitcher : MonoBehaviour
    {
        // [SerializeField] private Sprite damagedSprite;
        [SerializeField] private Sprite defaultSprite;
        // [SerializeField] private float spriteDelayTime;

        private Coroutine _currentChangeSpriteCoroutine;
        
        private SpriteRenderer _spriteRenderer;
        private WitchMovement _witchMovement;

        private void Awake()
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

