using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CriWare;

public class CButton : MonoBehaviour
{
    CriAtomExPlayer player;

    public void OnPressed(string seName)
    {
        player.SetCue(null, seName);
        player.Start();
    }

    public void EnterMainMenu()
    {
        //SceneLoader loader = GameObject.Find("SceneLoader").GetComponent<SceneLoader>();
        Singleton<SceneLoader>.Instance.EnterMain();
    }

    private void Start()
    {
        if(player == null)
        {
            player = new CriAtomExPlayer();
        }
    }

    private void OnDestroy()
    {
        if(player != null)
        {
            player.Stop();
            player.Dispose();
        }
    }
}
