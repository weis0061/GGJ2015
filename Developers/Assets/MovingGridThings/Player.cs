//#define DIR4_MOVEMENT


using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(GridMovingObject))]
[RequireComponent(typeof(FlareDrop))]
[AddComponentMenu("Entities/Player")]
public class Player : MonoBehaviour
{
    PlayerInput PlayerInput;
    
    Vector3 Destination;
    GridInfo TargetPos;
    bool Moving;
    GridMovingObject GridMovingObject;
    FlareDrop flare;

    public float MovementSpeedValue;

    // Use this for initialization
    void Start()
    {
        PlayerInput = GetComponent<PlayerInput>();
        GridMovingObject = GetComponent<GridMovingObject>();
        flare = GetComponent<FlareDrop>();

    }
	
    // Update is called once per frame
    void Update()
    {

        {
            if (TurnManager.State == TurnState.Idle)
            {
                if (PlayerInput.MoveForward)
                {
                    StartMove();
                    GridMovingObject.MoveForward();
                } 
#if DIR4_MOVEMENT
                else if (pi.MoveBack)
                {
                    
                }
                #endif
                if(PlayerInput.MoveLeft){
                    GridMovingObject.TurnLeft();
                }
                else if(PlayerInput.MoveRight){
                    GridMovingObject.TurnRight();
                }
                else if(PlayerInput.MoveBack){
                    GridMovingObject.TurnBack();
                }




                if(PlayerInput.DropFlare)
                {
                    Debug.Log("Flare Droped");
                    flare.DropFlare(transform.position);
                    PlayerInput.DropFlare = false;
                }
            }
        }
    }

    void StartMove()
    {
        PlayerInput.ResetButtons();
        Moving = true;
        TurnManager.DoTurn();
    }
    void StopMove()
    {
        Moving = false;
        
    }



}
