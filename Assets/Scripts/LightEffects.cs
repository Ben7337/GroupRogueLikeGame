using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightEffects : MonoBehaviour
{
    public enum Effect {Flicker, Fade};

    private new Light2D light;
    public Effect effect;

    float baseOuterRadius;
    float baseIntensity;

    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light2D>();
        baseOuterRadius = light.pointLightOuterRadius;
        baseIntensity = light.intensity;
    }

    // Update is called once per frame
    void Update()
    {
        switch (effect)
        {
            case (Effect.Flicker):
                if(light.pointLightOuterRadius <= baseOuterRadius)
                    light.pointLightOuterRadius = light.pointLightOuterRadius + (baseOuterRadius / Random.Range(8.5f, 10f));
                else
                    light.pointLightOuterRadius = light.pointLightOuterRadius - (baseOuterRadius / Random.Range(8.5f, 10f));

                if(light.intensity <= baseIntensity)
                    light.intensity = light.intensity + (baseIntensity / Random.Range(8f, 10f));
                else
                    light.intensity = light.intensity - (baseIntensity / Random.Range(8f, 10f));

                break;


            case (Effect.Fade):
                light.intensity = light.intensity / 1.05f;
                break;
        }
    }
}
