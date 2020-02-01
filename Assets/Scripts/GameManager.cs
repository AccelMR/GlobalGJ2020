using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum GAME_STATE
{
  mainScreen = 0,
  gamePlay,
  pause,
  undefined
};

public class GameManager : MonoBehaviour
{
  [SerializeField]
  private float m_gameTime = 0;
  [SerializeField]
  private float m_mainScrnTime = 0;
  [SerializeField]
  private float m_pauseTime = 0;

  private GAME_STATE m_gameState = GAME_STATE.undefined;

  private GameObject m_player;
  public GameObject Player
  {
    get
    {
      if (null == m_player)
      {
        m_player = GameObject.FindGameObjectWithTag("player");
      }
      return m_player;
    }
  }


  // Start is called before the first frame update
  void Start()
  {
  }

  // Update is called once per frame
  void Update()
  {
    switch (m_gameState)
    {
      case GAME_STATE.gamePlay:
        {
          m_gameTime += Time.fixedDeltaTime;
          m_mainScrnTime = 0;
          m_pauseTime = 0;
        }
        break;
      case GAME_STATE.pause:
        {
          m_gameTime = 0;
          m_mainScrnTime = 0;
          m_pauseTime = Time.fixedDeltaTime;
        }
        break;
      case GAME_STATE.undefined:
        {
          m_gameTime = 0;
          m_mainScrnTime = 0;
          m_pauseTime = 0;
          Debug.Log("Game State error");
        }
        break;
      case GAME_STATE.mainScreen:
        {
          m_gameTime = 0;
          m_mainScrnTime = Time.fixedDeltaTime;
          m_pauseTime = 0;
        }
        break;
    }

  }
}
