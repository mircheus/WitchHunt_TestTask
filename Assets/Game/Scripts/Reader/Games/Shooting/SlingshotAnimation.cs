using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingshotAnimation : MonoBehaviour
{
    private Animator _animator;
    private int _prepareAnimation = Animator.StringToHash("Prepare"); 
    private int _shootAnimation = Animator.StringToHash("Shoot");
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayShootAnimation()
    {
        _animator.Play(_shootAnimation);
    }
}
