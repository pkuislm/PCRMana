// Decompiled with JetBrains decompiler
// Type: Elements.StoryCommandVo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A7E03188-4A33-4E31-B2AA-6FF711CC1BCD
// Assembly location: C:\Users\ASUS\Documents\Tencent Files\1668911954\FileRecv\MobileFile\ksdumper-mod\princessconnectredive_11ED3000.dll

using System;
using System.Collections.Generic;

namespace Elements
{
    public class StoryCommandVo : StoryCommandBase
    {
        private bool isVoicePlaying;
        private string cueName = "";
        private string lipsyncName = "";

        public bool IsVoicePlaying => isVoicePlaying;

        public string LipSyncName => lipsyncName;

        protected override void SetCommandParam()
        {
            cueName = args[0];
            lipsyncName = cueName.Replace("vo_adv_", "").Replace("_", "");
        }

        public override void ExecCommand()
        {
            SetCommandParam();
            //storyManager.LipSync(lipsyncName);
            int num = int.Parse(lipsyncName.Substring(0, 7));
            if (true/*storyManager.NoVoice*/)
            {
                base.ExecCommand();
            }
            else
            {
                /*string voiceCueSheetName1 = storyManager.VoiceCueSheetName;
                if (!soundManager.IsLoadStoryCueSheet(voiceCueSheetName1))
                {
                    base.ExecCommand();
                }
                else
                {
                    string _cueSheet = voiceCueSheetName1;
                    if (num == 1900999)
                    {
                    string voiceCueSheetName2 = storyManager.InsertStoryVoiceCueSheetName;
                    if (!voiceCueSheetName2.IsNullOrEmpty())
                    {
                        if (!soundManager.IsLoadStoryCueSheet(voiceCueSheetName2))
                        {
                        base.ExecCommand();
                        return;
                        }
                        _cueSheet = voiceCueSheetName2;
                    }
                    }
                    soundManager.StopStory();
                    if (storyManager.IsBackLogVoicePlaying)
                    {
                    storyManager.IsBackLogVoicePlaying = false;
                    soundManager.SetStoryVoiceEffect("VoiceReverb", storyManager.VoEffectValue);
                    }
                    float _timeStretchRatio = 1f;
                    soundManager.PlayStoryVoice(_cueSheet, cueName, storyManager.StoryScene.CommandTimeScale, new Action(OnPlayEnd), _timeStretchRatio);
                    isVoicePlaying = true;
                    storyManager.IsVoicePage = true;
                    base.ExecCommand();
                }*/
            }
        }

        public void OnPlayEnd() => isVoicePlaying = false;

        public static string GetVoiceName(List<string> _args) => _args[0];

        private enum eArgs
        {
            VOICE_ID,
            MAX,
        }
    }
}
