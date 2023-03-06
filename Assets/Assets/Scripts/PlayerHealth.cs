using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float healthPoints = 100f;
    //This function makes the player receive damage and decreases the player health
    void ReceiveDamage(float EnemyDamage)
    {
        healthPoints -= EnemyDamage;
        
        Debug.Log("Enemy Dealt: " + healthPoints.ToString());

        if (healthPoints <= 0)
        {
            Debug.Log("GAME OVER - YOU DIED");
            Destroy(gameObject);
        }
    }
}
