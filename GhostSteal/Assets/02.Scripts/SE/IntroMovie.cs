using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroMovie : MonoBehaviour
{
    [SerializeField]
    private bool init = false;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("introMovie")/* || PlayerPrefs.GetInt("introMovie") == 0*/)
        {
            // 처음 시작한 경우
            Debug.Log("처음 시작한 것이므로 인트로무비 영상 재생.");
            // 인트로무비 영상 재생하기

            PlayerPrefs.SetInt("introMovie", 1);

            SceneManager.LoadScene("Moves");
        }
    }

    private void Update()
    {
        if (init)
        {
            //PlayerPrefs.SetInt("introMovie", 0);
            //PlayerPrefs.DeleteKey("introMovie");
            PlayerPrefs.DeleteAll();
            //Debug.Log("다시 확인용으로 초기화 해줌");
            Debug.Log("다시 확인용으로 데이터 지워줌. 다시 플레이 시 인트로무비 재생됨.");
            init = false;
        }
    }
}
