using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 싱글톤



[System.Serializable]            // 인스펙터창에 노출시킴
public class Sound
{
    public string soundName;     // 곡 이름
    public AudioClip clip;       // 곡
}



public class SoundManager : MonoBehaviour
{
    static public SoundManager instance;        //자기 자신 공유 자원

    private void Awake()
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



    public Sound[] bgmSounds;           // BGM 오디오 클립들
    public Sound[] effectSounds;        // 효과음 오디오 클립들


    // AudioSource: 재생기
    public AudioSource audioSourceBgmPlayers;           // BGM 재생기 (동시에 여러개 재생 X)
    public AudioSource[] audioSourceEffectsPlayers;     // 효과음 재생기

    public string[] playSoundName;                      // 재생 중인 효과음 사운드 이름 



    private void Start()
    {
        playSoundName = new string[audioSourceEffectsPlayers.Length];
    }



    public void PlaySE(string name)                                                     // name: 곡 이름
    {
        for (int i = 0; i < effectSounds.Length; i++)
        {
            // 만약 효과음 배열에서 똑같은 이름의 곡이 있는지 찾아 검사하고
            if (name == effectSounds[i].soundName)
            {
                for (int j = 0; j < audioSourceEffectsPlayers.Length; j++)
                {
                    if (!audioSourceEffectsPlayers[j].isPlaying)                        // 재생중이지 않은 재생기를 찾으면
                    {
                        audioSourceEffectsPlayers[j].clip = effectSounds[i].clip;       // clip: 오디오 클립
                        audioSourceEffectsPlayers[j].Play();                            //오디오 재생
                        playSoundName[j] = effectSounds[i].soundName;
                        return;
                    }
                }

                return;

            }
        }

        Debug.Log(name + "사운드가 사운드 메니저에 등록되지 않음");
    }



    public void PlayBGM(string name)
    {
        for (int i = 0; i < bgmSounds.Length; i++)
        {
            if (name == bgmSounds[i].soundName)
            {
                audioSourceBgmPlayers.clip = bgmSounds[i].clip;
                audioSourceBgmPlayers.Play();
                return;
            }
        }

        Debug.Log(name + "사운드가 사운드 매니저에 등록되지 않음");
    }



    public void StopAllEffectsSound()               //모든 효과음 끄기
    {
        for (int i = 0; i < audioSourceEffectsPlayers.Length; i++)
        {
            audioSourceEffectsPlayers[i].Stop();
        }
    }



    public void StopEffectsSound(string name)       //특정 효과음 끄기
    {
        for (int i = 0; i < audioSourceEffectsPlayers.Length; i++)
        {
            if (playSoundName[i] == name)
            {
                audioSourceEffectsPlayers[i].Stop();
                break;
            }
        }

        Debug.Log("재생중인 " + name + "사운드가 없음");

    }

}
