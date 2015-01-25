using UnityEngine;
using System.Collections;


public class PlayerInput : MonoBehaviour
{
    public bool MoveLeft;
    public bool MoveRight;
    public bool MoveForward;
    public bool MoveBack;
    public bool DropFlare;

    public float Deadzone;

    void Update()
    {
        ResetButtons();
        //If we can take input for the player
        if (TurnManager.State == TurnState.Idle)
        {
            if (Input.GetButtonDown("Move Left"))
            {
                MoveLeft = true;
            }
            if (Input.GetButtonDown("Move Right"))
            {
                MoveRight = true;
            }
            if (Input.GetButtonDown("Move Forward"))
            {
                MoveForward = true;
            }
            if (Input.GetButtonDown("Move Back"))
            {
                MoveBack = true;
            }
            if (Input.GetButtonDown("Drop Flare"))
            {
                DropFlare = true;
            }



        }
        MoveForward = Input.GetButton("Move Forward");
    }

    public void ResetButtons()
    {
        MoveBack = false;
        MoveRight = false;
        MoveLeft = false;
        MoveForward = false;
    }

    void Start()
    {
        Deadzone = Defaults.ControlDeadzone;
    }

}
