using UnityEngine;
using System.Collections;

public class GridObject : MonoBehaviour
{

    public Vector2 GridPos;

    GridInfo m_GInfo;
    public GridInfo GridInfo
    {
        get
        {
            return m_GInfo;
        }
        set
        {
            if (m_GInfo != null)
            {
                if (!m_GInfo.ObjectList.Contains(this))
                {
                    m_GInfo.ObjectList.Add(this);
                }
            }
            m_GInfo = value;
        }
    }

    void Start()
    {
        GridInfo = Grid.Instance.GetGridInfo(Grid.WorldToGridX(transform.position.x),
                                           Grid.WorldToGridZ(transform.position.z));
        GridPos = Grid.SnapToGrid(transform.position);
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 0.1f);
    }

    public void SnapToGrid()
    {
        transform.position = Grid.SnapToGrid(transform.position);
    }

}
