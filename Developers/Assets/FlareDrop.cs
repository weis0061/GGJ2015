using UnityEngine;
using System.Collections;

public class FlareDrop : MonoBehaviour {
    [SerializeField]
    int m_TotalFlares = 6;
    public GameObject FlarePrefab;

    public int GetAmountOfFlares
    {
        get{ return m_TotalFlares;}
    }

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void DropFlare(Vector3 position)
    {
        if (m_TotalFlares <= 0)
        {
            return;
        }

        Instantiate(FlarePrefab, position, Quaternion.identity);

        m_TotalFlares --;
    }
}
