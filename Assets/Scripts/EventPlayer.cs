using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPlayer : MonoBehaviour
{
    public GameObject eventControl;
    private System.Random r;
    public int industrializationForced = 0;
    void Start()
    {
        //line below is for testing
        //eventControl.GetComponent<EventControl>().NewEvent(0);
        r = new System.Random();
    }
    public void PlayRandomEvent()
    {
        if (eventControl.GetComponent<EventControl>().isEventOn == false)
        {
            int temp = r.Next(0, 4+industrializationForced);    
            Debug.Log(temp);
            eventControl.GetComponent<EventControl>().NewEvent(temp);

        }
    }
}
