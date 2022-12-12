using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    public static T Instance { get; private set; }

    protected void Awake()
    {
        if (Instance == null)
        {
            Instance = (T)this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void DeleteInstane() => Destroy(gameObject);
}

public class SceneLoader : Singleton<SceneLoader>
{
    [SerializeField] float fadeInTime = 0.5f;
    [SerializeField] float fadeOutTime = 0.4f;
    //Scene curScene;

    void LoadScene(string sceneName, LoadSceneMode mode = 0)
    {
        var cvg = gameObject.GetComponent<CanvasGroup>();
        cvg.interactable = true;
        cvg.blocksRaycasts = true;

        var status = SceneManager.LoadSceneAsync(sceneName, mode);
        status.allowSceneActivation = false;

        LeanTween.alphaCanvas(cvg, 1, fadeOutTime).setOnComplete(() => 
        { 
            status.allowSceneActivation = true;
            LeanTween.alphaCanvas(cvg, 0, fadeInTime).setOnComplete(() => 
            { 
                cvg.blocksRaycasts = false; 
                cvg.interactable = false; 
                
            });
        });
    }

    void UnloadScene(string sceneName)
    {
        var cvg = gameObject.GetComponent<CanvasGroup>();
        cvg.interactable = true;
        cvg.blocksRaycasts = true;

        LeanTween.alphaCanvas(cvg, 1, fadeOutTime).setOnComplete(() =>
        {
            SceneManager.UnloadSceneAsync(sceneName);
            Singleton<PageControl>.Instance.Show();
            LeanTween.alphaCanvas(cvg, 0, fadeInTime).setOnComplete(() =>
            {
                Singleton<PageControl>.Instance.ResumeAllMedia();
                cvg.blocksRaycasts = false;
                cvg.interactable = false;
            });
        });
    }

    public void EnterLogin()
    {
        LoadScene("Title");
    }

    public void EnterMain()
    {
        LoadScene("Main"); 
    }

    public void EnterStory()
    {
        //GameObject.Find("EventSystemMainMenu").GetComponent<EventSystem>().enabled = false;
        Singleton<PageControl>.Instance.Hide();
        LoadScene("StoryScene", LoadSceneMode.Additive);
    }

    public void LeaveStory()
    {
        UnloadScene("StoryScene");
        
        //GameObject.Find("EventSystemMainMenu").GetComponent<EventSystem>().enabled = true;
    }
}
