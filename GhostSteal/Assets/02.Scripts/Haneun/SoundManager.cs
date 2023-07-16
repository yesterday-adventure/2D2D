using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// �̱���



[System.Serializable]            // �ν�����â�� �����Ŵ
public class Sound
{
    public string soundName;     // �� �̸�
    public AudioClip clip;       // ��
}



public class SoundManager : MonoBehaviour
{
    static public SoundManager instance;        //�ڱ� �ڽ� ���� �ڿ�

    private void Awake()
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



    public Sound[] bgmSounds;           // BGM ����� Ŭ����
    public Sound[] effectSounds;        // ȿ���� ����� Ŭ����


    // AudioSource: �����
    public AudioSource audioSourceBgmPlayers;           // BGM ����� (���ÿ� ������ ��� X)
    public AudioSource[] audioSourceEffectsPlayers;     // ȿ���� �����

    public string[] playSoundName;                      // ��� ���� ȿ���� ���� �̸� 



    private void Start()
    {
        playSoundName = new string[audioSourceEffectsPlayers.Length];
    }



    public void PlaySE(string name)                                                     // name: �� �̸�
    {
        for (int i = 0; i < effectSounds.Length; i++)
        {
            // ���� ȿ���� �迭���� �Ȱ��� �̸��� ���� �ִ��� ã�� �˻��ϰ�
            if (name == effectSounds[i].soundName)
            {
                for (int j = 0; j < audioSourceEffectsPlayers.Length; j++)
                {
                    if (!audioSourceEffectsPlayers[j].isPlaying)                        // ��������� ���� ����⸦ ã����
                    {
                        audioSourceEffectsPlayers[j].clip = effectSounds[i].clip;       // clip: ����� Ŭ��
                        audioSourceEffectsPlayers[j].Play();                            //����� ���
                        playSoundName[j] = effectSounds[i].soundName;
                        return;
                    }
                }

                return;

            }
        }

        Debug.Log(name + "���尡 ���� �޴����� ��ϵ��� ����");
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

        Debug.Log(name + "���尡 ���� �Ŵ����� ��ϵ��� ����");
    }



    public void StopAllEffectsSound()               //��� ȿ���� ����
    {
        for (int i = 0; i < audioSourceEffectsPlayers.Length; i++)
        {
            audioSourceEffectsPlayers[i].Stop();
        }
    }



    public void StopEffectsSound(string name)       //Ư�� ȿ���� ����
    {
        for (int i = 0; i < audioSourceEffectsPlayers.Length; i++)
        {
            if (playSoundName[i] == name)
            {
                audioSourceEffectsPlayers[i].Stop();
                break;
            }
        }

        Debug.Log("������� " + name + "���尡 ����");

    }

}
