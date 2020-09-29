using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSelect : MonoBehaviour
{
    [Header("Sprite")]
    public SpriteRenderer character;

    [Header("Animator")]
    public Animator charAnimator;

    [Header("Options")]
    public List<Sprite> options = new List<Sprite>();

    [Header("Animation Options")]
    public List<RuntimeAnimatorController> animOptions = new List<RuntimeAnimatorController>();

    private int currentOption = 0;
    void Start()
    {
        charAnimator.runtimeAnimatorController = animOptions[0] as RuntimeAnimatorController;
    }

    public void NextOption()
    {
        currentOption++;
        if(currentOption>= options.Count)
        {
            currentOption = 0;
        }

        character.sprite = options[currentOption];
        charAnimator.runtimeAnimatorController = animOptions[currentOption] as RuntimeAnimatorController;
    }

    public void PreviousOption()
    {
        currentOption--;
        if(currentOption < 0)
        {
            currentOption = options.Count - 1;
        }

        character.sprite = options[currentOption];
        charAnimator.runtimeAnimatorController = animOptions[currentOption] as RuntimeAnimatorController;
    }
}
