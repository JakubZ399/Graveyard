using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    float startPlayerHealth = 100f;
    float currentPlayerHealth;

    private void Start()
    {
        startPlayerHealth = currentPlayerHealth;
    }
}
