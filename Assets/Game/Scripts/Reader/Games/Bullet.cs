using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{   
    [SerializeField] private float speed;
    private Vector2 _direction;

    private void Update()
    {
        transform.Translate(_direction  * speed * Time.deltaTime, Space.World);
        // transform.position = Vector2.MoveTowards(transform.position, _direction, speed * Time.deltaTime);
    }
    
    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
        Debug.Log(direction);
    }
}
