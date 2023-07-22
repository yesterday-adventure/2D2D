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
        SceneManager.LoadScene(nextScene);  // �������� ������ �̵���

    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // ���ø����̼� ����
#endif
    }
}
