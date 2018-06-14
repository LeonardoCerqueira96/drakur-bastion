using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour 
{
    [SerializeField] private int scorePerHit = 100;

    private int score = 0;
    private Text scoreText;

	// Use this for initialization
	void Start() 
	{
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
	}
	
    public void ScoreHit()
    {
        score += scorePerHit;
        scoreText.text = score.ToString();
    }
}
