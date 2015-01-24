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
                m_Instance = new GameObject().AddComponent<Grid>();
                m_Instance.Initialize();
            }
            return m_Instance;
        }
    }
    #endregion

    public void Initialize()
    {
        m_Grid = new List<List<GridInfo>>();
        for (int i=0; i<GridWidth; i++)
        {
            m_Grid.Add(new List<GridInfo>());
            for (int j=0; j<GridHeight; j++)
            {
                m_Grid [i].Add(new GridInfo());
                m_Grid [i] [j].GridXPos = i;
                m_Grid [i] [j].GridYPos = j;
                //m_Grid [i] [j].transform.position = GridStartPos + new Vector3(i, j, 0) * Defaults.GridSquareSize;
            }
        }
    }

    public void Start()
    {
        //Instance.Initialize();
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
        GridInfo ginfo = m_Grid [x] [y];
        return ginfo;
    }
    
    public static int WorldToGridX(float x)
    {
        return (int)((x - GridStartPos.x) / Defaults.GridSquareSize);
    }
    public static int WorldToGridY(float y)
    {
        return (int)((y - GridStartPos.y) / Defaults.GridSquareSize);
    }
    public static Vector3 GridToWorld(int x, int y)
    {
        return GridStartPos + new Vector3(x, y, 0) * Defaults.GridSquareSize;
    }
    public static bool IsInBounds(int x, int y)
    {
        if (x < Instance.GridWidth && x > 0 && y < Instance.GridHeight && y > 0)
            return true;
        else
            return false;
    }

    public static Vector3 SnapToGrid(Vector3 input)
    {
        input.x -= input.x % Defaults.GridSquareSize;
        input.y -= input.y % Defaults.GridSquareSize;
        return input;
    }

}
