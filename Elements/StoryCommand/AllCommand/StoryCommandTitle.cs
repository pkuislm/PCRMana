// Decompiled with JetBrains decompiler
// Type: Elements.StoryCommandTitle
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A7E03188-4A33-4E31-B2AA-6FF711CC1BCD
// Assembly location: C:\Users\ASUS\Documents\Tencent Files\1668911954\FileRecv\MobileFile\ksdumper-mod\princessconnectredive_11ED3000.dll
using UnityEngine;

namespace Elements
{
    public class StoryCommandTitle : StoryCommandBase
    {
        private StorySkipDialogParams skipParam;

        protected override void SetCommandParam() => skipParam.TitleLabelText = args[0];

        public override void ExecCommand()
        {
            skipParam = storyManager.StorySkipDialogParams;
            Debug.Log("StoryCommandTitle: " + args[0]);
            SetCommandParam();
            base.ExecCommand();
        }

        private enum eArgs
        {
            TITLE,
            MAX,
        }
    }
}
