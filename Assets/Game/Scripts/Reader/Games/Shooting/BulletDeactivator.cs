using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Reader.Games.Shooting
{
    public class BulletDeactivator : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Bullet bullet))
            {
                bullet.gameObject.SetActive(false);
            }
        }
    }
}


