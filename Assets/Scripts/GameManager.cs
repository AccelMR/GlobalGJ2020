using UnityEngine;
using UnityEngine.SceneManagement;

public enum GAME_STATE
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
    [SerializeField]
    public bool mPause = true;
  private GAME_STATE m_prevState = GAME_STATE.undefined;

  private GAME_STATE m_gameState = GAME_STATE.mainScreen;
  public GAME_STATE GameState
  {
    get { return m_gameState; }
  }

  private Ship m_player;
  public Ship Player
  {
    get
    {
      if (null == m_player)
      {
        m_player = FindObjectOfType<Ship>();
      }
      return m_player;
    }
  }

  private Gen m_asteroidGenerator;
  public Gen AsteroidGenerator
  {
    get
    {
      if(null == m_asteroidGenerator)
      {
        m_asteroidGenerator = GetComponentInChildren<Gen>();
      }
      return m_asteroidGenerator;
    }
  }

  private static GameManager gameMngr = null;

  // Game Instance Singleton
  public static GameManager GameMngr
  {
    get
    {
      return gameMngr;
    }
  }

  // Start is called before the first frame update
  void Start()
  {
  }

  private void Awake()
  {
    // if the singleton hasn't been initialized yet
    if (gameMngr != null && gameMngr != this)
    {
      Destroy(this.gameObject);
    }

    gameMngr = this;

    DontDestroyOnLoad(this.gameObject);
  }

  // Update is called once per frame
  void Update()
  {
    if(Input.GetButtonDown("pause"))
    {
        m_gameState = GAME_STATE.pause;
    }
    switch (m_gameState)
    {
      case GAME_STATE.gamePlay:
        {
          gamePlayState();
        }
        break;
      case GAME_STATE.pause:
        {
          pauseState();
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

    if(Input.GetKey("up")){
      changeState(GAME_STATE.gamePlay);
    }

  }

  private void
    gamePlayState()
  {
    if (m_gameTime <= 0 || m_prevState == GAME_STATE.mainScreen)
    {

    }

    m_gameTime += Time.fixedDeltaTime;
    m_mainScrnTime = 0;
    m_pauseTime = 0;

    if (Input.GetButtonDown("Submit"))
    {
      m_prevState = m_gameState;
      m_gameState = GAME_STATE.pause;
      //TODO: call scene
     
    }
       
    }
   
  private void
    pauseState()
  {
    m_mainScrnTime = 0;
    m_pauseTime += Time.fixedDeltaTime;

    SceneManager.LoadScene("Pause");

    if (Input.GetButtonDown("pause")&&mPause)
    {
                mPause = false;
            changeState(GAME_STATE.gamePlay);
         //   m_gameTime += (Time.timeScale = 0.0001f);
         
            
    }
   if(!mPause)
        {
           
         //   m_gameTime += (Time.timeScale = 1f);
            mPause = true;
        }


  }

  public void 
    changeState(GAME_STATE state)
  {
    m_prevState = m_gameState;
    m_gameState = state;

        switch (m_gameState)
        {
            case GAME_STATE.gamePlay:
                {
                    if (m_prevState == GAME_STATE.mainScreen)
                    {
                        SceneManager.LoadScene("GameScene");
                        var spawner = new GameObject("Spawner");
                        spawner.tag = "Spawner";
                        AsteroidGenerator.generarAsteroides();
                    }
                    else if (m_prevState == GAME_STATE.pause)
                    {


                    }
                }
                break;
            case GAME_STATE.pause:
                {
                    SceneManager.LoadScene("Pause");
                }
                break;
            case GAME_STATE.undefined:
                {
                }
                break;
            case GAME_STATE.mainScreen:
                {
                    SceneManager.LoadScene("MainMenuScreen");
                }
                break;
            case GAME_STATE.gameOver:
                {
                    SceneManager.LoadScene("UI_GameOver");
                }
                break;

            default:
                break;
        }


    }
}
