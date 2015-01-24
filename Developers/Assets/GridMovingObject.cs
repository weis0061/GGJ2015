using UnityEngine;
using System.Collections;

[RequireComponent(typeof(GridObject))]
public class GridMovingObject : MonoBehaviour
{
    public int XTarget;
    public int YTarget;
    [HideInInspector]
    public bool
        FinishedMoving;
    public float VisualMoveSpeed;
    Direction FaceDirection;
    GridObject GridObject;
    GridInfo GridTarget;
    public void SetMoveTarget(int x, int y)
    {
        XTarget = x;
        YTarget = y;
        GridTarget = Grid.Instance.GetGridInfo(x, y);
    }
    void Start()
    {
        GridObject = GetComponent<GridObject>();
    }
    public void MoveForward()
    {
        SetMoveTarget(ForwardMovePos.GridXPos, ForwardMovePos.GridYPos);
    }
    void DetermineDirection()
    {
        float ydir = transform.rotation.eulerAngles.y % 360;
        if (ydir > 315 || ydir < 45)
        {
            FaceDirection = Direction.right;
            return;
        }
        if (ydir >= 45)
        {
            FaceDirection = Direction.down;
        }
        if (ydir >= 135)
        {
            FaceDirection = Direction.left;
        }
        if (ydir >= 225)
        {
            FaceDirection = Direction.up;
        }
    }
    public bool CanMoveForward
    {
        get
        {
            if (ForwardMovePos.GridXPos < 0)
            {
                return false;
            } else if (ForwardMovePos.GridYPos < 0)
            {
                return false;
            } else if (ForwardMovePos.GridXPos >= Grid.Instance.GridWidth)
            {
                return false;
            } else if (ForwardMovePos.GridYPos >= Grid.Instance.GridHeight)
            {
                return false;
            }

            //TODO: check if there is a wall or obstacle in the way
            else if (false)
            {

            }
            return true;
        }

    }
    GridInfo ForwardMovePos
    {
        get
        {
            GridInfo ginfo;
            if (FaceDirection == Direction.down)
            {
                ginfo = Grid.Instance.GetGridInfo((int)GridObject.GridPos.x, (int)GridObject.GridPos.y + 1);
            } else if (FaceDirection == Direction.up)
            {
                ginfo = Grid.Instance.GetGridInfo((int)GridObject.GridPos.x, (int)GridObject.GridPos.y - 1);
            } else if (FaceDirection == Direction.right)
            {
                ginfo = Grid.Instance.GetGridInfo((int)GridObject.GridPos.x + 1, (int)GridObject.GridPos.y);
            } else
            {
                ginfo = Grid.Instance.GetGridInfo((int)GridObject.GridPos.x - 1, (int)GridObject.GridPos.y);
            } 
            if (ginfo == null)
            {
                ginfo = GridObject.GridInfo;
            }
            return ginfo;
        }
    }

    void Update()
    {
        if (TurnManager.State == TurnState.Showing)
        {
            StepTo(GridTarget.transform.position, VisualMoveSpeed);
        } else if (TurnManager.State == TurnState.Idle)
        {
            FinishedMoving = false;
        }
    }

    public void StepTo(Vector3 position, float SpeedDivider)
    {
        transform.position += (position - transform.position) / SpeedDivider;
    }
}
