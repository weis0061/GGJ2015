using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FlareHud : MonoBehaviour {

    public GameObject GuiFlare;
    public float Spacing = 2.0f;

    GameObject startPos;
    List<GameObject> Flares;
    FlareDrop flare;

	// Use this for initialization
	void Start () 
    {
        flare = GameObject.FindGameObjectWithTag("Player").GetComponent<FlareDrop>();
        startPos = GameObject.FindGameObjectWithTag("FlareStartPos");
        Flares = new List<GameObject>();

        if (GuiFlare != null)
        {
            Vector3 temp = startPos.transform.position;

            for (int i = 0; i <= flare.GetAmountOfFlares; i++)
            {
                Flares.Add((GameObject)Instantiate(GuiFlare, temp, Quaternion.AngleAxis(-90.0f, Vector3.right)));
                Flares[i].transform.parent = startPos.transform;
                temp.x += Spacing;
            }

        }



	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Flares != null)
        {
            for(int i =0; i < Flares.Count; i++)
            {
                if(Flares[i].activeSelf && i == flare.GetAmountOfFlares)
                {
                    Flares[i].SetActive(false);
                }
            }
        }
	    
	}
}
