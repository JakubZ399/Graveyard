using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    public ProjectileGun gunScript;
    public Rigidbody rb;
    public BoxCollider coll;
    public Transform player, gunContainer, fpsCam;

    public float pickingUpRange;
    public float dropForwardForce, dropUpwardForce;

    public bool equipped;
    public static bool slotFull;

    private void Update()
    {
        Vector3 distanceToPlayer = player.position - transform.position;
        if (!equipped && distanceToPlayer.magnitude <= pickingUpRange && Input.GetKeyDown(KeyCode.E) && !slotFull) PickUp();
        if (equipped && Input.GetKeyDown(KeyCode.Q)) Drop();
    }
    private void PickUp()
    {
        equipped = true;
        slotFull = true;

        rb.isKinematic = true;
        coll.isTrigger = true;
        
        gunScript.enabled = true;
    }
    private void Drop()
    {
        equipped = false;
        slotFull = false;

        rb.isKinematic = false;
        coll.isTrigger = false;

        gunScript.enabled = false;
    }
}
