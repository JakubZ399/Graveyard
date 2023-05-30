using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public int health = 50;

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("health: " + health);
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
