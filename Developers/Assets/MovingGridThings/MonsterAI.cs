using UnityEngine;
using System.Collections;

[RequireComponent(typeof(GridPather))]
[RequireComponent(typeof(GridMovingObject))]
public class MonsterAI : MonoBehaviour
{

    GridMovingObject GridMovingObject;
    GridPather GridPather;

    void Start()
    {
        GridMovingObject = GetComponent<GridMovingObject>();
        GridPather = GetComponent<GridPather>();
    }
    public void ChooseDirection()
    {
        GridMovingObject.FaceDirection = GridPather.BestPathDir(FindObjectOfType<Player>().GetComponent<GridObject>().GridInfo);
    }


}
