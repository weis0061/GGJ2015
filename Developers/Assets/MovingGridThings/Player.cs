using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(GridMovingObject))]
[RequireComponent(typeof(FlareDrop))]
[RequireComponent(typeof(SnapToGrid))]
[AddComponentMenu("Entities/Player")]
public class Player : MonoBehaviour
{
    PlayerInput PlayerInput;
    
    Vector3 Destination;
    GridInfo TargetPos;
    bool Moving;
    GridMovingObject GridMovingObject;
    FlareDrop flare;
    PowerHud power;


    public float MovementSpeedValue;
    public int lightPowerDecay = 1;

    // Use this for initialization
    void Start()
    {
        PlayerInput = GetComponent<PlayerInput>();
        GridMovingObject = GetComponent<GridMovingObject>();
        flare = GetComponent<FlareDrop>();
        power = GameObject.FindGameObjectWithTag("BatteryPower").GetComponent<PowerHud>();

    }
	
    // Update is called once per frame
    void Update()
    {

        {
            if (TurnManager.State == TurnState.Idle)
            {
                if (PlayerInput.MoveForward)
                {
                    if (GridMovingObject.CanMoveForward)
                    {
                        StartMove();
                        GridMovingObject.MoveForward();
                    }

                } 
                if (PlayerInput.MoveLeft)
                {
                    GridMovingObject.TurnLeft();
                } else if (PlayerInput.MoveRight)
                {
                    GridMovingObject.TurnRight();
                } else if (PlayerInput.MoveBack)
                {
                    GridMovingObject.TurnBack();
                }




                if (PlayerInput.DropFlare)
                {
                    flare.DropFlare(transform.position + transform.TransformDirection(new Vector3(-1, 0, 0)));
                    PlayerInput.DropFlare = false;
                }
            }
        }
    }

    void StartMove()
    {
        Moving = true;
        TurnManager.DoTurn();
        power.ReducePower(lightPowerDecay);
    }
    void StopMove()
    {
        Moving = false;
        
    }



}
