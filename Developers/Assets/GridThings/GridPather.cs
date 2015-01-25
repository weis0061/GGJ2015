using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(GridObject))]
public class GridPather : MonoBehaviour
{

    
    List<GridInfo> PassedTiles;
    List<GridInfo> TileList;
    int LowestTileNumber;
    int PlayerPosX;
    int PlayerPosY;
    GridInfo Target;

    Direction BestPathDir()
    {
        Target = PlayerGridPos;
        if (PlayerGridPos == null)
        {
            return Direction.down;
        }
        PassedTiles = new List<GridInfo>();

        GridInfo gInfo = GetComponent<GridObject>().GridInfo;
        
        RecursivelyCheckAdjacentTiles(0, Grid.Instance.GetGridInfo(gInfo.GridXPos + 1, gInfo.GridYPos), Direction.right);
        RecursivelyCheckAdjacentTiles(0, Grid.Instance.GetGridInfo(gInfo.GridXPos, gInfo.GridYPos + 1), Direction.down);
        RecursivelyCheckAdjacentTiles(0, Grid.Instance.GetGridInfo(gInfo.GridXPos - 1, gInfo.GridYPos), Direction.left);
        RecursivelyCheckAdjacentTiles(0, Grid.Instance.GetGridInfo(gInfo.GridXPos, gInfo.GridYPos - 1), Direction.up);

        for (int i=0; i<TileList.Count; i++)
        {
            TileList [i].DistToPather = 0;
        }

        return Target.ShortestDirection;
    }
    void RecursivelyCheckAdjacentTiles(int StepNumber, GridInfo Tile, Direction dir)
    {
        StepNumber++;

        if (Tile == null)
        {
            return;
        }

        if (PassedTiles.Contains(Tile))
        {
            if (Tile.DistToPather > StepNumber)
            {
                Tile.DistToPather = StepNumber;
                Tile.ShortestDirection = dir;
                RecursivelyCheckAdjacentTiles(StepNumber, Grid.Instance.GetGridInfo(Tile.GridXPos + 1, Tile.GridYPos), dir);
                RecursivelyCheckAdjacentTiles(StepNumber, Grid.Instance.GetGridInfo(Tile.GridXPos, Tile.GridYPos + 1), dir);
                RecursivelyCheckAdjacentTiles(StepNumber, Grid.Instance.GetGridInfo(Tile.GridXPos - 1, Tile.GridYPos), dir);
                RecursivelyCheckAdjacentTiles(StepNumber, Grid.Instance.GetGridInfo(Tile.GridXPos, Tile.GridYPos - 1), dir);

            }
        } else

            //if the tile wasn't already checked
        {
            PassedTiles.Add(Tile);

            //if the tile has an obstacle on it
            if (Tile.ObjectList.Exists(element => element.GetComponent<ObstacleBlock>() != null))
            {
                return;
            }
            RecursivelyCheckAdjacentTiles(StepNumber, Grid.Instance.GetGridInfo(Tile.GridXPos + 1, Tile.GridYPos), dir);
            RecursivelyCheckAdjacentTiles(StepNumber, Grid.Instance.GetGridInfo(Tile.GridXPos, Tile.GridYPos + 1), dir);
            RecursivelyCheckAdjacentTiles(StepNumber, Grid.Instance.GetGridInfo(Tile.GridXPos - 1, Tile.GridYPos), dir);
            RecursivelyCheckAdjacentTiles(StepNumber, Grid.Instance.GetGridInfo(Tile.GridXPos, Tile.GridYPos - 1), dir);
        }

        if (Tile == Target)
        {
            if (LowestTileNumber > StepNumber)
            {
                Tile.DistToPather = StepNumber;
                Tile.ShortestDirection = dir;
            }
        }

        
    }

    GridInfo PlayerGridPos
    {
        get
        {
            GameObject playerobj = FindObjectOfType<Player>().gameObject;
            return playerobj.GetComponent<GridObject>().GridInfo;
        }
    }
}
