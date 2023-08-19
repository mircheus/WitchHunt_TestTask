using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Reader.Games.ShootingGame
{
    public class Point : MonoBehaviour
    {
        [SerializeField] private bool _isLeftPoint;
        
        public bool IsLeftPoint => _isLeftPoint;
    }
}

