using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    private float currentSpeed;
    public void changevalue(float value)
    {
        currentSpeed = value;
    }
    public void SwitchToGame()
    {
        GameSpeedValue.gameSpeed = currentSpeed;
        SceneManager.LoadScene(sceneName: "Ingame");
    }
    
}
