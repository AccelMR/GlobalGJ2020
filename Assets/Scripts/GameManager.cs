﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

enum GAME_STATE
{
  mainScreen = 0,
  gamePlay,
  pause,
  gameOver,
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
  [SerializeField]
  private float m_gameOverTime = 0;

  private GAME_STATE m_gameState = GAME_STATE.gamePlay;

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
  private void Awake()
  {
    DontDestroyOnLoad(this.gameObject);
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

          if (Input.GetButtonDown("Submit"))
          {
            m_gameState = GAME_STATE.pause;
            //TODO: call scene
          }

        }
        break;
      case GAME_STATE.pause:
        {
          m_gameTime = 0;
          m_mainScrnTime = 0;
          m_pauseTime += Time.fixedDeltaTime;

          if (Input.GetButtonDown("Submit"))
          {
            m_gameState = GAME_STATE.gamePlay;
            //TODO call scene
          }
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
          m_mainScrnTime += Time.fixedDeltaTime;
          m_pauseTime = 0;
        }
        break;
      case GAME_STATE.gameOver:
        {
          m_gameTime = 0;
          m_mainScrnTime = 0;
          m_pauseTime = 0;
          m_gameOverTime += Time.fixedDeltaTime; 
        }
        break;
      default:
        break;
    }

  }
}
