using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuitarBehavior : MonoBehaviour
{
    public CircleCollider2D circleColl;
    public float speedReduction = 0.8f; // ���ٱ�����0.5��ζ���ٶȼ���
    private PlayerStats playerStats; // ���״̬�ű�������

    private float originalSpeed;

    private static int slowCounter = 0; // ��̬�����������ٳ��������м���Ӱ�������

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStats playerStats = other.GetComponent<PlayerStats>();
            if (playerStats != null && slowCounter == 0) // ֻ�е�������Ϊ0ʱ����û����������Ч��ʱ���ż���
            {
                playerStats.currentMoveSpeed -= speedReduction;
            }
            slowCounter++; // ���ۺ�ʱ��ҽ���һ���µļ������򣬶�����������
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            slowCounter--; // ���ÿ�뿪һ���������򣬵ݼ�������
            if (slowCounter == 0) // ֻ�е��������ص�0ʱ����û����������Ч��ʱ���Żָ��ٶ�
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

