﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
public class ChangScene : MonoBehaviour
{
    
    public void OpenLevel(int Lmao)
    {
  
        SceneManager.LoadScene(Lmao);
       
    }
    // Start is called before the first frame update

}
