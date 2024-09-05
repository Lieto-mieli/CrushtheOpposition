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
    public GameObject choice1object;
    public TextMeshProUGUI choice1text;
    public GameObject choice2object;
    public TextMeshProUGUI choice2text;
    public GameObject choice3object;
    public TextMeshProUGUI choice3text;
    private Sprite temp;
    public AudioSource phoneSfx;
    private Event tempEvent;
    public bool isEventOn = false;
    public ResourceControl resourceControl;
    private static Event[] eventList = new Event[]
    {
        //list of all events
        new Event
        ("a Man is blocking our tanks!",
            "tiangmen",
            3,
            "Remove them forcefully",
            new ResourceEffect[]
            {
                new ResourceEffect(2, -0.2f, 30, "Event0Choice1OpinionDecrease"),
                new ResourceEffect(4, 0.1f, 30, "Event0Choice1FearIncrease")
            },
            "De-escalate and wait for them to leave",
            new ResourceEffect[]
            {
                new ResourceEffect(2, 0.2f, 30, "Event0Choice2OpinionIncrease"),
                new ResourceEffect(2, -0.6f, 30, "Event0Choice2FearDecrease")
            },
            "To the concentration camp they go!",
            new ResourceEffect[]
            {
                new ResourceEffect(2, -1f, 30, "Event0Choice3OpinionDecrease"),
                new ResourceEffect(4, 2f, 30, "Event0Choice3FearIncrease"),
                new ResourceEffect(3, 0.05f, 100, "Event0Choice3SpiritIncrease")
            }
        ),
    };
    private void Start()
    {
        //phoneSfx = GetComponent<AudioSource>();
    }
    public void NewEvent(int eventID)
    {
        isEventOn = true;
        eventWindow.SetActive(true);
        tempEvent = eventList[eventID];
        eventTitle.text = tempEvent.title;
        temp = Resources.Load<Sprite>(tempEvent.imagePathName);
        eventImage.GetComponent<Image>().sprite = temp;
        choice1text.text = tempEvent.choice1;
        choice2text.text = tempEvent.choice2;
        choice3text.text = tempEvent.choice3;
        switch (tempEvent.choiceCount)
        {
            case 1:
                choice1object.SetActive(true);
                choice2object.SetActive(false);
                choice3object.SetActive(false);
                break;
            case 2:
                choice1object.SetActive(true);
                choice2object.SetActive(true);
                choice3object.SetActive(false);
                break;
            case 3:
                choice1object.SetActive(true);
                choice2object.SetActive(true);
                choice3object.SetActive(true);
                break;
        }
        phoneSfx.pitch = Random.Range(0.95f, 1.05f);
        phoneSfx.Play();
    }
    public void EventChoice(int choiceNum)
    {
        switch (choiceNum)
        {
            case 1:
                foreach(ResourceEffect effect in tempEvent.choice1effects)
                {
                    resourceControl.AddEffect(effect);
                }
                break;
            case 2:
                foreach (ResourceEffect effect in tempEvent.choice2effects)
                {
                    resourceControl.AddEffect(effect);
                }
                break;
            case 3:
                foreach (ResourceEffect effect in tempEvent.choice3effects)
                {
                    resourceControl.AddEffect(effect);
                }
                break;
        }
        isEventOn = false;
        eventWindow.SetActive(false);
    }
}