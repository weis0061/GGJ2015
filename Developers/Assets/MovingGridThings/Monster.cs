using UnityEngine;
using System.Collections;

[RequireComponent(typeof(GridObject))]
[RequireComponent(typeof(SnapToGrid))]
[RequireComponent(typeof(MonsterAI))]
[RequireComponent(typeof(GridMovingObject))]
[AddComponentMenu("Entities/Monster")]
public class Monster : MonoBehaviour
{

    MonsterAI MonsterAI;
    GridMovingObject GridMovingObject;


    void Start()
    {
        MonsterAI = GetComponent<MonsterAI>();
        GridMovingObject = GetComponent<GridMovingObject>();
    }

    public void DoMove()
    {
        MonsterAI.ChooseDirection();
        GridMovingObject.MoveForward();
    }

}
