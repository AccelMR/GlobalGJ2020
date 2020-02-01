using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class ReturnMain : MonoBehaviour
{
    public void ReturnMainMenu(string level)
    {
        SceneManager.LoadScene(level);
    }
}
