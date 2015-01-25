using UnityEngine;
using System.Collections;

[RequireComponent(typeof(GridObject))]
[RequireComponent(typeof(CharacterController))]
public class GridMovingObject : MonoBehaviour
{

    int XTarget;

    int YTarget;
    [HideInInspector]
    public bool
        FinishedMoving;
    public float AestheticMoveSpeedDivider;
    public Direction FaceDirection;
    GridObject GridObject;
    GridInfo GridTarget;
    GridInfo GridInfo;
    public void SetMoveTarget(int x, int y)
    {
        XTarget = x;
        YTarget = y;
        GridInfo.ObjectList.Remove(GridObject);
        GridTarget = Grid.Instance.GetGridInfo(x, y);
        GridInfo = GridTarget;
    }
    void Start()
    {
        GridObject = GetComponent<GridObject>();
        GridInfo = Grid.Instance.GetGridInfo(Grid.WorldToGridX(transform.position.x),
                                           Grid.WorldToGridZ(transform.position.z));
    }
    public void MoveForward()
    {
        if (CanMoveForward)
        {
            SetMoveTarget(ForwardMovePos.GridXPos, ForwardMovePos.GridYPos);
        }
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
            else if (ForwardMovePos.ObjectList.Exists(element => element.GetComponent<ObstacleBlock>() != null))
            {
                return false;
            }
            return true;
        }

    }
    GridInfo ForwardMovePos
    {
        get
        {
            GridInfo ginfo;
            int gposX = GridInfo.GridXPos;
            int gposY = GridInfo.GridYPos;
            if (FaceDirection == Direction.down)
            {
                gposY++;
            } else if (FaceDirection == Direction.up)
            {
                gposY--;
            } else if (FaceDirection == Direction.right)
            {
                gposX++;
            } else //facing left
            {
                gposX--;

            } 
            if (Grid.IsInBounds(gposX, gposY))
            {
                ginfo = Grid.Instance.GetGridInfo(gposX, gposY);
            } else
                ginfo = GridInfo;
            return ginfo;
        }
    }

    void Update()
    {
        UpdateRotation();
        if (TurnManager.State == TurnState.Showing)
        {
            StepTo(Grid.GridToWorld(XTarget, YTarget), AestheticMoveSpeedDivider);
        } else if (TurnManager.State == TurnState.Idle)
        {
            FinishedMoving = false;
        }
    }

    public void StepTo(Vector3 position, float SpeedDivider)
    {
        transform.position += (position - transform.position) / SpeedDivider;
        if ((position - transform.position).magnitude < Defaults.MovingObjectLerpSnapDistance)
        {
            transform.position = position;
            FinishedMoving = true;
        }
    }

    public void TurnLeft()
    {
        FaceDirection += 1;
        if (FaceDirection > (Direction)3)
        {
            FaceDirection = (Direction)0;
        }
    }
    public void TurnRight()
    {
        FaceDirection -= 1;
        if (FaceDirection < (Direction)0)
        {
            FaceDirection = (Direction)3;
        }
    }
    public void TurnBack()
    {
        TurnRight();
        TurnRight();
    }
    void UpdateRotation()
    {
        Quaternion targetRotation = new Quaternion(0, (int)FaceDirection * 90, 0, 0);

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime);
    }





}
