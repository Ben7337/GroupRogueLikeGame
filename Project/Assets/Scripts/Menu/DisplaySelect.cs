using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplaySelect : MonoBehaviour
{
    [Header("Sprite")]
    public SpriteRenderer character;

    [Header("Options")]
    public List<Sprite> options = new List<Sprite>();

    private int currentOption = 0;

    public void NextOption()
    {
        currentOption++;
        if(currentOption >= options.Count)
        {
            currentOption = 0;
        }

        character.sprite = options[currentOption];
    }

    public void PreviousOption()
    {
        currentOption--;
        if(currentOption < 0)
        {
            currentOption = options.Count - 1;
        }

        character.sprite = options[currentOption];
    }
}
