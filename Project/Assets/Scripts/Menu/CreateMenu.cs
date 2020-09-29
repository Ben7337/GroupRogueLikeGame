using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateMenu : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene(2);
    }
}
