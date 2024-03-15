using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SpotLightScript : MonoBehaviour
{
    public float intensity = 1f; // Intensity of the spotlight
    public float range = 5f; // Range of the spotlight
    public Color color = Color.white; // Color of the spotlight
    public float flickerSpeed = 1f; // Speed of flickering effect
    public float flickerIntensity = 0.1f; // Intensity of flickering effect

    private Light2D spotlight;
    private float originalIntensity;
    private float originalRange;
    private Color originalColor;

    private void Start()
    {
        spotlight = GetComponent<Light2D>();
        originalIntensity = spotlight.intensity;
        originalRange = spotlight.pointLightOuterRadius;
        originalColor = spotlight.color;

        // Start flickering effect
        InvokeRepeating(nameof(Flicker), 0f, flickerSpeed);
    }

    private void Flicker()
    {
        // Apply flicker effect by changing intensity and range randomly
        float flickerFactor = Random.Range(1 - flickerIntensity, 1 + flickerIntensity);
        spotlight.intensity = originalIntensity * flickerFactor;
        spotlight.pointLightOuterRadius = originalRange * flickerFactor;

        // Apply flickering color effect
        spotlight.color = originalColor * flickerFactor;
    }

    private void Update()
    {
        // Apply user-defined properties
        spotlight.intensity = intensity;
        spotlight.pointLightOuterRadius = range;
        spotlight.color = color;
    }
}
