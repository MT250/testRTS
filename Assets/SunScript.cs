using UnityEngine;

public class SunScript : MonoBehaviour
{
    public float turnSpeed = 5f;
    void Start()
    {

    }

    private void Update()
    {
        //if (transform.rotation.x == 1) { DynamicLightObject.LightOn(); Debug.LogWarning("Night upon us!"); }
        //else if (transform.rotation.x == 0) DynamicLightObject.LightOff(); Debug.LogWarning("Daylight. For now...");
    }

    void FixedUpdate()
    {
        transform.Rotate(new Vector3(turnSpeed * Time.deltaTime, 0));
    }
}
