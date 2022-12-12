// Decompiled with JetBrains decompiler
// Type: Elements.StoryCommandEnv
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A7E03188-4A33-4E31-B2AA-6FF711CC1BCD
// Assembly location: C:\Users\ASUS\Documents\Tencent Files\1668911954\FileRecv\MobileFile\ksdumper-mod\princessconnectredive_11ED3000.dll

using System.Collections.Generic;
using UnityEngine;

namespace Elements
{
    public class StoryCommandEnv : StoryCommandBase
    {
        private string cueName = "";
        private int playChannel;
        private bool isLoop;
        private float playTime;
        private int timeScale;

        public string PlayingEnvName => cueName;

        public bool PlayingEnvIsLoop => isLoop;

        public int PlayingEnvIndex => playChannel;

        public float PlayingTime => playTime;

/*    protected override void SetCommandParam()
    {
        int length = args.Length;
        cueName = args[0];
        isLoop = true;
        if (length > 2)
        isLoop = int.Parse(args[2]) == 1;
        playTime = 0.0f;
        if (length > 3)
        playTime = float.Parse(args[3]) / (float) timeScale;
        int num = storyManager.StopPlayingEnv(cueName);
        if (num != -1 && soundManager.IsPlaySE(num))
        soundManager.StopEnv(num);
        playChannel = soundManager.PlayEnv(cueName, isLoop).JBMKLDAFJNL;
    }*/

        public override void ExecCommand()
        {
            /*timeScale = storyManager.StoryScene.CommandTimeScale;
            SetCommandParam();
            storyManager.AddPlayingEnv(cueName, playChannel);*/
            Debug.Log("StoryCommandEnv: " + args[0]);
            base.ExecCommand();
        }

        public static string GetSeId(List<string> _args) => _args[0];

        private enum Args
        {
            CUE_NAME,
            FADE_TIME,
            LOOP,
            PLAY_TIME,
            MAX,
        }
    }
}
