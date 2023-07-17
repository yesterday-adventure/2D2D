using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectPoolable : MonoBehaviour
{

    EffectPoolable effectPoolable;
    public bool isUsing; // Ǯ�� ���
    Transform _root;

    protected virtual void OnParticleSystemStopped()         // particle�� ���� �ֱⰡ ������ ȣ��Ǵ� �Լ�
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
