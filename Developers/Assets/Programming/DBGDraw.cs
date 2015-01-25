using UnityEngine;
using System.Collections;

public class DBGDraw : MonoBehaviour {

    void OnDrawGizmos(){
        Gizmos.DrawCube(Grid.GridToWorld(22, 14),Vector3.one);
    }
}
