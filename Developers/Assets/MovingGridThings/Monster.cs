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


    Player Player;
    public Animator Animator;


    void Start()
    {
        MonsterAI = GetComponent<MonsterAI>();
        GridMovingObject = GetComponent<GridMovingObject>();

        Player = FindObjectOfType<Player>();
    }

    public void DoMove()
    {
        MonsterAI.ChooseDirection();
        GridMovingObject.MoveForward();
        if (GridMovingObject.GridInfo.ObjectList.Exists(element => element.GetComponent<Player>() != null))
        {
            FadeAndGameState.Instance.Lose();
        }
    }

    void Update()
    {
        if (Vector3.Distance(Player.transform.position, transform.position) < 1.0f)
        {
            FadeAndGameState.Instance.Lose();
        }
        Animator.SetFloat("Forward", GridMovingObject.Velocity);

    }

}
