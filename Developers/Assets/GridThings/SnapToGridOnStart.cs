using UnityEngine;
using System.Collections;

[RequireComponent(typeof(GridObject))]
public class SnapToGridOnStart : MonoBehaviour
{
    void Start()
    {
        GetComponent<GridObject>().SnapToGrid();
    }
}
