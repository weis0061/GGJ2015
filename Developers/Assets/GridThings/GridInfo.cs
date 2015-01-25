using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GridInfo //: MonoBehaviour
{


    public int GridXPos;
    public int GridYPos;
    
    //to be used for pathing only
    #region pathing
    public int DistToPather = 0;
    public Direction ShortestDirection = Direction.down;
    #endregion

    public GridInfo()
    {

    }
    

    public List<GridObject> ObjectList
    {
        get
        {
            if (m_ObjectList == null)
                m_ObjectList = new List<GridObject>();
            return m_ObjectList;
        }
    }

    List<GridObject> m_ObjectList;
    

}
