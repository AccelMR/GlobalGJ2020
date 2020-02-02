using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
public class ChangScene : MonoBehaviour
{
    
    public void OpenLevel(int NumScence)
    {

        //SceneManager.LoadScene(Lmao);
       if(NumScence ==3)
        {
            GameManager.GameMngr.changeState(GAME_STATE.gamePlay);
        }
       else if(NumScence == 0)
        {
            GameManager.GameMngr.changeState(GAME_STATE.mainScreen);
        }
        else if (NumScence == 1)
        {
            SceneManager.LoadScene(1);
        }
        else if (NumScence == 2)
        {
            GameManager.GameMngr.changeState(GAME_STATE.gameOver);
        }
        else if (NumScence == -1)
        {
            Debug.Log("Si te vas a salir");
            Application.Quit();
        }

    }
    // Start is called before the first frame update

}
