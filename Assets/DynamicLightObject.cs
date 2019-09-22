using System.Collections.Generic;
using UnityEngine;

public class DynamicLightObject : MonoBehaviour
{
    public Light lightSource;
    public ParticleSystem lightEffect;
    [Space]
    private static List<Light> AllLightObjects = new List<Light>();
    private static List<ParticleSystem> AllLightEffects = new List<ParticleSystem>();

    private static bool lightEnabled = true;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)) //TODO: Performs on each instance of object. Ex.: 2 obj - 2 times, 7 obj - 7 times.
        {
            Debug.Log("Pressed");
            if (lightEnabled == true) { LightOff(); lightEnabled = false; Debug.Log("Lights out!"); }
            else if (lightEnabled == false) { LightOn(); lightEnabled = true; Debug.Log("Let there be light!"); }
            Debug.Log("out");
        }
    }


    void Start()
    {
        //lightEffect = GetComponent<ParticleSystem>();
        //lightSource = GetComponent<Light>();
    }

    public void OnEnable()
    {
        AllLightObjects.Add(lightSource);
        AllLightEffects.Add(lightEffect);
    }

    public static void LightOn()
    {
        foreach (Light lightSrc in AllLightObjects)
        {
            lightSrc.enabled = true;
        }
        foreach (ParticleSystem particleSystem in AllLightEffects)
        {

            particleSystem.Play();
        }
        lightEnabled = true;
    }

    public static void LightOff()
    {
        foreach (Light lightSrc in AllLightObjects)
        {
            lightSrc.enabled = false;
        }
        foreach (ParticleSystem particleSystem in AllLightEffects)
        {
            particleSystem.Stop();
        }
        lightEnabled = false;
    }
}
