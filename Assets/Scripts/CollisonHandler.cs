using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisonHandler : MonoBehaviour 
{
    private void OnTriggerEnter(Collider collider)
    {
        StartDeathSequence();
    }

    private void StartDeathSequence()
    {
        SendMessage("OnPlayerDeath");
    }
}
