using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBarController : MonoBehaviour
{
    [SerializeField]
    private Text ScoreText;

    int score;
    void Start()
    {
        
       
    }

    void Update()
    {

    }
    public void ChangeScore(int value)
    {
        score += value;
        ScoreText.text =score.ToString();

    }
   
}
