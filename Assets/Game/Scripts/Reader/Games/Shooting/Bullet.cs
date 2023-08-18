using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Reader.Games.ShootingGame
{
    public class Bullet : MonoBehaviour
    {   
        [SerializeField] private float speed;
        [SerializeField] private float rotationSpeed;
        [SerializeField] private float scaleDecreaseModifier;
        [SerializeField] private int damage;
        [SerializeField] private Vector3 defaultScale;
        
        private Vector2 _direction;
        
        public int Damage => damage;

        private void OnEnable()
        {
            transform.localScale = defaultScale;
        }
        
        private void Update()
        {
            Move();
            Rotate();
            DecraseScale();
        }
    
        public void SetDirection(Vector2 direction)
        {
            _direction = direction;
        }

        private void Move()
        {
            transform.Translate(_direction  * speed * Time.deltaTime, Space.World);
        }

        private void Rotate()
        {
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime, Space.Self);
        }
        
        private void DecraseScale()
        {
            transform.localScale -= Vector3.one * scaleDecreaseModifier * Time.deltaTime;

            if (transform.localScale.x <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
}

