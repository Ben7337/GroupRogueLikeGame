using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI textMesh;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        textMesh = gameObject.GetComponent<TextMeshProUGUI>();
        textMesh.text = "score: " + score;
    }

    public int addScore(int addition)
    {
        score += addition;
        textMesh.text = "score: " + score;
        return score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
