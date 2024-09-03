using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event
{
    public string title;
    public string imagePathName;
    public int choiceCount;
    public string choice1 = "";
    public ResourceEffect[] choice1effects;
    public string choice2 = "";
    public ResourceEffect[] choice2effects;
    public string choice3 = "";
    public ResourceEffect[] choice3effects;
    public Event(string title, string imagePathName, int choiceCount, string choice1, ResourceEffect[] choice1effects, string choice2, ResourceEffect[] choice2effects,string choice3, ResourceEffect[] choice3effects)
    {
        this.title = title;
        this.imagePathName = imagePathName;
        this.choiceCount = choiceCount;
        this.choice1 = choice1;
        this.choice1effects = choice1effects;
        this.choice2 = choice2;
        this.choice2effects = choice2effects;
        this.choice3 = choice3;
        this.choice3effects = choice3effects;
    }
}

