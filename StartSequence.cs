using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CriWare;
using CriWare.CriMana;

public class StartSequence : MonoBehaviour
{
    public CriManaMovieControllerForUI movie;
    public RectTransform rectTransform;

    // Start is called before the first frame update
    void Start()
    {
        if(movie == null)
        {
            movie = new CriManaMovieControllerForUI();
        }
        movie.player.SetFile(null, "view_splash_h264.usm");
        movie.player.SetAudioTrack(2);
        movie.player.Prepare();
    }

    // Update is called once per frame
    void Update()
    {
        switch(movie.player.status)
        {
            case Player.Status.PlayEnd:
                movie.player.Stop();
                Singleton<SceneLoader>.Instance.EnterLogin();
                break;
            case Player.Status.Ready:
                rectTransform.sizeDelta = new Vector2(movie.player.movieInfo.width, movie.player.movieInfo.height);
                rectTransform.anchoredPosition = new Vector2(0, -movie.player.movieInfo.height / 2);
                movie.player.Start();
                break;
            default:
                break;
        }
    }

    private void OnDestroy()
    {
        if(movie != null)
        {
            movie.player.Stop();
            movie.player.Dispose();
        }
    }
}
