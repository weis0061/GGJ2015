using UnityEngine;
using System.Collections;

[RequireComponent(typeof(GridObject))]
[RequireComponent(typeof(SnapToGrid))]
public class ObstacleBlock : MonoBehaviour
{
    void OnDrawGizmos()
    {
        Gizmos.color = new Color(1f, 0, 0, 0.65f);
        Gizmos.DrawCube(transform.position, Vector3.one * Defaults.GridSquareSize);
    }
}
