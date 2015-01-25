using UnityEngine;
using System.Collections;

[RequireComponent(typeof(GUITexture))]
public class FadeAndGameState : MonoBehaviour
{
    #region Singleton
    static FadeAndGameState m_Instance;
    public static FadeAndGameState Instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = new GameObject().AddComponent<FadeAndGameState>();
                
            }
            return m_Instance;
        }
    }
    #endregion

    enum GameState
    {
        Playing=0,
        Win,
        Lose
    }
    ;
    Color white = new Color(1, 1, 1, 1);
    Color white_Transparent = new Color(1, 1, 1, 0);
    Color black = new Color(0, 0, 0, 1);
    Color black_Transparent = new Color(0, 0, 0, 0);

    static Color currentCol;

    static float FadeTime = Defaults.GameStateFadeTime;
    static float m_fadeTime;
    static GameState gs;
    

    public GUITexture GUITexture;
    public void Win()
    {
        gs = GameState.Win;
    }

    public void Lose()
    {
        gs = GameState.Lose;
    }

    void OnGUI()
    {
        guiTexture.color = currentCol;
    }

    void Update()
    {
        if (FadeTime > 0.0f)
        {
            m_fadeTime += Time.deltaTime / FadeTime;
            if (gs == GameState.Lose)
            {
                currentCol = Color.Lerp(black_Transparent, black, m_fadeTime);
            } else if (gs == GameState.Win)
            {
                currentCol = Color.Lerp(white_Transparent, white, m_fadeTime);
            } else
            {
                currentCol = black_Transparent;
            }
            if (m_fadeTime >= 1.0f)
            {
                Application.LoadLevel(Application.loadedLevelName);
            }
        } else
        {
            if (gs == GameState.Lose)
            {
                currentCol = black;
            } else if (gs == GameState.Win)
            {
                currentCol = white;
            } else
            {
                currentCol = black_Transparent;
            }
        }
    }

}
