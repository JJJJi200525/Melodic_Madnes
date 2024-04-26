using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float damage = 10f; // 子弹的伤害值

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // 调用玩家的受伤方法，传递伤害值
            collision.gameObject.GetComponent<PlayerStats>().TakeDamage(damage);
            // 销毁子弹
            Destroy(gameObject);
        }
    }
}

