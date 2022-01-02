using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private static string sceneToLoad;

    public static void StartSceneLoading(string scene_name)
    {
        sceneToLoad = scene_name;
        SceneManager.LoadScene("load");
    }

    private void Start()
    {
        var loading = SceneManager.LoadSceneAsync(sceneToLoad);
        loading.allowSceneActivation = true;
    }
}
