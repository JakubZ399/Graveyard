using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Zombie Type", menuName = "Custom/Zombie Type")]
public class ZombieData : ScriptableObject
{
    public string zombieName;
    public GameObject model;
    public Animator animator;
    public int health;
    public int damage;
    public float attackRange;
    public float attackSpeed;
    public float movementSpeed;
}
