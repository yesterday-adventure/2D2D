using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EffectResourceManager : MonoBehaviour
{
    public T Load<T>(string path) where T : UnityEngine.Object
    {
        if (typeof(T) == typeof(GameObject))        // ���� Ÿ���� ������Ʈ���
        {
            string name = path;
            int index = name.LastIndexOf('/');

            if (index >= 0)
            {
                name = name.Substring(index + 1);
            }

            //GameObject go = EffectPoolManager.Pool.GetOriginal(name);
            //if (go != null)
            //{
            //    return go as T;
            //}  
        }
        return Resources.Load<T>(path);
    }

    public GameObject Instantiate(string path, Transform parent = null)
    {
        // 1. original �̹� ��������� �ٷ� ��� => ������ Load�κп���
        GameObject original = Load<GameObject>($"Prefabs/{path}");
        if (original == null)
        {
            Debug.Log($"Fail to load prefab : {path}");
            return null;
        }

        // 2. Ȥ�� Ǯ���� �ְ� ������? 
        //if (original.GetComponent<EffectPoolable>() != null) // ���ٸ� �����ϰ� ������� ���ư��� �ɰ��̴�.
        //    return EffectPoolManager.Pool.Pop(original, parent).gameObject;

        GameObject go = UnityEngine.Object.Instantiate(original, parent);

        //int index = go.name.IndexOf("(Clone)");
        //if (index > 0)
        //    go.name = go.name.Substring(0, index);
        // ���� 3���̶� go.name = original.name;�̶� �������̴�.

        //GameObject go = Object.Instantiate(original, parent); �̷����ϴ°Ŷ� UnityEngine.Object.Instantiate(original, parent); �̰Ŷ� ����
        go.name = original.name;
        return go;
    }

    public void Destroy(GameObject go)
    {
        if (go == null)
            return;

        // 3. �ʿ���ٰ� �ٷ� ���ִ°��� �ƴ϶�(Ǯ���� �ʿ��� ���̶��) -> Ǯ���Ŵ������� ��Ź�� ���ش�.
        EffectPoolable poolable = go.GetComponent<EffectPoolable>();
        if (poolable != null)
        {
            //EffectPoolManager.Pool.Push(poolable);
            return;
        }

        UnityEngine.Object.Destroy(go);
        //Object.Destrot(go);
    }
}