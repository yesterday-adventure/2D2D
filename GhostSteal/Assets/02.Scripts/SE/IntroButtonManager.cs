using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroButtonManager : MonoBehaviour
{
    [SerializeField]
    private string nextScene;

    private void NextScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}
