using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuitarBehavior : MonoBehaviour
{
    public CircleCollider2D circleColl;
    public float speedReduction = 0.8f; // 减速倍数，0.5意味着速度减半
    private PlayerStats playerStats; // 玩家状态脚本的引用

    private float originalSpeed;

    private static int slowCounter = 0; // 静态计数器，跟踪场景中所有减速影响的数量

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStats playerStats = other.GetComponent<PlayerStats>();
            if (playerStats != null && slowCounter == 0) // 只有当计数器为0时，即没有其他减速效果时，才减速
            {
                playerStats.currentMoveSpeed -= speedReduction;
            }
            slowCounter++; // 无论何时玩家进入一个新的减速区域，都递增计数器
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            slowCounter--; // 玩家每离开一个减速区域，递减计数器
            if (slowCounter == 0) // 只有当计数器回到0时，即没有其他减速效果时，才恢复速度
            {
                PlayerStats playerStats = other.GetComponent<PlayerStats>();
                if (playerStats != null)
                {
                    playerStats.currentMoveSpeed += speedReduction;
                }
            }
        }
    }
}

