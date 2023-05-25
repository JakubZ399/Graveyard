using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    private RaycastHit hit;
    private Ray ray;

    public GameObject impactEffect;

    public int damage = 10;
    public float rateOfFire = 2;
    public float currentFireCooldown;
    void Start()
    {
        
    }


    void Update()
    {
       ray = Camera.main.ViewportPointToRay(new Vector3(.5f, .5f, 0));
       if(Input.GetMouseButton(0) && currentFireCooldown == 0)
       {
           if(Physics.Raycast(ray, out hit, Mathf.Infinity))
           {
                currentFireCooldown = rateOfFire;
               GameObject impactEffectGO = Instantiate(impactEffect, hit.point, Quaternion.identity) as GameObject;
               Destroy(impactEffectGO, 5);
               if(hit.collider.gameObject.tag == "Cube")
               {
                   Cube cube = hit.collider.gameObject.GetComponent<Cube>();
                   cube.TakeDamage(damage);
               }
               
           }
        }
        else
        {
            currentFireCooldown -=  Time.deltaTime;
            if(currentFireCooldown <= 0)
            {
                currentFireCooldown = 0;
            }
        }
    }
}
