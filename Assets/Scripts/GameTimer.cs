using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public GameObject resourceControl;
    private ResourceControl ben;
    // Start is called before the first frame update
    void Start()
    {
        ben = resourceControl.GetComponent<ResourceControl>();
    }

    // Update is called once per frame
    void Update()
    {
        ben.resource1amount += Mathf.Clamp(Time.deltaTime * 1, -10, 100);
        ben.resource2amount += Mathf.Clamp(Time.deltaTime * ((Mathf.Log(ben.resource2amount) - 1f)/10), -10, 100);
        ben.resource3amount += Mathf.Clamp((Time.deltaTime * 0.3f) / (Mathf.Log(ben.resource4amount) + 1f), -10, 100);
        ben.resource4amount += Mathf.Clamp(Time.deltaTime * (-0.4f + ((ben.resource4amount / 100) - 0.5f)), -10, 100);
    }
}