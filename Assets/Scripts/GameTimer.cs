using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public GameObject resourceControl;
    private ResourceControl ben;
    public float eventTimer;
    public GameObject eventPlayer;
    public GameObject musicChange;
    public GameObject gameoverMenu;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI rankText;
    public TextMeshProUGUI debugScore;
    List<int> scoreList;
    private string[] rankings = new string[]
    {
        "Dolfo Hitman",
        "Joze Stan",
        "Mark Big-Dong",
        "Benny Pepperoni",
        "Kai Il-Ceng",
        "Dan Pan",
        "Sad Man Hiding",
        "French Frank",
        "August Pinocchio",
        "Mämmi Godot"
    };
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
        if ((ben.resource1amount + GameSpeedValue.gameSpeed * Time.deltaTime * 1) >= 0 && (ben.resource1amount + GameSpeedValue.gameSpeed * Time.deltaTime * 1) <= 100)
        {
            ben.resource1amount += GameSpeedValue.gameSpeed * Time.deltaTime * 1;
        }
        if ((ben.resource2amount + GameSpeedValue.gameSpeed * Time.deltaTime * -1) >= 0 && (ben.resource2amount + GameSpeedValue.gameSpeed * Time.deltaTime * -1) <= 100)
        {
            ben.resource2amount += GameSpeedValue.gameSpeed * Time.deltaTime * -1;
        }
        if ((ben.resource3amount + GameSpeedValue.gameSpeed * Time.deltaTime * 0.5f / Mathf.Clamp(Mathf.Log(ben.resource4amount) + Mathf.Log(ben.resource2amount), 0.1f, 2f)) >= 0 && (ben.resource3amount + GameSpeedValue.gameSpeed * Time.deltaTime * 0.5f / Mathf.Clamp(Mathf.Log(ben.resource4amount) + Mathf.Log(ben.resource2amount), 0.1f, 2f)) <= 100)
        {
            ben.resource3amount += GameSpeedValue.gameSpeed * Time.deltaTime * 0.5f / Mathf.Clamp(Mathf.Log(ben.resource4amount) + Mathf.Log(ben.resource2amount), 0.1f, 2f);
        }
        if ((ben.resource4amount + GameSpeedValue.gameSpeed * Time.deltaTime * -1) >= 0 && (ben.resource4amount + GameSpeedValue.gameSpeed * Time.deltaTime * -1) <= 100)
        {
            ben.resource4amount += GameSpeedValue.gameSpeed * Time.deltaTime * -1;
        }
        ben.resource5score += GameSpeedValue.gameSpeed * Time.deltaTime * 1;
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
        if(ben.resource3amount >= 100) { GameEnd(); }
        debugScore.text = Convert.ToString(ben.resource5score);
    }
    public void GameEnd()
    {
        GameSpeedValue.gameSpeed = 0;
        int finalScore = System.Convert.ToInt16(ben.resource5score);
        gameoverMenu.SetActive(true);
        scoreText.text = $"Score: {finalScore}";
        string tempStr = rankings[9-System.Convert.ToInt16(finalScore/100)];
        rankText.text = $"Rank: {tempStr}";
        scoreList.Capacity = PlayerPrefs.GetInt("myList_count", 1);
        for (int i = 0; i < scoreList.Count; i++)
        {
            if(PlayerPrefs.HasKey("myList_" + i))
            {
                scoreList.Add(PlayerPrefs.GetInt("myList_" + i));
            }
        }
        scoreList.Add(finalScore);
        PlayerPrefs.SetInt("myList_count", scoreList.Count);
        for (int i = 0; i < scoreList.Count; i++)
        {
            PlayerPrefs.SetInt("myList_" + i, scoreList[i]);
        }
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene(sceneName: "Mainmenu");
    }
}