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
        //If we can take input for the player
        if (TurnManager.State == TurnState.Idle)
        {
            ResetButtons();
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
            if(Input.GetButton("Drop Flare"))
            {
                DropFlare = true;
            }



        }
    }

    public void ResetButtons()
    {
        MoveBack = false;
        MoveRight = false;
        MoveLeft = false;
        MoveForward = false;
        DropFlare = false;;
    }

    void Start()
    {
        Deadzone = Defaults.ControlDeadzone;
    }

}
