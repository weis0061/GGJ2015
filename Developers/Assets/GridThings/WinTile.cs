using UnityEngine;
using System.Collections;

[RequireComponent(typeof(GridObject))]
[RequireComponent(typeof(SnapToGrid))]
public class WinTile : MonoBehaviour
{
#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 1, 0, 0.65f);
        Gizmos.DrawCube(transform.position, Vector3.one * Defaults.GridSquareSize);
    }
#endif



}
