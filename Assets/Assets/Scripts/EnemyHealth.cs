using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float healthPoints = 100f;
    public GameObject parentToKill;
    //This function receives whether the enemy has been hit by the players attack and decreases the health.
    void ReceiveDamageEnemy(float PlayerDamage)
    {
        healthPoints -= PlayerDamage;

        Debug.Log("Player Dealt: " + healthPoints.ToString());

        if (healthPoints <= 0)
        {
            Invoke("SelfTerminate", 0f);
        }
    }

    //Function to destroy the enemy on 0 health
    void SelfTerminate()
    {
        Destroy(gameObject);
    }
}
