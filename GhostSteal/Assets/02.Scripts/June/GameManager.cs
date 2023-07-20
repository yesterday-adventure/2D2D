using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("게임 관련")]
    public bool isLight = true;
    public GameObject player;
    public Vector2 resetPos;

    [Header("게임오버")]
    [SerializeField] GameObject gameOverPanel;
    public bool isGameOver = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Debug.LogError($"{transform} : GameManager is Multiple");

        player = GameObject.Find("Player");

        resetPos = GameObject.Find("resetPos").transform.position;
        
        Init();
    }

    public void Init()
    {
        player.transform.position = resetPos;
        isGameOver = false;
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        isGameOver = true;
    }
}
