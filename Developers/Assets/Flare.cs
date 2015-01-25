using UnityEngine;
using System.Collections;

public class Flare : MonoBehaviour {
   
    float lightTimer = 1.0f;
    public float lightIntensityMin = 0.5f;
    public float lightIntensityMax = 1.0f;
    bool isLightOn = true;

    // Use this for initialization
    void Start () 
    {
        
    }
    
    // Update is called once per frame
    void Update () 
    {
        lightTimer -= Time.deltaTime;
        
        //checks if the light is on
        if(isLightOn)
        {
            //checks if the light timer is less or equal to zero
            if( lightTimer <= 0)
            {
                //changes the intensity of the light to zero (off)
                this.gameObject.light.intensity = Random.Range(lightIntensityMin, lightIntensityMax);
                isLightOn = false;
                //resets the timer to a random value between 0 and 0.666
                lightTimer = Random.Range(0.0f, lightTimer);
            }
        }
        
        //checks if the light is off
        if(!isLightOn)
        {
            //checks if the timer is less than 0
            if( lightTimer <= 0)
            {
                //sets the light intensity
                this.gameObject.light.intensity = Random.Range(lightIntensityMin, lightIntensityMax);
                isLightOn = true;
                lightTimer = Random.Range(0.0f, lightTimer);
            }
        }   
    }
    
}
