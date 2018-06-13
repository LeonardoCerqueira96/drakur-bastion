using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisonHandler : MonoBehaviour 
{
    [Tooltip("In seconds")] [SerializeField] private float reloadDelay = 1f;
    [Tooltip("FX prefab on player")] [SerializeField] private GameObject deathFX;


    private void OnTriggerEnter(Collider collider)
    {
        StartDeathSequence();
    }

    private void StartDeathSequence()
    {
        SendMessage("OnPlayerDeath");
        deathFX.SetActive(true);
        Invoke("ReloadLevel", reloadDelay);
    }

    private void ReloadLevel() // string referenced
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
