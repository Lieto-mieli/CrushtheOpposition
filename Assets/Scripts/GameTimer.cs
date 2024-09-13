using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public GameObject resourceControl;
    private ResourceControl ben;
    public float eventTimer;
    public GameObject eventPlayer;
    public GameObject musicChange;
    // Start is called before the first frame update
    void Start()
    {
        ben = resourceControl.GetComponent<ResourceControl>();
        eventTimer = 20;
        if (GameSpeedValue.gameSpeed == 0) { GameSpeedValue.gameSpeed = 1; }
    }

    // Update is called once per frame
    void Update()
    {
        Mathf.Clamp(ben.resource1amount += GameSpeedValue.gameSpeed * Time.deltaTime * 1, -10, 100);
        Mathf.Clamp(ben.resource2amount += GameSpeedValue.gameSpeed * Time.deltaTime * (-0.4f - (ben.resource2amount / 100)), -10, 100);
        Mathf.Clamp(ben.resource3amount += GameSpeedValue.gameSpeed * Time.deltaTime * 0.5f / Mathf.Clamp(Mathf.Log(ben.resource4amount) + Mathf.Log(ben.resource2amount),0.1f,3f), -10, 100);
        Mathf.Clamp(ben.resource4amount += GameSpeedValue.gameSpeed * Time.deltaTime * (-0.4f - ((ben.resource4amount / 100) - 0.5f)), -10, 100);
        eventTimer -= GameSpeedValue.gameSpeed * Time.deltaTime;
        if (eventTimer <= 0)
        {
            eventPlayer.GetComponent<EventPlayer>().PlayRandomEvent();
            eventTimer = 20;
        }
        if (ben.resource3amount > 60)
        {
            musicChange.GetComponent<MusicChange>().ChangeToTenseBGM();
        }
    }
}