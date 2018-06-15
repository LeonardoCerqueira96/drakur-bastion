using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionHandler : MonoBehaviour 
{
    [SerializeField] private int scorePerHit = 100;
    [SerializeField] private int hitsLeft = 10;
    [SerializeField] private GameObject deathFX;

    private Transform runtimeParent;
    private ScoreBoard scoreBoard;
    private Collider collider;

    private bool hasBeenKilled = false;

	// Use this for initialization
	void Start() 
	{
        runtimeParent = GameObject.Find("Runtime").transform;
        scoreBoard = FindObjectOfType<ScoreBoard>();

        AddNonTriggerCollider();
	}

    private void AddNonTriggerCollider()
    {
        collider = gameObject.AddComponent<BoxCollider>();
        collider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        if (!hasBeenKilled)
        {
            hitsLeft--;
            
            if (hitsLeft <= 0)
            {
                KillEnemy();
            }
        }
    }

    private void KillEnemy()
    {
        hasBeenKilled = true;

        GameObject fxInstance = Instantiate(deathFX, transform.position, Quaternion.identity);
        fxInstance.transform.parent = runtimeParent;

        scoreBoard.ScoreHit(scorePerHit);

        Destroy(gameObject);
    }
}
