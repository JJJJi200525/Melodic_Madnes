using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public PlayerStats playerStats;
    public GameObject upgradeCanvas; // ����Canvas������

    void Awake()
    {
        upgradeCanvas.SetActive(false); // ȷ����Ϸ��ʼʱCanvas�ǲ���Ծ��
    }

    // ��ʾ�������沢��ͣ��Ϸ
    public void ActivateUpgradeMenu()
    {
        upgradeCanvas.SetActive(true); // ��������Canvas
        Time.timeScale = 0; // ��ͣ��Ϸʱ�䣬��ͣ��Ϸ
    }

    // �ر��������沢�ָ���Ϸ
    public void DeactivateUpgradeMenu()
    {
        upgradeCanvas.SetActive(false); // ��������Canvas
        Time.timeScale = 1; // �ָ���Ϸʱ��
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

