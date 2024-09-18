using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreMenu : MonoBehaviour
{
    public List<TextMeshProUGUI> textFields;
    private List<int> scoreList = new List<int>(1);
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("myList_count"))
        {
            scoreList.Capacity = PlayerPrefs.GetInt("myList_count", 1);
            for (int i = 0; i < scoreList.Count; i++)
            {
                if (PlayerPrefs.HasKey("myList_" + i))
                {
                    scoreList.Add(PlayerPrefs.GetInt("myList_" + i));
                }
            }
        }
        scoreList.Reverse();
        for (int i = 0; i < 7; i++)
        {
            if(scoreList.Count <= i)
            {
                textFields[i].text = "-";
            }
            else
            {
                textFields[i].text = $"#{i+1} - {scoreList[i]}";
            }
        }
    }   
}
