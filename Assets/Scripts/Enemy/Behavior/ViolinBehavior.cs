using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViolinBehavior : MonoBehaviour
{
    public CircleCollider2D circleColl;
    public Transform player; // 玩家的Transform，需要在Inspector中指定或在Start中自动查找
    public GameObject bulletPrefab; // 子弹Prefab，需在Inspector中指定
    public float shootingInterval = 3f; // 发射间隔
    private float shootingTimer; // 计时器

    void Start()
    {
        shootingTimer = shootingInterval; // 初始化计时器
        // 自动寻找玩家，假设玩家标签为"Player"
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void Update()
    {
        // 计时器递减
        shootingTimer -= Time.deltaTime;

        // 当计时器小于等于0时，重置并发射子弹
        if (shootingTimer <= 0)
        {
            Shoot();
            shootingTimer = shootingInterval;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // 检测是否是玩家进入触发区域
        if (other.gameObject.CompareTag("Player"))
        {
            shootingTimer = shootingInterval; // 确保玩家进入时立即重置计时器
        }
    }

    void Shoot()
    {
        if (player != null)
        {
            // 实例化子弹
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            // 计算方向
            Vector2 direction = (player.position - transform.position).normalized;
            // 发射子弹
            bullet.GetComponent<Rigidbody2D>().velocity = direction * 5f; // 假设子弹速度为20

            Destroy(bullet, 3f);
        }
    }
}

