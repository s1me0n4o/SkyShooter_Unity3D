using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{

    [Tooltip("In mPerSec")]
    [SerializeField] float speed = 50f;

    [Tooltip("In mPerSec")]
    [SerializeField] float xRange = 22f;
    [Tooltip("In mPerSec")]
    [SerializeField] float yRange = 13f;


    // Update is called once per frame
    void Update()
    {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * speed* Time.deltaTime;

        float newXPos = transform.localPosition.x + xOffset;
        float ClampedXPos = Mathf.Clamp(newXPos, -xRange, xRange);


        float yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * speed * Time.deltaTime;
        float newYPos = transform.localPosition.y + yOffset;

        float ClampedYPos = Mathf.Clamp(newYPos, -yRange, yRange);

        transform.localPosition = new Vector3(ClampedXPos, ClampedYPos, transform.localPosition.z);

    }
}
