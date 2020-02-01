using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour
{
    public void RestarGame(string level)
    {
        SceneManager.LoadScene(level);
    }
}
