//#define DIR4_MOVEMENT


using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(GridMovingObject))]
[AddComponentMenu("Entities/Player")]
public class Player : MonoBehaviour
{
    PlayerInput pi;
    
    Vector3 Destination;
    GridInfo TargetPos;
    bool Moving;
    GridMovingObject GridMovingObject;

    public float MovementSpeedValue;

    // Use this for initialization
    void Start()
    {
        pi = GetComponent<PlayerInput>();
        GridMovingObject = GetComponent<GridMovingObject>();
    }
	
    // Update is called once per frame
    void Update()
    {

        {
            if (TurnManager.State == TurnState.Idle)
            {
                if (pi.MoveForward)
                {
                    StartMove();
                    GridMovingObject.MoveForward();
                } 
#if DIR4_MOVEMENT
                else if (pi.MoveBack)
                {
                    
                }
#endif
                if(pi.DropFlare)
                {

                }
            }
        }
    }

    void StartMove()
    {
        pi.ResetButtons();
        Moving = true;
        TurnManager.DoTurn();
    }
    void StopMove()
    {
        Moving = false;
        
    }



}
