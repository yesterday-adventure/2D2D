using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effects : MonoBehaviour
{
    ParticleSystem particle;

    public void SpawnParticleEffect()
    {
        particle = EffectsManager.instance.GetParticle();  // EffectsManager���� ��Ȱ��ȭ�� ParticleSystem�� ������
        Debug.Log(particle);
        // ParticleSystem�� ���� (��ġ, ȸ�� ��)
        particle.transform.position = new Vector3(0f, 0f, 0f);

        particle.Play();  // ParticleSystem�� ����Ͽ� ȿ�� ����
        Debug.Log("Boom!");

        // ParticleSystem�� �Ϸ�� ������ ���
    }

    protected virtual void OnParticleSystemStopped()        // particle�� ���� �ֱⰡ ������ ȣ��Ǵ� �Լ�
    {
        Debug.Log("end");
        EffectsManager.instance.ReturnParticle(particle);  // ����� ���� ParticleSystem�� EffectsManager�� ��ȯ�Ͽ� �ٽ� ��ü Ǯ�� ������
    }
}
