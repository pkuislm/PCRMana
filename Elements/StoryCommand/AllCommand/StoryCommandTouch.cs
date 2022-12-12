// Decompiled with JetBrains decompiler
// Type: Elements.StoryCommandTouch
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A7E03188-4A33-4E31-B2AA-6FF711CC1BCD
// Assembly location: C:\Users\ASUS\Documents\Tencent Files\1668911954\FileRecv\MobileFile\ksdumper-mod\princessconnectredive_11ED3000.dll

namespace Elements
{
    public class StoryCommandTouch : StoryCommandBase
    {
        public override void ExecCommand()
        {
            storyManager.SetArrowIconVisible(true);
            storyManager.IsVoicePage = false;
        }
    }
}
