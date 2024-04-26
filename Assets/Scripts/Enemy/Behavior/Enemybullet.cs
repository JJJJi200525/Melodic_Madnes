using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float damage = 10f; // �ӵ����˺�ֵ

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // ������ҵ����˷����������˺�ֵ
            collision.gameObject.GetComponent<PlayerStats>().TakeDamage(damage);
            // �����ӵ�
            Destroy(gameObject);
        }
    }
}

