using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour 
{
    [Header("General")]
    [Tooltip("In ms^-1")] [SerializeField] private float horizontalSpeed = 3f;
    [Tooltip("In ms^-1")] [SerializeField] private float verticalSpeed = 3f;
    [Tooltip("In meters")] [SerializeField] private float xRange = 5f;
    [Tooltip("In meters")] [SerializeField] private float yRange = 4f;

    [Header("Screen position based")]
    [SerializeField] private float positionPitchFactor = -4f;
    [SerializeField] private float positionYawFactor = 4f;

    [Header("Control axis based")]
    [SerializeField] private float controlPitchFactor = -30f;
    [SerializeField] private float controlRollFactor = -20f;

    private float xThrow, yThrow;
    private bool isControlEnabled = true;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isControlEnabled)
        {
            CalculateTranslation();
            CalculateRotation();
        }
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
        float xOffset = horizontalSpeed * xThrow * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        return clampedXPos;
    }

    private float GetNewYPosition()
    {
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = verticalSpeed * yThrow * Time.deltaTime;
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

    private void OnPlayerDeath() // called by string reference
    {
        DisableControls();
    }

    private void DisableControls()
    {
        isControlEnabled = false;
        Debug.Log("Controls disabled");
    }
}
