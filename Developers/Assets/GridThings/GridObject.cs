using UnityEngine;
using System.Collections;

public class GridObject : MonoBehaviour
{

    public Vector2 GridPos;
    public GridInfo GridInfo;

    void Start()
    {
        GridInfo = Grid.Instance.GetGridInfo(Grid.WorldToGridX(transform.position.x),
                                           Grid.WorldToGridY(transform.position.y));
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 1f);
    }

    public void SnapToGrid()
    {
        transform.position = Grid.SnapToGrid(transform.position);
    }

}
