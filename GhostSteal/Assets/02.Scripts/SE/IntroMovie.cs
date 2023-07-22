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
            // ó�� ������ ���
            Debug.Log("ó�� ������ ���̹Ƿ� ��Ʈ�ι��� ���� ���.");
            // ��Ʈ�ι��� ���� ����ϱ�

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
            //Debug.Log("�ٽ� Ȯ�ο����� �ʱ�ȭ ����");
            Debug.Log("�ٽ� Ȯ�ο����� ������ ������. �ٽ� �÷��� �� ��Ʈ�ι��� �����.");
            init = false;
        }
    }
}
