using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderDelay : MonoBehaviour
{
    [SerializeField]
    string sceneToLoad;

    [SerializeField]
    float secondsToDelay;

    bool isLoading = false;

    public void LoadScene()
    {
        if (!isLoading)
        {
            isLoading = true;
            StartCoroutine(WaitThenLoad());
        }
    }

    IEnumerator WaitThenLoad()
    {
        yield return new WaitForSeconds(secondsToDelay);
        SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
        isLoading = false;
    }
}
