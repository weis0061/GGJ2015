using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GridInfo : MonoBehaviour
{


    public int GridXPos;
    public int GridYPos;
    

    public List<GridObject> ObjectList;

    void Start()
    {
        ObjectList = new List<GridObject>();
    }
    

}
