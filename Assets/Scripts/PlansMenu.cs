using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlansMenu : MonoBehaviour
{
    private bool moveMenu;
    private bool isOpen;
    public GameObject planButton1;
    public GameObject planButton2;
    public GameObject planButton3;
    public GameObject planButton4;
    private void Start()
    {
    }
    private void Update()
    {
        if (moveMenu)
        {
            if (menuOpen == 0)
            {
                transform.position = new Vector3(transform.position.x + Time.deltaTime * 3000, transform.position.y, transform.position.z);
                if (transform.position.x >= 2580)
                {
                    moveMenu = false;
                    isOpen = false;
                }
            }
            else
            {
                transform.position = new Vector3(transform.position.x - Time.deltaTime * 3000, transform.position.y, transform.position.z);
                if (transform.position.x <= 1290)
                {
                    moveMenu = false;
                    isOpen = true;
                }
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
        else if (!isOpen) { moveMenu = true; menuOpen = buttonNum; }
        else
        {
            menuOpen = buttonNum;
            switch (buttonNum)
            {
                case 1:
                    // switch to menu 1
                    break;
                case 2:
                    // switch to menu 2
                    break;
                case 3:
                    // switch to menu 3
                    break;
            }
        }
    }
    public void EnactPlan(int planNum)
    {

    }
}
