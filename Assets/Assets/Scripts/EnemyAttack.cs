using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float EnemyDamage = 10f;

    //This script applies damage if the player is hit by the enemies melee attack
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision with collider detected");
        if (other.CompareTag("Player"))
        {
            Debug.Log("Hit was on player");
            other.SendMessageUpwards("ReceiveDamage", EnemyDamage, SendMessageOptions.DontRequireReceiver);
        }
    }

}
