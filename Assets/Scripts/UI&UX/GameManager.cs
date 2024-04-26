using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerStats playerStats;
    public Text maxHealth;
    public Text recovery;
    public Text speed;

    public GameObject pauseMenu; 
    public GameObject upgradeMenu;

    void Update()
    {
        InfoUpdate();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }

    // ��ͣ��Ϸ����ʾ��ͣ�˵�
    public void Pause()
    {
        pauseMenu.SetActive(true); // ��ʾ��ͣ�˵�
        Time.timeScale = 0; // ��ͣ��Ϸʱ��
    }

    // ������Ϸ��������ͣ�˵�
    public void Resume()
    {
        pauseMenu.SetActive(false); // ������ͣ�˵�
        Time.timeScale = 1; // �ָ���Ϸʱ��
    }

    public void BackToMenu()
    {
        // Loading scene called "MainGame"
        SceneManager.LoadScene("Menu");
    }

    void InfoUpdate()
    {
        maxHealth.text = "MaxHealth:" + playerStats.currentHealth.ToString();
        recovery.text = "Recovery:" + playerStats.currentRecovery.ToString();
        speed.text = "Speed:" + playerStats.currentMoveSpeed.ToString();
    }
}

