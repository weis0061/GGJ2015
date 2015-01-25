using UnityEngine;
using System.Collections;

public class PowerHud : MonoBehaviour {

    public int Power = 100;

	// Use this for initialization
	void Start () 
    {
        GetComponent(TextMesh).guiText = Power.ToString;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
