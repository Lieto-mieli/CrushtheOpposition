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
        new Event // 00
        ("a Man is blocking our tanks!",
            "tiangmen",
            3,
             "To the concentration camp they go!",
            new ResourceEffect[]
            {
                new ResourceEffect(2, -2f, 30, "Event0Choice1OpinionDecrease"),
                new ResourceEffect(4, 3f, 30, "Event0Choice1FearIncrease"),
                new ResourceEffect(3, 0.1f, 50, "Event0Choice1SpiritIncrease"),
                new ResourceEffect(5, 5, 10, "Event0Choice1PointsIncrease")
            },
            "Remove them forcefully",
            new ResourceEffect[]
            {
                new ResourceEffect(2, -1.5f, 30, "Event0Choice2OpinionDecrease"),
                new ResourceEffect(4, 1.5f, 30, "Event0Choice2FearIncrease")
            },
            "De-escalate and wait for them to leave",
            new ResourceEffect[]
            {
                new ResourceEffect(2, 1.5f, 30, "Event0Choice3OpinionIncrease"),
                new ResourceEffect(2, -1.5f, 30, "Event0Choice3FearDecrease")
            }
        ),
        new Event  // 01
        ("The UN are threatening us with embargos,\r\nif we continue to commit so many human rights violations", // replace "us" with country name if it is implemented
            "un",
            2,
            "I don't care",
            new ResourceEffect[]
            {
                new ResourceEffect(2, -0.5f, 30, "Event1Choice1OpinionDecrease"),
                new ResourceEffect(1, -1.5f, 30, "Event1Choice1TreasuryDecrease")
            },
            "We should comply with their demands",
            new ResourceEffect[]
            {
                new ResourceEffect(2, 1f, 30, "Event1Choice2OpinionIncrease"),
                new ResourceEffect(2, -2.5f, 30, "Event1Choice2FearDecrease")
            },
            "",
            new ResourceEffect[]
            {
            }
        ),
        new Event // 02
        ("Protests are mobilizing out in one of our cities",
            "protest",
            3,
             "Arrest all those attending and throw them in the gulag!",
            new ResourceEffect[]
            {
                new ResourceEffect(2, -3f, 30, "Event2Choice1OpinionDecrease"),
                new ResourceEffect(4, 5f, 30, "Event2Choice1FearIncrease"),
                new ResourceEffect(3, 0.2f, 50, "Event2Choice1SpiritIncrease"),
                new ResourceEffect(5, 10, 10, "Event2Choice1PointsIncrease")
            },
            "Break them up with force",
            new ResourceEffect[]
            {
                new ResourceEffect(2, -2f, 30, "Event2Choice2OpinionDecrease"),
                new ResourceEffect(4, 2f, 30, "Event2Choice2FearIncrease")
            },
            "That's fine, I don't mind peaceful protests",
            new ResourceEffect[]
            {
                new ResourceEffect(2, 1f, 30, "Event2Choice3OpinionIncrease"),
                new ResourceEffect(2, -0.5f, 30, "Event2Choice3FearDecrease")
            }
        ),
        new Event // 03
        ("a Dam has malfunctioned, flooding the surrounding area",
            "dam",
            2,
             "Who cares? Just let them sort it out themselves",
            new ResourceEffect[]
            {
                new ResourceEffect(1, -1f, 30, "Event3Choice1TreasuryDecrease"),
                new ResourceEffect(2, -1f, 30, "Event3Choice1OpinionDecrease"),
                new ResourceEffect(4, 1f, 30, "Event3Choice1FearIncrease"),
                new ResourceEffect(3, 0.5f, 50, "Event3Choice1SpiritIncrease"),
                new ResourceEffect(5, 1, 10, "Event3Choice1PointsIncrease")
            },
            "We should send humanitarian aid and fix the dam immediately",
            new ResourceEffect[]
            {
                new ResourceEffect(1, -2.5f, 20, "Event3Choice2TreasuryDecrease"),
                new ResourceEffect(2, 3f, 30, "Event3Choice2OpinionIncrease"),
                new ResourceEffect(4, -0.5f, 30, "Event3Choice2FearDecrease")
            },
            "",
            new ResourceEffect[]
            {
            }
        ),
        new Event // 09
        ("Our industrialization efforts have backfired, and the whole country is experiencing a famine!",
            "farm",
            1,
             "Oops...",
            new ResourceEffect[]
            {
                new ResourceEffect(1, -2f, 30, "Event9Choice1TreasuryDecrease"),
                new ResourceEffect(2, -2f, 30, "Event9Choice1OpinionDecrease"),
                new ResourceEffect(3, 0.1f, 50, "Event9Choice1SpiritIncrease")
            },
            "",
            new ResourceEffect[]
            {
            },
            "",
            new ResourceEffect[]
            {
            }
        )
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