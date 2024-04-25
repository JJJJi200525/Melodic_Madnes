using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public PlayerStats playerStats; 
    public Text healthText;
    public Text timeText;
    public Text levelText;

    private float startTime;

    void Start()
    {
        startTime = Time.time; // 初始化游戏开始时间
    }

    void Update()
    {
        HelathUpdate();
        Timer();
        LevelUpdate();
    }

    void HelathUpdate()
    {
        if (playerStats != null && healthText != null)
        {
            healthText.text = "HP: " + Mathf.RoundToInt(playerStats.currentHealth).ToString(); // 更新文本显示当前健康值
        }
    }

    void Timer()
    {
        if (timeText != null)
        {
            float timeElapsed = Time.time - startTime; 
            int minutes = Mathf.FloorToInt(timeElapsed / 60); 
            int seconds = Mathf.FloorToInt(timeElapsed % 60); 
            timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    void LevelUpdate()
    {
        if (levelText != null)
        {
            levelText.text = "Level: " + playerStats.experience + " / " + playerStats.experienceCap;
        }
    }
}
