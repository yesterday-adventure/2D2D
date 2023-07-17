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

        public void init(GameObject original, int count = 5)        // 풀링할 오브젝트 개수
        {
            Original = original;        // UnityChan_Root 빈 오브젝트 생성. 
                                        // 원본 프리팹
            Root = new GameObject().transform; // 위에서 Root를 Transform으로 설정해놔서
                                               // Root: 풀링에 사용할 오브젝트들
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

        public void Push(EffectPoolable effectPoolable)   // 오브젝트 비활성화
        {
            if (effectPoolable == null)
            {
                return;
                // 없다면 바로 끝낸다.
            }
            effectPoolable.transform.parent = Root;

            // 영상 꺼놓는 부분
            effectPoolable.gameObject.SetActive(false);
            effectPoolable.isUsing = false;

            // 이렇게까지해서 설정이 완료되었으니 stack에 넣어주면된다.
            _poolStack.Push(effectPoolable);

        }

        public EffectPoolable Pop(Transform parent)     // 오브젝트 활성화
        {
            EffectPoolable effectPoolable;

            if (_poolStack.Count > 0)
                effectPoolable = _poolStack.Pop();
            else
                effectPoolable = Create();

            effectPoolable.gameObject.SetActive(true);

            // DontDestroyOnLoad 해제 용도
            // 한번이라도 DontDestroyOnLoad 위로 이동을 했다면 정상적으로 잘 작동을 할것이다.
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
        Pool pool = new Pool(); // 새로운 class생성
        pool.init(original, count);
        pool.Root.parent = _root;
        // 현재 _root가 Transform 이니까 pool.Root.parent = _root.trnasform이랑 같은 말이다.

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
