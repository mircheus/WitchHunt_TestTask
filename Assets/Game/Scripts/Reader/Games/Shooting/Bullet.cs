using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Reader.Games.ShootingGame
{
    public class Bullet : MonoBehaviour
    {   
        [SerializeField] private float speed;
        [SerializeField] private int damage;

        private Vector2 _direction;

        public int Damage => damage;
        
        private void Update()
        {
            transform.Translate(_direction  * speed * Time.deltaTime, Space.World);
        }
    
        public void SetDirection(Vector2 direction)
        {
            _direction = direction;
        }
    }
}

