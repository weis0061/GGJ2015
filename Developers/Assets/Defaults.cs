using UnityEngine;
using System.Collections;

public static class Defaults
{
    public const int GridWidth = 25;
    public const int GridHeight = 33;
    public const int LightCharges = 100;
    public const float ControlDeadzone = 0.7f;
    public const float GridSquareSize = 3.0f;
    public const float GridStartX = -33f;//make this a multiple of the GridSquareSize
    public const float GridStartZ = -90f;//make this a multiple of the GridSquareSize
    public const float MovingObjectLerpSnapDistance = 0.15f;
    public const float CharacterRotateSlerp = 3.0f;
    public const float MouseRotateSlerp = 3.0f;
    public const float LowestYPointToFall = -2.0f;
    public const float ResetYPointAfterFall = 1.0f;

}
