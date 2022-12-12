using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreloadScene : MonoBehaviour
{
    [RuntimeInitializeOnLoadMethod]
    static void Initialize()
    {
        string startSceneName = "Logo";
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name.Equals(startSceneName))
        {
            return;
        }
        SceneManager.LoadScene(startSceneName);
    }


}
