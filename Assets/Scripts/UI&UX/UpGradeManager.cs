using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public PlayerStats playerStats;
    public GameObject upgradeCanvas; // 升级Canvas的引用

    void Awake()
    {
        upgradeCanvas.SetActive(false); // 确保游戏开始时Canvas是不活跃的
    }

    // 显示升级界面并暂停游戏
    public void ActivateUpgradeMenu()
    {
        upgradeCanvas.SetActive(true); // 激活升级Canvas
        Time.timeScale = 0; // 暂停游戏时间，暂停游戏
    }

    // 关闭升级界面并恢复游戏
    public void DeactivateUpgradeMenu()
    {
        upgradeCanvas.SetActive(false); // 隐藏升级Canvas
        Time.timeScale = 1; // 恢复游戏时间
    }

    public void UpgradeHealth()
    {
        playerStats.currentHealth += 1f;
    }

    public void UpgradeMoveSpeed()
    {
        playerStats.currentMoveSpeed +=0.5f;
    }
    public void UpgradeRecovery()
    {
        playerStats.currentRecovery +=0.1f;
    }
}

