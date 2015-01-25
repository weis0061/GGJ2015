using UnityEngine;
using System.Collections;

public class FlareDrop : MonoBehaviour {
    [SerializeField]
    float m_TotalFlares = 6;
    public GameObject FlarePrefab;
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
