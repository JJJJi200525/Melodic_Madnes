using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//base script of all Projectile Behaviour, to be placed on a prefab of a weapon that is a projectile
public class ProjectileWeaponBehaviour : MonoBehaviour
{
    public WeaponScriptableObject weaponData;

    protected Vector3 direction;
    public float destroyAfterSeconds;

    //Curretn stats
    public float currentDamage;
    protected float currentSpeed;
    protected float currentCooldownDuration;
    protected float currentPierce;

    void Awake()
    {
        currentDamage = weaponData.Damage;
        currentSpeed = weaponData.Speed;
        currentCooldownDuration = weaponData.CooldownDuration;
        currentPierce = weaponData.Pierce;
    }

    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }

    public void DirectionChecker(Vector3 dir) 
    {
        direction = dir;

        float dirx = direction.x;
        float diry = direction.y;

        Vector3 scale = transform.localScale;
        Vector3 rotation = transform.rotation.eulerAngles;

        if(dirx < 0 && diry ==0)    //left
        {
            scale.x = scale.x * -1;
            scale.y = scale.y * -1;
        }
        else if (dirx == 0 && diry < 0)     //down
        {
            scale.y = scale.y * -1;
        }
        else if (dirx == 0 && diry > 0)     //up
        {
            scale.x = scale.x * -1;
        }
        else if (dir.x > 0 && dir.y > 0)     //right up
        {
            rotation.z = 0f;
        }
        else if (dir.x > 0 && dir.y < 0)     //right down
        {
            rotation.z = -90f;
        }
        else if (dir.x < 0 && dir.y > 0)     //left up
        {
            scale.x = scale.x * -1;
            scale.y = scale.y * -1;
            rotation.z = -90f;
        }
        else if (dir.x < 0 && dir.y < 0)     //left down
        {
            scale.x = scale.x * -1;
            scale.y = scale.y * -1;
            rotation.z = 0f;
        }

        transform.localScale = scale;
        transform.rotation = Quaternion.Euler(rotation);  // can't simply set the vector because cannot convert
    }

    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        //Reference the script from the collided collider and deal damage using TakeDamage()
        if(col.CompareTag("Enemy"))
        {
            Debug.Log("Hit!");
            EnemyStats enemy = col.GetComponent<EnemyStats>();
            enemy.TakaDamage(currentDamage);    //Make sure to use currentDamage instead of weaaponData.damage in case any damage multipliers in the future
            Debug.Log("Damage:"+ currentDamage);

            ReducePierce();
        }
    }

    void ReducePierce()
    {
        currentPierce--;
        if(currentPierce <=0)
        {
            Destroy(gameObject);
        }
    }
}
