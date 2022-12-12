// Decompiled with JetBrains decompiler
// Type: Elements.StoryCommandBgm
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A7E03188-4A33-4E31-B2AA-6FF711CC1BCD
// Assembly location: C:\Users\ASUS\Documents\Tencent Files\1668911954\FileRecv\MobileFile\ksdumper-mod\princessconnectredive_11ED3000.dll

using System;
using System.Collections.Generic;

namespace Elements
{
    public class StoryCommandBgm : StoryCommandBase
    {
        private string cueSheet = "";
        private string cueName = "";

        public string PlayingBgm { get; private set; }

        public float FadeInTime { get; private set; }

        public int PlayingChannel { get; private set; }

        public bool Loop { get; private set; }

        public float PlayingTime { get; private set; }

        public bool CrossFade { get; private set; }

        //public NIBGCIIGOMC AudioPlayback { get; private set; }

        public override void ExecCommand()
        {
            /*if (args[0] == "stop")
            {
                float _fadeTime = args.Length > 1 ? float.Parse(args[1]) : 0.5f;
                int targetChannel = args.Length > 2 ? int.Parse(args[2]) : 0;
                storyManager.BgmCommandRemoveCueSheetCheck(targetChannel);
                soundManager.StopFadeBgm(targetChannel, _fadeTime, (Action) (() =>
                {
                    if (!storyManager.FadeStopRemoveCueSheetName.IsNullOrEmpty())
                    {
                        soundManager.RemoveCueSheet(storyManager.FadeStopRemoveCueSheetName);
                        NIBGCIIGOMC nibgciigomc;
                        if (storyManager.BgmAudioPlayBackDic.TryGetValue(targetChannel, out nibgciigomc) && storyManager.FadeStopRemoveCueSheetName == nibgciigomc.EHFHMILAFJF)
                            storyManager.BgmAudioPlayBackDic.Remove(targetChannel);
                    }
                    storyManager.IsFadeStopBgm = false;
                    storyManager.FadeStopTargetChannel = -1;
                    storyManager.FadeStopRemoveCueSheetName = "";
                    PlayingBgm = "";
                }));
            }
            else
            {
                string _bgmName = args[0];
                AdvUtility.SetCueSheetAndCueName(_bgmName, out cueName, out cueSheet);
                float num1 = 0.0f;
                int num2 = 0;
                bool _loop = true;
                float _offsetTime = 0.0f;
                bool flag1 = false;
                int length = args.Length;
                int commandTimeScale = storyManager.StoryScene.CommandTimeScale;
                if (length > 1)
                    num1 = float.Parse(args[1]) * (float) commandTimeScale;
                if (length > 2)
                    _loop = int.Parse(args[2]) == 1;
                if (length > 3)
                    num2 = int.Parse(args[3]);
                if (length > 4)
                    _offsetTime = float.Parse(args[4]) / (float) commandTimeScale;
                if (length > 5)
                    flag1 = int.Parse(args[5]) == 1;
                if (flag1)
                {
                    AudioPlayback = soundManager.PlayBGMCrossFade(cueSheet, cueName, num1);
                }
                else
                {
                    bool flag2 = true;
                    NIBGCIIGOMC nibgciigomc;
                    if (storyManager.BgmAudioPlayBackDic.TryGetValue(num2, out nibgciigomc) && nibgciigomc.EHFHMILAFJF == cueSheet && nibgciigomc.LFCGOPHDPHJ == cueName)
                    {
                    flag2 = false;
                    AudioPlayback = nibgciigomc;
                    }
                    if (flag2)
                    AudioPlayback = soundManager.PlayBGM(cueSheet, cueName, num1, num2, _loop, _offsetTime);
                }
                PlayingBgm = _bgmName;
                FadeInTime = num1;
                Loop = _loop;
                PlayingChannel = num2;
                PlayingTime = _offsetTime;
                CrossFade = flag1;
                storyManager.BgmAudioPlayBackDic[num2] = AudioPlayback;
            }*/
            base.ExecCommand();
        }

        public static string GetBgmId(List<string> _args)
        {
            string _cueName = "";
            string _cueSheet = "";
            //AdvUtility.SetCueSheetAndCueName(_args[0], out _cueName, out _cueSheet);
            return _cueSheet;
        }

        public enum eArgs
        {
            CUENAME,
            FADETIME,
            LOOP,
            CHANNEL,
            PLAYTIME,
            CROSSFADE,
            MAX,
        }
    }
}
