using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class load_screen : MonoBehaviour
{
    public GameObject loadscreen;
    public Slider valor;
    public void LoadLevel(int index) {

        StartCoroutine(LoadAsynchronously(index));
    }

    IEnumerator LoadAsynchronously(int index) {
        AsyncOperation operation = SceneManager.LoadSceneAsync(index);
        loadscreen.SetActive(true);
        while (!operation.isDone) {
            float progress = Mathf.Clamp01(operation.progress / 1f);
            valor.value = progress;
            yield return null;
        }

    }
    
}
