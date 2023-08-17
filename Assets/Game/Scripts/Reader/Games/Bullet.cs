using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{   
    private Vector2 _direction;

    private void Update()
    {
        transform.Translate(_direction * Time.deltaTime);
    }
    
    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }
}
