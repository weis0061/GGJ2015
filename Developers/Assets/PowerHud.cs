using UnityEngine;
using System.Collections;

public class PowerHud : MonoBehaviour
{

    public int Power = Defaults.LightCharges;
    int maxPower;
    public Texture FullPower;
    public Texture MidPower;
    public Texture LowPower;
    public Texture NoPower;
    public Material BatteryMat;
    public Light LightToDisable;

    GameObject[] PowerText;
    TextMesh Text;

    // Use this for initialization
    void Start()
    {
        maxPower = Power;
        PowerText = GameObject.FindGameObjectsWithTag("Power");
        BatteryMat.SetTexture("_MainTex", FullPower);

        for (int i = 0; i < PowerText.Length; i++)
        {
            PowerText [i].GetComponent<TextMesh>().text = "" + Power;

        }
    }
	
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < PowerText.Length; i++)
        {
            PowerText [i].GetComponent<TextMesh>().text = "" + Power;
            
        }

        IconCheck();

    }

    public void ReducePower(int value)
    {
        Power -= value;
        if (Power <= 0)
        {
            Power = 0;
            LightToDisable.enabled = false;
        }
    }

    void IconCheck()
    {
        if (Power <= (maxPower / 2))
        {
            BatteryMat.SetTexture("_MainTex", MidPower);
        }
        if (Power <= (maxPower / 6))
        {
            BatteryMat.SetTexture("_MainTex", LowPower);
        }
        if (Power <= 0)
        {
            BatteryMat.SetTexture("_MainTex", NoPower);
        }

    }

    public int GetPower
    {
        get{ return Power;}
    }
}
