using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class TurnManager : MonoBehaviour
{
    #region Singleton
    static TurnManager m_Instance;

    public static TurnManager Instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = new GameObject().AddComponent<TurnManager>();
                m_Instance.Start();
            }
            return m_Instance;
        }
    }
                  #endregion

    public static TurnState State;
    GridMovingObject[] movers;
    public static void DoTurn()
    {
        //GridMovingObject[] movers = FindObjectsOfType<GridMovingObject>();
        State = TurnState.Calculating;

        for (int i=0; i<Instance.movers.Length; i++)
        {
            Monster m = Instance.movers [i].GetComponent<Monster>();
            if (m != null)
            {
                m.DoMove();
            }
        }


        State = TurnState.Showing;
    }




    void Update()
    {


        for (int i=0; i<movers.Length; i++)
        {
            if (!movers [i].FinishedMoving)
            {
                return;
            }
        }
        State = TurnState.Idle;


    }



    void Start()
    {
        movers = FindObjectsOfType<GridMovingObject>();
    }
}
