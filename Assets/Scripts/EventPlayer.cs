using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPlayer : MonoBehaviour
{
    public GameObject eventControl;
    void Start()
    {
        eventControl.GetComponent<EventControl>().NewEvent(0);
    }
    void Update()
    {
        
    }
}
