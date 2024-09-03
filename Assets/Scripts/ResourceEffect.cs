using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceEffect
{
    public int resourceID;
    public float effectMagnitude;
    public float effectDuration;
    public string internalName;

    public ResourceEffect(int resourceID, float effectMagnitude, float effectDuration, string internalName)
    {
        this.resourceID = resourceID;
        this.effectMagnitude = effectMagnitude;
        this.effectDuration = effectDuration;
        this.internalName = internalName;
    }
}
