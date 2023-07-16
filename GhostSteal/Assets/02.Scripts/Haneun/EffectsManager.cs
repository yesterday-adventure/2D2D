using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EffectsManager : MonoBehaviour
{
    static public EffectsManager instance;        // Singleton

    public UnityEvent unityEvent;

    public int poolSize = 10;
    //public ParticleSystem[] effects;            // effect 배열로 입력받음... 이였으나
                                                  // 배열오 입력받지 않고 enum으로 처리할 것
                                                // object pool 은 부모-자식으로 받아 사용하는거다...


    List<ParticleSystem> particlePool;  // 비활성화된 ParticleSystem을 보관할 객체 풀
    List<ParticleSystem> activeParticles;  // 활성화된 ParticleSystem을 추적할 리스트


    private void Awake()
    {
        Singleton();

        ParticleSystem[] particleSystems = GetComponents<ParticleSystem>();

        particlePool = new List<ParticleSystem>();
        activeParticles = new List<ParticleSystem>();

        for (int i = 0; i < poolSize; i++)
        {
            CreateParticle();    // 초기 객체 풀 크기에 맞게 비활성화된 ParticleSystem을 생성하여 객체 풀에 추가
        }

        transform.position = new Vector3(0f, 0f, 0f);       // 위치 초기화
    }

    void Singleton()
    {
        if (instance == null)                   // 최초 생성(하나만 존재)
        {
            instance = this;                    // 자기 자신 할당
            DontDestroyOnLoad(gameObject);      // 씬이 전환되어도 파괴되지 않음
        }

        else                                    // 단 하나만 존재하게끔 새로 생긴 Sound Manager 오브젝트 인스턴스일 경우엔 파괴
        {
            Destroy(this.gameObject);
        }
    }

    void CreateParticle()
    {
        // enum
        
        //ParticleSystem newParticle = Instantiate(effects[0]);   // ParticleSystem 프리팹을 복제하여 새로운 ParticleSystem 생성
        //newParticle.gameObject.SetActive(false);   // 생성된 ParticleSystem을 비활성화
        //particlePool.Add(newParticle);   // 비활성화된 ParticleSystem을 객체 풀에 추가
    }

    public ParticleSystem GetParticle()
    {
        if (particlePool.Count == 0)
        {
            // 객체 풀이 비어있는 경우 새로운 ParticleSystem을 생성하여 객체 풀에 추가
            CreateParticle();
        }

        ParticleSystem particle = particlePool[0];   // 객체 풀에서 첫 번째 비활성화된 ParticleSystem을 가져옴
        particlePool.RemoveAt(0);   // 가져온 ParticleSystem을 객체 풀에서 제거
        particle.gameObject.SetActive(true);   // 가져온 ParticleSystem을 활성화
        activeParticles.Add(particle);   // 활성화된 ParticleSystem을 추적하기 위해 리스트에 추가

        return particle;   // 가져온 ParticleSystem 반환
    }

    public void ReturnParticle(ParticleSystem particle)
    {
        // Destroy(gameObject); // 풀매니저 추가하면서 고치기
        Debug.Log(particle.name);
        activeParticles.Remove(particle);   // 사용이 끝난 ParticleSystem을 추적하는 리스트에서 제거
        particlePool.Add(particle);   // 사용이 끝난 ParticleSystem을 다시 객체 풀에 추가
        particle.gameObject.SetActive(false);   // 사용이 끝난 ParticleSystem을 비활성화
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            unityEvent?.Invoke();
        }

    }
}
