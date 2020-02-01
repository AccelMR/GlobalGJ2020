using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class ReturnMenu : MonoBehaviour
{
   public void MenuReturn(string level)
    {
        SceneManager.LoadScene(level);
    }
}
