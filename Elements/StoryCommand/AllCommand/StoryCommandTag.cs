// Decompiled with JetBrains decompiler
// Type: Elements.StoryCommandTag
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A7E03188-4A33-4E31-B2AA-6FF711CC1BCD
// Assembly location: C:\Users\ASUS\Documents\Tencent Files\1668911954\FileRecv\MobileFile\ksdumper-mod\princessconnectredive_11ED3000.dll

using System.Collections.Generic;

namespace Elements
{
    public class StoryCommandTag : StoryCommandBase
    {
        public override void ExecCommand() => base.ExecCommand();

        public static int GetTagId(List<string> _args) => int.Parse(_args[0]);

        private enum eArgs
        {
            TAG_ID,
        }
    }
}
