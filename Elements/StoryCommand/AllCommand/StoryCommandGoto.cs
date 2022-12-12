// Decompiled with JetBrains decompiler
// Type: Elements.StoryCommandGoto
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A7E03188-4A33-4E31-B2AA-6FF711CC1BCD
// Assembly location: C:\Users\ASUS\Documents\Tencent Files\1668911954\FileRecv\MobileFile\ksdumper-mod\princessconnectredive_11ED3000.dll

namespace Elements
{
    public class StoryCommandGoto : StoryCommandBase
    {
        public override void ExecCommand()
        {
            int _tag = int.Parse(args[0]);
            storyManager.GotoTag(_tag);
            storyManager.SelectGotoTagList.Add(_tag);
            storyManager.ExecNextCommand();
        }

        private enum eArgs
        {
            TAG_ID,
            MAX,
        }
    }
}
