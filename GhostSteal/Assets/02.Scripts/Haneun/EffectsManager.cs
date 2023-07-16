using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EffectsManager : MonoBehaviour
{
    static public EffectsManager instance;        // Singleton

    public UnityEvent unityEvent;

    public int poolSize = 10;
    //public ParticleSystem[] effects;            // effect �迭�� �Է¹���... �̿�����
                                                  // �迭�� �Է¹��� �ʰ� enum���� ó���� ��
                                                // object pool �� �θ�-�ڽ����� �޾� ����ϴ°Ŵ�...


    List<ParticleSystem> particlePool;  // ��Ȱ��ȭ�� ParticleSystem�� ������ ��ü Ǯ
    List<ParticleSystem> activeParticles;  // Ȱ��ȭ�� ParticleSystem�� ������ ����Ʈ


    private void Awake()
    {
        Singleton();

        ParticleSystem[] particleSystems = GetComponents<ParticleSystem>();

        particlePool = new List<ParticleSystem>();
        activeParticles = new List<ParticleSystem>();

        for (int i = 0; i < poolSize; i++)
        {
            CreateParticle();    // �ʱ� ��ü Ǯ ũ�⿡ �°� ��Ȱ��ȭ�� ParticleSystem�� �����Ͽ� ��ü Ǯ�� �߰�
        }

        transform.position = new Vector3(0f, 0f, 0f);       // ��ġ �ʱ�ȭ
    }

    void Singleton()
    {
        if (instance == null)                   // ���� ����(�ϳ��� ����)
        {
            instance = this;                    // �ڱ� �ڽ� �Ҵ�
            DontDestroyOnLoad(gameObject);      // ���� ��ȯ�Ǿ �ı����� ����
        }

        else                                    // �� �ϳ��� �����ϰԲ� ���� ���� Sound Manager ������Ʈ �ν��Ͻ��� ��쿣 �ı�
        {
            Destroy(this.gameObject);
        }
    }

    void CreateParticle()
    {
        // enum
        
        //ParticleSystem newParticle = Instantiate(effects[0]);   // ParticleSystem �������� �����Ͽ� ���ο� ParticleSystem ����
        //newParticle.gameObject.SetActive(false);   // ������ ParticleSystem�� ��Ȱ��ȭ
        //particlePool.Add(newParticle);   // ��Ȱ��ȭ�� ParticleSystem�� ��ü Ǯ�� �߰�
    }

    public ParticleSystem GetParticle()
    {
        if (particlePool.Count == 0)
        {
            // ��ü Ǯ�� ����ִ� ��� ���ο� ParticleSystem�� �����Ͽ� ��ü Ǯ�� �߰�
            CreateParticle();
        }

        ParticleSystem particle = particlePool[0];   // ��ü Ǯ���� ù ��° ��Ȱ��ȭ�� ParticleSystem�� ������
        particlePool.RemoveAt(0);   // ������ ParticleSystem�� ��ü Ǯ���� ����
        particle.gameObject.SetActive(true);   // ������ ParticleSystem�� Ȱ��ȭ
        activeParticles.Add(particle);   // Ȱ��ȭ�� ParticleSystem�� �����ϱ� ���� ����Ʈ�� �߰�

        return particle;   // ������ ParticleSystem ��ȯ
    }

    public void ReturnParticle(ParticleSystem particle)
    {
        // Destroy(gameObject); // Ǯ�Ŵ��� �߰��ϸ鼭 ��ġ��
        Debug.Log(particle.name);
        activeParticles.Remove(particle);   // ����� ���� ParticleSystem�� �����ϴ� ����Ʈ���� ����
        particlePool.Add(particle);   // ����� ���� ParticleSystem�� �ٽ� ��ü Ǯ�� �߰�
        particle.gameObject.SetActive(false);   // ����� ���� ParticleSystem�� ��Ȱ��ȭ
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            unityEvent?.Invoke();
        }

    }
}
