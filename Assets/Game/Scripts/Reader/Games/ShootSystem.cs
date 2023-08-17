using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSystem : MonoBehaviour
{
    [SerializeField] private Transform shootTransform;
    [SerializeField] private Bullet bulletPrefab;
    
    public void Shoot(Vector2 touchPosition)
    {
        var position = shootTransform.position;
        Vector2 direction = (touchPosition - (Vector2)position).normalized;
        Instantiate(bulletPrefab, position, Quaternion.identity);
    }
}
