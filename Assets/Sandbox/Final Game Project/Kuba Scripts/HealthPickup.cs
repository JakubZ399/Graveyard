using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int addHealth = 25;

    private void Start()
    {
        transform.DOMoveY(1f, 1f).SetLoops(-1, LoopType.Yoyo);
        transform.DORotate(new Vector3(0, 360, 0), 3, RotateMode.LocalAxisAdd).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
        //transform.DOScale(0.5f, 1f).SetLoops(-1, LoopType.Yoyo);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            HealthSystem.currentPlayerHealthStatic += addHealth;
            Destroy(gameObject);
        }
    }
}
