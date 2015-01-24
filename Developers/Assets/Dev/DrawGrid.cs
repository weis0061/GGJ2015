using UnityEngine;
using System.Collections;

public class DrawGrid : MonoBehaviour
{
#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        for (int i=0; i<Defaults.GridWidth; i++)
        {
            for (int j=0; j<Defaults.GridHeight; j++)
            {
                Gizmos.DrawWireCube(new Vector3(i, 0, j) * Defaults.GridSquareSize + new Vector3(Defaults.GridStartX, 0, Defaults.GridStartZ),
                                    new Vector3(1, 0, 1) * Defaults.GridSquareSize);
            }
        }
    }
#else
    void Start(){GameObject.Destroy(this.gameObject);}
#endif
}
