using UnityEngine;
using System.Collections;

public class GridObject : MonoBehaviour
{
    #if UNITY_EDITOR
    public Vector2 GridPos;
#endif
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
                if (m_GInfo.ObjectList.Contains(this))
                {
                    m_GInfo.ObjectList.Remove(this);
                }
            }
            m_GInfo = value;
            
            if (m_GInfo != null)
            {
                if (!m_GInfo.ObjectList.Contains(this))
                {
                    m_GInfo.ObjectList.Add(this);
                }
            }
        }
    }

    void Start()
    {
        GridInfo = Grid.Instance.GetGridInfo(Grid.WorldToGridX(transform.position.x),
                                           Grid.WorldToGridZ(transform.position.z));
#if UNITY_EDITOR
        GridPos = new Vector2(GridInfo.GridXPos, GridInfo.GridYPos);
#endif
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
