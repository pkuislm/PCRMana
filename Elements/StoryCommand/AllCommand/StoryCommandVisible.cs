// Decompiled with JetBrains decompiler
// Type: Elements.StoryCommandVisible
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A7E03188-4A33-4E31-B2AA-6FF711CC1BCD
// Assembly location: C:\Users\ASUS\Documents\Tencent Files\1668911954\FileRecv\MobileFile\ksdumper-mod\princessconnectredive_11ED3000.dll

using UnityEngine;

namespace Elements
{
    public class StoryCommandVisible : StoryCommandBase
    {
        public override void ExecCommand()
        {
    /*        StoryCharacter characterWithName = this.storyManager.StoryScene.GetCharacterWithName(this.args[0]);
            if (characterWithName != null)
            {
                bool flag = args[1].ToLower() == "true";
                characterWithName.SetVisible(flag);
            }*/
            base.ExecCommand();
        }

        private enum eArgs
        {
            CHARA_ID,
            VISIBLE,
            MAX,
        }
    }
}
