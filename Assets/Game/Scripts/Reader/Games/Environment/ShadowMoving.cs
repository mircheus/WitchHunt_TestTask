using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShadowMoving : MonoBehaviour
{
    [SerializeField] private BackgroundShadows _backgroundShadows;
    [SerializeField] private float speed;
    [SerializeField] private Transform leftPoint;
    [SerializeField] private Transform rightPoint;

    private Vector2 _target;

    private void Start()
    {
        _target = rightPoint.position;
        MoveShadows();
    }

    private void MoveShadows()
    {
        _backgroundShadows.transform.DOMove(_target, speed).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
    }
}
