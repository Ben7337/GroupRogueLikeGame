using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCombo
{
    public string[] buttons;
    private int currentIndex = 0; //moves along the array as buttons are pressed

    public float allowedTimeBetweenButtons = 0.20f; //tweak as needed
    private float timeLastButtonPressed;

    public KeyCombo(string[] b)
    {
        buttons = b;
    }

    //usage: call this once a frame. when the combo has been completed, it will return true
    public bool Check()
    {
        if (Time.time > timeLastButtonPressed + allowedTimeBetweenButtons) currentIndex = 0;
        {
            if (currentIndex < buttons.Length)
            {
                Debug.Log(Input.GetButtonDown(buttons[currentIndex]));
                if (/*(buttons[currentIndex] == "down" && Input.GetAxisRaw("Vertical") == -1) ||
                (buttons[currentIndex] == "up" && Input.GetAxisRaw("Vertical") == 1) ||
                (buttons[currentIndex] == "left" && Input.GetAxisRaw("Vertical") == -1) ||
                (buttons[currentIndex] == "right" && Input.GetAxisRaw("Horizontal") == 1) ||*/
                (Input.GetButtonDown(buttons[currentIndex])))
                {
                    timeLastButtonPressed = Time.time;
                    currentIndex++;
                }

                if (currentIndex >= buttons.Length)
                {
                    currentIndex = 0;
                    return true;
                }
                else return false;
            }
        }

        return false;
    }
}