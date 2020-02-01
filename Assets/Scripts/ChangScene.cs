using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
public class ChangScene : MonoBehaviour
{
    public int mLevel;
    public void OpenLevel()
    {
        SceneManager.LoadScene(mLevel);
    }
    // Start is called before the first frame update
 
}
