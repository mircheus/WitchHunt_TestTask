using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Reader.Games.ShootingGame
{
    public class WitchAnimation : MonoBehaviour
    {
        private Animator _animator;
        private int _turnAnimation = Animator.StringToHash("Turn");
        private int _getDamageAnimation = Animator.StringToHash("GetDamage");
    
        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public void PlayTurnAnimation()
        {
            _animator.Play(_turnAnimation);
        }
    
        public void PlayGetDamageAnimation()
        {
            _animator.Play(_getDamageAnimation);
        }
    }
}