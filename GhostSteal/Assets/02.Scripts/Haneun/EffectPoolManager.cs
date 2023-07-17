using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EffectPoolManager : MonoBehaviour
{
    #region Pool
    public class Pool
    {
        public GameObject Original;
        public Transform Root;

        Stack<EffectPoolable> _poolStack = new Stack<EffectPoolable>();

        public void init(GameObject original, int count = 5)        // Ǯ���� ������Ʈ ����
        {
            Original = original;        // UnityChan_Root �� ������Ʈ ����. 
                                        // ���� ������
            Root = new GameObject().transform; // ������ Root�� Transform���� �����س���
                                               // Root: Ǯ���� ����� ������Ʈ��
            Root.name = $"{original.name}Particle";

            for (int i = 0; i < 5; i++)
            {
                Push(Create());
            }
        }

        EffectPoolable Create()
        {
            GameObject go = Object.Instantiate<GameObject>(Original);
            go.name = Original.name;
            return go.GetOrAddComponent<EffectPoolable>();

        }

        public void Push(EffectPoolable effectPoolable)   // ������Ʈ ��Ȱ��ȭ
        {
            if (effectPoolable == null)
            {
                return;
                // ���ٸ� �ٷ� ������.
            }
            effectPoolable.transform.parent = Root;

            // ���� ������ �κ�
            effectPoolable.gameObject.SetActive(false);
            effectPoolable.isUsing = false;

            // �̷��Ա����ؼ� ������ �Ϸ�Ǿ����� stack�� �־��ָ�ȴ�.
            _poolStack.Push(effectPoolable);

        }

        public EffectPoolable Pop(Transform parent)     // ������Ʈ Ȱ��ȭ
        {
            EffectPoolable effectPoolable;

            if (_poolStack.Count > 0)
                effectPoolable = _poolStack.Pop();
            else
                effectPoolable = Create();

            effectPoolable.gameObject.SetActive(true);

            // DontDestroyOnLoad ���� �뵵
            // �ѹ��̶� DontDestroyOnLoad ���� �̵��� �ߴٸ� ���������� �� �۵��� �Ұ��̴�.
            //if (parent == null)
            //    effectPoolable.transform.parent = Manager.Scene.CurrenScene.transform;

            effectPoolable.transform.parent = parent;
            effectPoolable.isUsing = true;

            return effectPoolable;

        }
    }
    #endregion

    Dictionary<string, Pool> _pool = new Dictionary<string, Pool>();

    Transform _root;

    public void init()
    {
        if (_root == null)
        {
            _root = new GameObject { name = "EffectPoolable" }.transform;
            Object.DontDestroyOnLoad(_root);
        }
    }

    public void CreatePool(GameObject original, int count = 5)
    {
        Pool pool = new Pool(); // ���ο� class����
        pool.init(original, count);
        pool.Root.parent = _root;
        // ���� _root�� Transform �̴ϱ� pool.Root.parent = _root.trnasform�̶� ���� ���̴�.

        _pool.Add(original.name, pool);
    }

    public void Push(EffectPoolable effectPoolable)
    {
        string name = effectPoolable.gameObject.name;

        if (_pool.ContainsKey(name) == false)
        {
            GameObject.Destroy(effectPoolable.gameObject);
            return;
        }

        _pool[name].Push(effectPoolable);
    }

    public EffectPoolable Pop(GameObject original, Transform parent = null)
    {
        if (_pool.ContainsKey(original.name) == false)
        {
            CreatePool(original);
        }

        return _pool[original.name].Pop(parent);
    }

    public GameObject GetOriginal(string name)
    {
        if (_pool.ContainsKey(name) == false)
        {
            return null;
        }

        return _pool[name].Original;
    }

    public void Clear()
    {
        foreach (Transform child in _root)
            GameObject.Destroy(child.gameObject);

        _pool.Clear();
    }

    
}
