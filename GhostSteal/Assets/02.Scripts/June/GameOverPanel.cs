using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{
    public void Re()
    {
        GameManager.Instance.Init();
        transform.gameObject.SetActive(false);
    }

    public void Exit()
    {
        SceneManager.LoadScene("Intro");
    }
}
