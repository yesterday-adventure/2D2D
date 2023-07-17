using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectPoolable : MonoBehaviour
{

    EffectPoolable effectPoolable;
    public bool isUsing; // 풀링 대상
    Transform _root;

    protected virtual void OnParticleSystemStopped()         // particle의 생명 주기가 끝나면 호출되는 함수
    {

    }

    public void Init()
    {
        if (_root == null)
        {
            _root = new GameObject { name = "EffectPoolable" }.transform;
            Object.DontDestroyOnLoad(_root);
        }
    }

    public void Push()
    {

    }

    public void Pop()
    {

    }
}
