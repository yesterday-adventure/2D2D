using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effects : MonoBehaviour
{
    ParticleSystem particle;

    public void SpawnParticleEffect()
    {
        particle = EffectsManager.instance.GetParticle();  // EffectsManager에서 비활성화된 ParticleSystem을 가져옴
        Debug.Log(particle);
        // ParticleSystem을 구성 (위치, 회전 등)
        particle.transform.position = new Vector3(0f, 0f, 0f);

        particle.Play();  // ParticleSystem을 재생하여 효과 시작
        Debug.Log("Boom!");

        // ParticleSystem이 완료될 때까지 대기
    }

    protected virtual void OnParticleSystemStopped()        // particle의 생명 주기가 끝나면 호출되는 함수
    {
        Debug.Log("end");
        EffectsManager.instance.ReturnParticle(particle);  // 사용이 끝난 ParticleSystem을 EffectsManager에 반환하여 다시 객체 풀로 돌려줌
    }
}
