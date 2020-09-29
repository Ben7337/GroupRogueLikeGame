using UnityEngine;
using System.Collections;

public class InputScriptExample : MonoBehaviour
{
    //public playerMovement characterMovement;

    private KeyCombo upDash = new KeyCombo(new string[] { "Up", "Up" });
    private KeyCombo rightDash = new KeyCombo(new string[] { "Right", "Right" });
    private KeyCombo leftDash = new KeyCombo(new string[] { "Left", "Left" });

    void Update()
    {
        if (upDash.Check())
        {
            Debug.Log("hi");
            //characterMovement.castDash(8);
        }
        if (rightDash.Check())
        {
            //characterMovement.castDash(6);
        }
        if (leftDash.Check())
        {
            //characterMovement.castDash(4);
        }
    }
}