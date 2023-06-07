using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessingControl : MonoBehaviour
{
    public VolumeProfile gameVolume;
    private Vignette _vignette;
    private ColorAdjustments _colorAdjustments;
    private float _maxHealthPoints = 100f;

    private void Awake()
    {
        InitializeVignette();
        InitializeColorAdjustments();
    }

    private void InitializeVignette()
    {
        Vignette _vi;
        if (gameVolume.TryGet<Vignette>(out _vi))
        {
            _vignette = _vi;
            _vignette.intensity.value = 0.15f;
        }
    }

    private void InitializeColorAdjustments()
    {
        ColorAdjustments _ca;
        if (gameVolume.TryGet<ColorAdjustments>(out _ca))
        {
            _colorAdjustments = _ca;
            _colorAdjustments.saturation.value = 0f;
        }
    }

    private void Update()
    {
        UpdateVignette();
        UpdateColorAdjustments();
    }

    private void UpdateVignette()
    {
        float normalizedHealth = HealthSystem.currentPlayerHealthStatic / _maxHealthPoints;
        float vignetteIntensity = Mathf.Lerp(1f, 0.15f, normalizedHealth);

        if (_vignette != null)
        {
            _vignette.intensity.value = vignetteIntensity;
        }
    }

    private void UpdateColorAdjustments()
    {
        float normalizedHealth = HealthSystem.currentPlayerHealthStatic / _maxHealthPoints;
        float saturationValue = Mathf.Lerp(-100f, 0f, normalizedHealth);

        if (_colorAdjustments != null)
        {
            _colorAdjustments.saturation.value = saturationValue;
        }
    }
}