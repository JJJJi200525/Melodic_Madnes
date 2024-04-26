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

    // 暂停游戏并显示暂停菜单
    public void Pause()
    {
        pauseMenu.SetActive(true); // 显示暂停菜单
        Time.timeScale = 0; // 暂停游戏时间
    }

    // 继续游戏并隐藏暂停菜单
    public void Resume()
    {
        pauseMenu.SetActive(false); // 隐藏暂停菜单
        Time.timeScale = 1; // 恢复游戏时间
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

