using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour 
{
    [Tooltip("Amount of score to add")]
    [SerializeField] private int scoreOverTime = 5;
    [Tooltip("Fraction of a second")]
    [SerializeField] private float timeUpdateUnit = 1f;

    private int score = 0;
    private Text scoreText;
    private CollisionHandler player;

	// Use this for initialization
	void Start() 
	{
        scoreText = GetComponent<Text>();
        player = FindObjectOfType<CollisionHandler>();

        UpdateScore();
        InvokeRepeating("IncrementSurvivalScore", 0.1f, timeUpdateUnit);
	}

    public void ScoreHit(int value)
    {
        score += value;
        UpdateScore();
    }

    private void IncrementSurvivalScore()
    {
        if (!player.IsPlayerAlive())
        {
            CancelInvoke();
            return;
        }

        score += scoreOverTime;
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = score.ToString("0000000000");
    }
}
