using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashTransition : MonoBehaviour 
{
    [SerializeField] private float loadDelay = 5f;

	// Use this for initialization
	void Start() 
	{
        Invoke("EndSplashScreen", loadDelay);
	}

    private void EndSplashScreen()
    {
        SceneManager.LoadScene(1);
    }
}
