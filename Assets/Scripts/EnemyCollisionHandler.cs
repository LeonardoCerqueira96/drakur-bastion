using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionHandler : MonoBehaviour 
{

    [SerializeField] private GameObject deathFX;

    private Transform runtimeParent;

	// Use this for initialization
	void Start() 
	{
        runtimeParent = GameObject.Find("Runtime").transform;

        AddNonTriggerCollider();
	}

    private void AddNonTriggerCollider()
    {
        Collider enemyCollider = gameObject.AddComponent<BoxCollider>();
        enemyCollider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        GameObject fxInstance = Instantiate(deathFX, transform.position, Quaternion.identity);
        fxInstance.transform.parent = runtimeParent;
        Destroy(gameObject);
    }
}
