using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EventControl : MonoBehaviour
{
    public GameObject eventWindow;
    public TextMeshProUGUI eventTitle;
    public GameObject eventImage;
    public GameObject choice1;
    public TextMeshProUGUI choice1text;
    public GameObject choice2;
    public TextMeshProUGUI choice2text;
    public GameObject choice3;
    public TextMeshProUGUI choice3text;
    private Sprite temp;
    private AudioSource phoneSfx;
    private List<Event> eventList;

    public void NewEvent(int eventID)
    {
        Event tempEvent = eventList[eventID];
        eventTitle.GetComponent<Text>().text = tempEvent.title;
        temp = Resources.Load<Sprite>(tempEvent.imagePathName);
        eventImage.GetComponent<Image>().sprite = temp;
        choice1text.GetComponent<Text>().text = tempEvent.choice1;
        choice2text.GetComponent<Text>().text = tempEvent.choice2;
        choice3text.GetComponent<Text>().text = tempEvent.choice3;
        switch (tempEvent.choiceCount)
        {
            case 1:
                choice1.SetActive(true);
                choice2.SetActive(false);
                choice3.SetActive(false);
                break;
            case 2:
                choice1.SetActive(true);
                choice2.SetActive(true);
                choice3.SetActive(false);
                break;
            case 3:
                choice1.SetActive(true);
                choice2.SetActive(true);
                choice3.SetActive(true);
                break;
        }
        phoneSfx.pitch = Random.Range(0.95f, 1.05f);
        phoneSfx.Play();
    }
}
