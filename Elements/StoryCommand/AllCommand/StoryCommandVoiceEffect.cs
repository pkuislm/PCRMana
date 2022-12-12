// Decompiled with JetBrains decompiler
// Type: Elements.StoryCommandVoiceEffect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A7E03188-4A33-4E31-B2AA-6FF711CC1BCD
// Assembly location: C:\Users\ASUS\Documents\Tencent Files\1668911954\FileRecv\MobileFile\ksdumper-mod\princessconnectredive_11ED3000.dll
using UnityEngine;

namespace Elements
{
    public class StoryCommandVoiceEffect : StoryCommandBase
    {
        private float voEffectValue;

        protected override void SetCommandParam()
        {
            voEffectValue = 0.0f;
            if (args.Length != 0)
            voEffectValue = float.Parse(args[0]) * 0.1f;
            //soundManager.SetStoryVoiceEffect("VoiceReverb", voEffectValue);
        }

        public override void ExecCommand()
        {
            SetCommandParam();
            //storyManager.VoEffectValue = voEffectValue;
            Debug.Log("StoryCommandVoiceEffect");
            base.ExecCommand();
        }

        private enum eArgs
        {
            VOICE_EFFECT_ID,
            MAX,
        }
    }
}
