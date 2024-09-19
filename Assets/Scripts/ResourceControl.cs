using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ResourceControl : MonoBehaviour
{
    public GameObject resource1;
    public GameObject resource2;
    public GameObject resource3;
    public GameObject resource4;
    public float resource1amount; // Treasury
    public float resource2amount; // Public Opinion
    public float resource3amount; // Societal Unrest
    public float resource4amount; // Fear
    public float resource5score;
    private List<ResourceEffect> currentEffects = new List<ResourceEffect> { };
    private void Start()
    {
        resource1amount = 60;
        resource2amount = 50;
        resource3amount = 0;
        resource4amount = 20;
        resource5score = 0;
        currentEffects.Capacity = 99;
    }
    void Update()
    {
        if (currentEffects != null)
        {
            foreach (ResourceEffect effect in currentEffects.ToList())
            {
                switch (effect.resourceID)
                {
                    case 1:
                        if ((resource1amount + GameSpeedValue.gameSpeed * Time.deltaTime * effect.effectMagnitude) >= 0 && (resource1amount + GameSpeedValue.gameSpeed * Time.deltaTime * effect.effectMagnitude) <= 100)
                        {
                            resource1amount += GameSpeedValue.gameSpeed * Time.deltaTime * effect.effectMagnitude;
                        }
                        break;
                    case 2:
                        if ((resource2amount + GameSpeedValue.gameSpeed * Time.deltaTime * effect.effectMagnitude) >= 0 && (resource2amount + GameSpeedValue.gameSpeed * Time.deltaTime * effect.effectMagnitude) <= 100)
                        {
                            resource2amount += GameSpeedValue.gameSpeed * Time.deltaTime * effect.effectMagnitude;
                        }
                        break;
                    case 3:
                        if ((resource3amount + GameSpeedValue.gameSpeed * Time.deltaTime * effect.effectMagnitude) >= 0 && (resource3amount + GameSpeedValue.gameSpeed * Time.deltaTime * effect.effectMagnitude) <= 100)
                        {
                            resource3amount += GameSpeedValue.gameSpeed * Time.deltaTime * effect.effectMagnitude;
                        }
                        break;
                    case 4:
                        if ((resource4amount + GameSpeedValue.gameSpeed * Time.deltaTime * effect.effectMagnitude) >= 0 && (resource4amount + GameSpeedValue.gameSpeed * Time.deltaTime * effect.effectMagnitude) <= 100)
                        {
                            resource4amount += GameSpeedValue.gameSpeed * Time.deltaTime * effect.effectMagnitude;
                        }
                        break;
                    case 5:
                        resource5score += GameSpeedValue.gameSpeed * Time.deltaTime * effect.effectMagnitude;
                        break;
                }
                effect.effectDuration -= GameSpeedValue.gameSpeed * Time.deltaTime;
                if (effect.effectDuration <= 0) { currentEffects.Remove(effect); }
            }
        }

        resource1.GetComponent<UnityEngine.UI.Slider>().value = resource1amount;
        resource2.GetComponent<UnityEngine.UI.Slider>().value = resource2amount;
        resource3.GetComponent<UnityEngine.UI.Slider>().value = resource3amount;
        resource4.GetComponent<UnityEngine.UI.Slider>().value = resource4amount;
    }
    public void NewEffect(int resourceID, float magnitude, float duration, string name)
    {
        ResourceEffect temp = new ResourceEffect(resourceID, magnitude, duration, name);
        currentEffects.Add(temp);
    }
    public void AddEffect(ResourceEffect effect)
    {
        currentEffects.Add(effect);
    }
    public bool GetEffect(string name)
    {
        foreach (ResourceEffect effect in currentEffects)
        {
            if (effect.internalName == name) return true;
        }
        return false;
    }
}
