using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    [Header("General")]
    [Tooltip("In mPerSec")]
    [SerializeField] float speed = 50f;
    [Tooltip("In mPerSec")]
    [SerializeField] float xRange = 22f;
    [Tooltip("In mPerSec")]
    [SerializeField] float yRange = 13f;

    [Header("Screen-Position Based")]
    // We are mutiplying the factors to receive the desieed effects
    [SerializeField] float positionPitchFactor = -1.5f;
    [SerializeField] float controlPitchFactor = -30f;
    [SerializeField] float positionYawFactor = -1.5f;
    [SerializeField] float controlRowFactor = -50f;

    float xThrow, yThrow;
    bool isControlEnabled = true;

    // Update is called once per frame
    void Update()
    {
        if (isControlEnabled)
        {
            Movement();
            Rotation();
        }
    }

    void OnPlayerDeath() //called by string reference
    {
        isControlEnabled = false;
    }

    private void Rotation()
    {
        float x = (transform.localPosition.y * positionPitchFactor) + (yThrow * controlPitchFactor);
        float y = transform.localPosition.x * positionYawFactor;
        float z = xThrow * controlRowFactor;
        transform.localRotation = Quaternion.Euler(x, y, z);
    }

    private void Movement()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * speed * Time.deltaTime;

        float newXPos = transform.localPosition.x + xOffset;
        float ClampedXPos = Mathf.Clamp(newXPos, -xRange, xRange);


        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * speed * Time.deltaTime;
        float newYPos = transform.localPosition.y + yOffset;

        float ClampedYPos = Mathf.Clamp(newYPos, -yRange, yRange);

        transform.localPosition = new Vector3(ClampedXPos, ClampedYPos, transform.localPosition.z);
    }
}
