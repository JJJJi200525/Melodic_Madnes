using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeytarController : WeaponController
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    protected override void Attack ()
    {
        base.Attack();
        GameObject spawnedKnife = Instantiate(weaponData.Prefab);
        spawnedKnife.transform.position = transform.position; // assign the position to be the same as this object which is parented to the player
        spawnedKnife.GetComponent<KeytarBehaviour>().DirectionChecker(pm.lastMovedVector); //reference and se the direction
    }
}
