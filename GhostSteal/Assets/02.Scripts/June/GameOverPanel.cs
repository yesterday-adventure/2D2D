using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{
    public void Re()
    {
        SceneManager.LoadScene("Play");
    }

    public void Exit()
    {
        SceneManager.LoadScene("Intro");
    }
}
