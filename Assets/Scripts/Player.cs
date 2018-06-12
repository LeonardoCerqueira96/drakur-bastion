using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour 
{
    [Tooltip("In ms^-1")] [SerializeField] private float xSpeed = 3f;
    [Tooltip("In ms^-1")] [SerializeField] private float ySpeed = 3f;

    [Tooltip("In meters")] [SerializeField] private float xRange = 5f;
    [Tooltip("In meters")] [SerializeField] private float yRange = 4f;

    [SerializeField] private float positionPitchFactor = -4;
    [SerializeField] private float controlPitchFactor = -30f;

    [SerializeField] private float positionYawFactor = 4;

    [SerializeField] private float controlRollFactor = -20f;

    private float xThrow, yThrow;

    // Use this for initialization
    void Start() 
	{
		
	}
	
	// Update is called once per frame
	void FixedUpdate()
    {
        CalculateTranslation();
        CalculateRotation();
    }

    private void CalculateTranslation()
    {
        float xPos = GetNewXPosition();
        float yPos = GetNewYPosition();

        transform.localPosition = new Vector3(xPos, yPos, transform.localPosition.z);
    }

    private float GetNewXPosition()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xSpeed * xThrow * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        return clampedXPos;
    }

    private float GetNewYPosition()
    {
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = ySpeed * yThrow * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        return clampedYPos;
    }

    private void CalculateRotation()
    {
        float pitch = transform.localPosition.y * positionPitchFactor + controlPitchFactor * yThrow;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = controlRollFactor * xThrow;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
}
