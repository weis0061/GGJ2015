using UnityEngine;
using System.Collections;

[RequireComponent(typeof(GridObject))]
public class SnapToGrid : MonoBehaviour
{
    void Start()
    {
        Snap();
    }
    public void Snap()
    {
        GetComponent<GridObject>().SnapToGrid();
    }
}
