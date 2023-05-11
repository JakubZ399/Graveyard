using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private float startPlayerHealth = 100f;
    public float currentPlayerHealth;

    private void Start()
    {
        startPlayerHealth = currentPlayerHealth;
    }

    private void Update()
    {
        RestartLevel();
    }

    private void RestartLevel()
    {
        if(currentPlayerHealth <= 0)
        {
            GameObject.Destroy(gameObject);
            /*
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentScene);
            */
        }
    }
}
