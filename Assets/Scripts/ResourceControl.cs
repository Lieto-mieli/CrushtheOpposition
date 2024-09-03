using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ResourceControl : MonoBehaviour
{
    public GameObject resource1;
    public GameObject resource2;
    public GameObject resource3;
    public GameObject resource4;
    private float resource1amount; // money
    private float resource2amount; // public opinion
    private float resource3amount; // revolution
    private float resource4amount; // fear
    private List<ResourceEffect> currentEffects = new List<ResourceEffect> { };
    private void Start()
    {
        resource1amount = 60;
        resource2amount = 50;
        resource3amount = 0;
        resource4amount = 10;
        currentEffects.Capacity = 99;
    }
    void Update()
    {
        if (currentEffects != null)
        {
            foreach (ResourceEffect effect in currentEffects)
            {
                switch (effect.resourceID)
                {
                    case 1:
                        resource1amount += Mathf.Clamp(Time.deltaTime * effect.effectMagnitude, -10, 100);
                        break;
                    case 2:
                        resource2amount += Mathf.Clamp(Time.deltaTime * effect.effectMagnitude, -10, 100);
                        break;
                    case 3:
                        resource3amount += Mathf.Clamp(Time.deltaTime * effect.effectMagnitude, -10, 100);
                        break;
                    case 4:
                        resource4amount += Mathf.Clamp(Time.deltaTime * effect.effectMagnitude, -10, 100);
                        break;
                }
                effect.effectDuration -= Time.deltaTime * 1;
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
}
