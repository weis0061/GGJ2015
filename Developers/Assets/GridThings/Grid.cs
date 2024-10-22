﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Grid:MonoBehaviour
{


    List<List<GridInfo>> m_Grid;
    
    static int m_GWidth = Defaults.GridWidth;
    static int m_GHeight = Defaults.GridHeight;
    static Vector3 GridStartPos = new Vector3(Defaults.GridStartX, 0, Defaults.GridStartZ);
    public static int NumberOfTiles
    {
        get
        {
            return Instance.GridWidth * Instance.GridHeight;
        }
           
    }
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
                GridInfo GridToAdd = new GridInfo();
                GridToAdd.GridXPos = i;
                GridToAdd.GridYPos = j;
                m_Grid [i].Add(GridToAdd);
                //m_Grid [i] [j].GridXPos = i;
                //m_Grid [i] [j].GridYPos = j;
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
        
        GridInfo ginfo; 
        /*
        if (x < 0 || y < 0 || x >= GridWidth || y >= GridHeight)
        {
            Debug.LogError("ERROR: getting grid position X: " + x + " Y: " + y + " is out of bounds");
            return null;
        }
        if (m_Grid.Count <= x)
        {
            ginfo = null;
        } else if (m_Grid [x].Count <= y)
        {
            ginfo = null;
        } else*/

        if (IsInBounds(x, y))
        {
            //if the values are in index range, then actually look up the entity
            ginfo = m_Grid [x] [y];
            return ginfo;
        } else
            return null;
    }
    
    public static int WorldToGridX(float x)
    {
        return (int)((x - GridStartPos.x) / Defaults.GridSquareSize);
    }
    public static int WorldToGridZ(float y)
    {
        return (int)((y - GridStartPos.z) / Defaults.GridSquareSize);
    }
    public static Vector3 GridToWorld(int x, int y)
    {
        return GridStartPos + new Vector3(x, 0, y) * Defaults.GridSquareSize;
    }
    public static bool IsInBounds(int x, int y)
    {
        if (x < Instance.GridWidth && x >= 0 && y < Instance.GridHeight && y >= 0)
            return true;
        else
            return false;
    }

    public static Vector3 SnapToGrid(Vector3 input)
    {
        input.x -= input.x % Defaults.GridSquareSize;
        input.z -= input.z % Defaults.GridSquareSize;
        return input;
    }

}
