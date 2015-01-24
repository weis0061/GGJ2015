using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Grid:MonoBehaviour
{


    List<List<GridInfo>> m_Grid;
    
    static int m_GWidth = Defaults.GridWidth;
    static int m_GHeight = Defaults.GridHeight;
    static Vector3 GridStartPos;
    #region Singleton
    static Grid m_Instance;
    public static Grid Instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = ((GameObject)GameObject.Instantiate(new GameObject())).AddComponent<Grid>();
            }
            return m_Instance;
        }
    }
    #endregion

    public void Initialize()
    {
        Debug.Log("Init");
        m_Grid = new List<List<GridInfo>>(GridWidth);
        for (int i=0; i<GridWidth; i++)
        {
            m_Grid [i] = new List<GridInfo>(GridHeight);
            for (int j=0; j<GridHeight; j++)
            {
                m_Grid [i] [j].GridXPos = i;
                m_Grid [i] [j].GridYPos = j;
                m_Grid [i] [j].transform.position = GridStartPos + new Vector3(i, j, 0) * Defaults.GridSquareSize;
                Debug.Log(m_Grid [i] [j]);
            }
        }
    }

    public void Start()
    {
        Instance.Initialize();
    }
    public int GridWidth
    {
        get
        {
            return m_GWidth;
        }
    }
            
    public int GridHeight
    {
        get
        {
            return m_GHeight;
        }
    }

    public GridInfo GetGridInfo(int x, int y)
    {
        if (x < 0 || y < 0 || x >= GridWidth || y >= GridHeight)
        {
            Debug.LogError("ERROR: getting grid position X: " + x + " Y: " + y + " is out of bounds");
            return null;
        }
        Debug.Log("Getting grid info of X: " + x + " Y: " + y);
        GridInfo ginfo = m_Grid [x] [y];
        return ginfo;
    }
    
    public int WorldToGridX(float x)
    {
        return (int)((x - GridStartPos.x) / Defaults.GridSquareSize);
    }
    public int WorldToGridY(float y)
    {
        return (int)((y - GridStartPos.y) / Defaults.GridSquareSize);
    }
    public bool IsInBounds(int x, int y)
    {
        return false;
    }

}
