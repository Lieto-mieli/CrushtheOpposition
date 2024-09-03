using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPlayer : MonoBehaviour
{
    public GameObject eventControl;
    void Start()
    {
        EventControl eventScript = eventControl.GetComponent<EventControl>();
        eventScript.NewEvent(0);
    }
    void Update()
    {
        
    }
}
