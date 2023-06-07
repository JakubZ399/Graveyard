using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    private RaycastHit hit;
    private Ray ray;

    public GameObject impactEffect;

    public int damage = 10;
    public float rateOfFire = 2;
    public float currentFireCooldown;

    //ammo
    public int _maxAmmo = 30;
    public float _reloadingTime = 3f;

    private int _currentAmmo;

    //DOTween recoil
    public float recoilStrength = 1f;
    
    public Camera _playerCamera;
    public static Camera _playerCameraStatic;

    public GameObject _buzzEffect;

    //bool
    private bool isReloading;

    public GameObject reloadText;
    private void Awake()
    {
        _buzzEffect.SetActive(false);
        _playerCameraStatic = _playerCamera;
    }
    private void Start()
    {
        isReloading = false;
        _currentAmmo = _maxAmmo;
    }

    void Update()
    {
        ray = Camera.main.ViewportPointToRay(new Vector3(.5f, .5f, 0));
        if (Input.GetMouseButton(0) && currentFireCooldown == 0 && _currentAmmo > 0 && !isReloading)
        {
            _buzzEffect.SetActive(true);
            _playerCamera.DOShakeRotation(0.1f, recoilStrength, 1, 90f);


            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                currentFireCooldown = rateOfFire;
                GameObject impactEffectGO = Instantiate(impactEffect, hit.point, Quaternion.identity) as GameObject;

                _currentAmmo -= 1;
                Debug.Log(_currentAmmo);

                Destroy(impactEffectGO, 5);
                if (hit.collider.gameObject.tag == "Cube")
                {
                    Cube cube = hit.collider.gameObject.GetComponent<Cube>();
                    cube.TakeDamage(damage);
                }

            }
        }
        else
        {

            currentFireCooldown -= Time.deltaTime;
            if (currentFireCooldown <= 0)
            {
                currentFireCooldown = 0;
            }
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            _buzzEffect.SetActive(false);
        }
        Reloading();

        if (_currentAmmo <= 0)
        {
            reloadText.SetActive(true);
        }

    }

    private void Reloading()
    {
        if (Input.GetKeyDown(KeyCode.R) && !isReloading)
        {
            Debug.Log("Reloading");
            isReloading = true;
            _currentAmmo = _maxAmmo;
            StartCoroutine(ReloadingCooldown());
        }
    }

    private IEnumerator ReloadingCooldown()
    {
        yield return new WaitForSeconds(_reloadingTime);
        reloadText.SetActive(false);
        Debug.Log("Reloaded");
        isReloading = false;
        yield break;
    }
}
