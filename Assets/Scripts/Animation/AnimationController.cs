using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void SetBoolean(string animationType, bool value)
    {
        _animator.SetBool(animationType,value);
    }
}
