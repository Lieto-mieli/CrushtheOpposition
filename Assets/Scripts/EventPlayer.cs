using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPlayer : MonoBehaviour
{
    public GameObject eventControl;
    private System.Random r;
    void Start()
    {
        //line below is for testing
        //eventControl.GetComponent<EventControl>().NewEvent(0);
    }
    public void PlayRandomEvent()
    {
        if (eventControl.GetComponent<EventControl>().isEventOn == false)
        {
            eventControl.GetComponent<EventControl>().NewEvent(r.Next(0, 1));
        }
    }
}
