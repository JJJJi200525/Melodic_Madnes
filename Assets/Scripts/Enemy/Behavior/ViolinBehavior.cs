using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViolinBehavior : MonoBehaviour
{
    public CircleCollider2D circleColl;
    public Transform player; // ��ҵ�Transform����Ҫ��Inspector��ָ������Start���Զ�����
    public GameObject bulletPrefab; // �ӵ�Prefab������Inspector��ָ��
    public float shootingInterval = 3f; // ������
    private float shootingTimer; // ��ʱ��

    void Start()
    {
        shootingTimer = shootingInterval; // ��ʼ����ʱ��
        // �Զ�Ѱ����ң�������ұ�ǩΪ"Player"
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void Update()
    {
        // ��ʱ���ݼ�
        shootingTimer -= Time.deltaTime;

        // ����ʱ��С�ڵ���0ʱ�����ò������ӵ�
        if (shootingTimer <= 0)
        {
            Shoot();
            shootingTimer = shootingInterval;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // ����Ƿ�����ҽ��봥������
        if (other.gameObject.CompareTag("Player"))
        {
            shootingTimer = shootingInterval; // ȷ����ҽ���ʱ�������ü�ʱ��
        }
    }

    void Shoot()
    {
        if (player != null)
        {
            // ʵ�����ӵ�
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            // ���㷽��
            Vector2 direction = (player.position - transform.position).normalized;
            // �����ӵ�
            bullet.GetComponent<Rigidbody2D>().velocity = direction * 5f; // �����ӵ��ٶ�Ϊ20

            Destroy(bullet, 3f);
        }
    }
}

