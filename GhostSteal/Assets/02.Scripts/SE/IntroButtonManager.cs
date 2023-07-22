using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class IntroButtonManager : MonoBehaviour
{
    [SerializeField]
    private Image Panel;

    private void Start()
    {
        Panel.DOFade(0, 1.5f);
        StartCoroutine(PanelWait(1.5f));
    }

    IEnumerator PanelWait(float time)
    {
        yield return new WaitForSeconds(time);
        Panel.gameObject.SetActive(false);
    }

    public void NextScene(string nextScene)
    {
        StartCoroutine(SceneGo(nextScene));
        Panel.gameObject.SetActive(true);
        Panel.DOFade(1, 1);
    }

    IEnumerator SceneGo(string nextScene)
    {
        yield return new WaitForSeconds(1.5f);
        PlayerPrefs.DeleteKey("X");
        PlayerPrefs.DeleteKey("Y");
        SceneManager.LoadScene(nextScene);  // 지정해준 씬으로 이동함

    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 어플리케이션 종료
#endif
    }
}
