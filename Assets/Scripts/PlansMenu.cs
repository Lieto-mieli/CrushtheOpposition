using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlansMenu : MonoBehaviour
{
    private bool moveMenu;
    public GameObject planButton1;
    public GameObject planButton2;
    public GameObject planButton3;
    public GameObject planButton4;
    public GameObject resourceThingy;
    public GameObject eventDog;
    private ResourceControl rCtrl;
    private ResourceEffect[] tempList;
    private void Start()
    {
        rCtrl = resourceThingy.GetComponent<ResourceControl>();
    }
    private void Update()
    {
        if (moveMenu)
        {
            if (menuOpen == 0)
            {
                if (transform.position.x >= 2580)
                {
                    moveMenu = false;
                }
                else { transform.position = new Vector3(transform.position.x + Time.deltaTime * 3000, transform.position.y, transform.position.z); }
            }
            else
            {
                if (transform.position.x <= 1290)
                {
                    moveMenu = false;
                }
                else { transform.position = new Vector3(transform.position.x - Time.deltaTime * 3000, transform.position.y, transform.position.z); }
            }
        }
    }
    private int menuOpen = 0;
    public void ChangeMenu(int buttonNum)
    {
        if (menuOpen == buttonNum)
        {
            menuOpen = 0;
            moveMenu = true;
        }
        else { moveMenu = true; menuOpen = buttonNum; 
            switch (buttonNum)
            {
                case 1:
                    planButton1.GetComponent<PlanButton>().Title.text = "Give speeches";
                    planButton1.GetComponent<PlanButton>().Positives.text = "+Public Opinion";
                    planButton1.GetComponent<PlanButton>().Negatives.text = "-Treasury";
                    planButton2.GetComponent<PlanButton>().Title.text = "Promote fascist rhetoric";
                    planButton2.GetComponent<PlanButton>().Positives.text = "++Public Opinion";
                    planButton2.GetComponent<PlanButton>().Negatives.text = "--Treasury";
                    planButton3.GetComponent<PlanButton>().Title.text = "Indoctrinate children";
                    planButton3.GetComponent<PlanButton>().Positives.text = "+++Public Opinion";
                    planButton3.GetComponent<PlanButton>().Negatives.text = "---Treasury";
                    planButton4.GetComponent<PlanButton>().Title.text = "Undermine minorities";
                    planButton4.GetComponent<PlanButton>().Positives.text = "++Public Opinion";
                    planButton4.GetComponent<PlanButton>().Negatives.text = "-Public Opinion";
                    ChangeButtonState(planButton1, "S1PlanOpinionIncrease");
                    ChangeButtonState(planButton2, "S2PlanOpinionIncrease");
                    ChangeButtonState(planButton3, "S3PlanOpinionIncrease");
                    ChangeButtonState(planButton4, "S4PlanOpinionIncrease");
                    // switch to menu 1
                    break;
                case 2:
                    planButton1.GetComponent<PlanButton>().Title.text = "Increase corruption";
                    planButton1.GetComponent<PlanButton>().Positives.text = "++Treasury";
                    planButton1.GetComponent<PlanButton>().Negatives.text = "--Public Opinion";
                    planButton2.GetComponent<PlanButton>().Title.text = "Take more loans";
                    planButton2.GetComponent<PlanButton>().Positives.text = "++++Treasury";
                    planButton2.GetComponent<PlanButton>().Negatives.text = "-Treasury?";
                    planButton3.GetComponent<PlanButton>().Title.text = "Crush unions";
                    planButton3.GetComponent<PlanButton>().Positives.text = "+Treasury\r\n+Fear";
                    planButton3.GetComponent<PlanButton>().Negatives.text = "--Public Opinion";
                    planButton4.GetComponent<PlanButton>().Title.text = "Force Industrialization";
                    planButton4.GetComponent<PlanButton>().Positives.text = "+++Treasury?";
                    planButton4.GetComponent<PlanButton>().Negatives.text = "-Public Opinion?";
                    ChangeButtonState(planButton1, "E1PlanTreasuryIncrease");
                    ChangeButtonState(planButton2, "E2PlanTreasuryDecrease");
                    ChangeButtonState(planButton3, "E3PlanTreasuryIncrease");
                    ChangeButtonState(planButton4, "E4PlanTreasuryIncrease");
                    // switch to menu 2
                    break;
                case 3:
                    planButton1.GetComponent<PlanButton>().Title.text = "Expand Surveillance";
                    planButton1.GetComponent<PlanButton>().Positives.text = "++Fear";
                    planButton1.GetComponent<PlanButton>().Negatives.text = "-Public Opinion\r\n-Treasury";
                    planButton2.GetComponent<PlanButton>().Title.text = "Eliminate political activists";
                    planButton2.GetComponent<PlanButton>().Positives.text = "+++Fear";
                    planButton2.GetComponent<PlanButton>().Negatives.text = "--Public Opinion\r\n-Treasury";
                    planButton3.GetComponent<PlanButton>().Title.text = "Escalate media censorship";
                    planButton3.GetComponent<PlanButton>().Positives.text = "++Public Opinion\r\n+Fear";
                    planButton3.GetComponent<PlanButton>().Negatives.text = "---Treasury";
                    planButton4.GetComponent<PlanButton>().Title.text = "Build \"rehabilitation\" camps";
                    planButton4.GetComponent<PlanButton>().Positives.text = "++Fear\r\n++Score";
                    planButton4.GetComponent<PlanButton>().Negatives.text = "---Public Opinion\r\n--Treasury";
                    ChangeButtonState(planButton1, "O1PlanFearIncrease");
                    ChangeButtonState(planButton2, "O2PlanFearIncrease");
                    ChangeButtonState(planButton3, "O3PlanFearIncrease");
                    ChangeButtonState(planButton4, "O4PlanFearIncrease");
                    // switch to menu 3
                    break;
            }
        }
    }
    public void EnactPlan(int planNum)
    {
        switch (menuOpen)
        {
            case 1:
                switch (planNum)
                {
                    case 1:
                        tempList = new ResourceEffect[] {
                        new ResourceEffect(2, 1.75f, 30, "S1PlanOpinionIncrease"),
                        new ResourceEffect(1, -1.5f, 30, "S1PlanTreasuryDecrease")};
                        ChangeButtonState(planButton1, true);
                        break;
                    case 2:
                        tempList = new ResourceEffect[] {
                        new ResourceEffect(2, 2.5f, 30, "S2PlanOpinionIncrease"),
                        new ResourceEffect(1, -2.25f, 30, "S2PlanTreasuryDecrease")};
                        ChangeButtonState(planButton2, true);
                        break;
                    case 3:
                        tempList = new ResourceEffect[] {
                        new ResourceEffect(2, 3.25f, 30, "S3PlanOpinionIncrease"),
                        new ResourceEffect(1, -3f, 30, "S3PlanTreasuryDecrease")};
                        ChangeButtonState(planButton3, true);
                        break;
                    case 4:
                        tempList = new ResourceEffect[] {
                        new ResourceEffect(2, 2.25f, 30, "S4PlanOpinionIncrease"),
                        new ResourceEffect(2, 1f, 30, "S4PlanOpinionDecrease")};
                        ChangeButtonState(planButton4, true);
                        break;
                }
                break;
            case 2:
                switch (planNum)
                {
                    case 1:
                        tempList = new ResourceEffect[] { 
                            new ResourceEffect(1, 2.5f, 30, "E1PlanTreasuryIncrease"),
                            new ResourceEffect(2, -2.25f, 30, "E1PlanOpinionDecrease")};
                        ChangeButtonState(planButton1, true);
                        break;
                    case 2:
                        tempList = new ResourceEffect[] {
                            new ResourceEffect(1, 60f, 1, "E2PlanTreasuryIncrease"),
                            new ResourceEffect(1, -1.5f, 60, "E2PlanTreasuryDecrease")};
                        ChangeButtonState(planButton2, true);
                        break;
                    case 3:
                        tempList = new ResourceEffect[] {
                            new ResourceEffect(1, 1.25f, 30, "E3PlanTreasuryIncrease"),
                            new ResourceEffect(4, 1.25f, 30, "E3PlanFearIncrease"),
                            new ResourceEffect(2, -2.25f, 30, "E3PlanOpinionDecrease")};
                        ChangeButtonState(planButton3, true);
                        break;
                    case 4:
                        tempList = new ResourceEffect[] {
                            new ResourceEffect(1, 3f, 30, "E4PlanTreasuryIncrease"),
                            new ResourceEffect(2, -1.5f, 30, "E4PlanOpinionDecrease")};
                        eventDog.GetComponent<EventPlayer>().industrializationForced = 1;
                        ChangeButtonState(planButton4, true);
                        break;
                }
                break;
            case 3:
                switch (planNum)
                {
                    case 1:
                        tempList = new ResourceEffect[] {
                        new ResourceEffect(4, 2.25f, 30, "O1PlanFearIncrease"),
                        new ResourceEffect(2, 1f, 30, "O1PlanOpinionDecrease"),
                        new ResourceEffect(1, 1f, 30, "O1PlanTreasuryDecrease")};
                        ChangeButtonState(planButton1, true);
                        break;
                    case 2:
                        tempList = new ResourceEffect[] {
                        new ResourceEffect(4, 3.25f, 30, "O2PlanFearIncrease"),
                        new ResourceEffect(2, 2f, 30, "O2PlanOpinionDecrease"),
                        new ResourceEffect(1, 1f, 30, "O2PlanTreasuryDecrease")};
                        ChangeButtonState(planButton2, true);
                        break;
                    case 3:
                        tempList = new ResourceEffect[] {
                        new ResourceEffect(2, 2.25f, 30, "O3PlanOpinionIncrease"),
                        new ResourceEffect(4, 1.25f, 30, "O3PlanFearIncrease"),
                        new ResourceEffect(1, 3.25f, 30, "O3PlanTreasuryDecrease")};
                        ChangeButtonState(planButton3, true);
                        break;
                    case 4:
                        tempList = new ResourceEffect[] {
                        new ResourceEffect(4, 2.25f, 30, "O4PlanFearIncrease"),
                        new ResourceEffect(5, 2.25f, 30, "O4PlanScoreIncrease"),
                        new ResourceEffect(2, 3f, 30, "O4PlanOpinionDecrease"),
                        new ResourceEffect(1, 2.25f, 30, "O4PlanTreasuryDecrease")};
                        ChangeButtonState(planButton4, true);
                        break;
                }
                break;
        }
        foreach (ResourceEffect effect in tempList)
        {
            rCtrl.AddEffect(effect);
        }
    }
    public void ChangeButtonState(GameObject button, string effectName)
    {
        if (rCtrl.GetEffect(effectName))
        {
            button.GetComponent<CanvasGroup>().alpha = 0.5f;
            button.GetComponent<CanvasGroup>().interactable = false;
        }
        else
        {
            button.GetComponent<CanvasGroup>().alpha = 1f;
            button.GetComponent<CanvasGroup>().interactable = true;
        }
    }
    public void ChangeButtonState(GameObject button, bool skip)
    {
        if (skip)
        {
            button.GetComponent<CanvasGroup>().alpha = 0.5f;
            button.GetComponent<CanvasGroup>().interactable = false;
        }
        else
        {
            button.GetComponent<CanvasGroup>().alpha = 1f;
            button.GetComponent<CanvasGroup>().interactable = true;
        }
    }
}
