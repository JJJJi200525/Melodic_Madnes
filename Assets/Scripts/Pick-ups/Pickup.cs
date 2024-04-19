using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))    //destroy Expball when it gets close to the player
        {
            Destroy(gameObject);
        }
    }
}
