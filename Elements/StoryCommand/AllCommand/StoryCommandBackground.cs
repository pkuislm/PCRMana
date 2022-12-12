// Decompiled with JetBrains decompiler
// Type: Elements.StoryCommandBackground
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A7E03188-4A33-4E31-B2AA-6FF711CC1BCD
// Assembly location: C:\Users\ASUS\Documents\Tencent Files\1668911954\FileRecv\MobileFile\ksdumper-mod\princessconnectredive_11ED3000.dll
using UnityEngine;

namespace Elements
{
    public class StoryCommandBackground : StoryCommandBase
    {
        private int bgId;
        private int bgType;
        private int backgroundWidth = 1414;
        private int backgroundHeight = 1060;
        private const int BG_ID_MAX_LENGTH = 6;

        public int BgId => bgId;

        public override void ExecCommand()
        {
            storyManager.ReleaseMovieStayCommandAction();
            if (int.TryParse(args[0], out bgId) && args[0].Length == 6)
            {
                bgType = 0;
                backgroundWidth = 1414;
                backgroundHeight = 1060;
                bool flag = args.Length >= 3;
                if (args.Length >= 2)
                {
                    bgType = int.Parse(args[1]);
                    if (bgType == 1)
                    backgroundWidth = flag ? int.Parse(args[2]) : 1768;
                    else if (bgType == 2)
                    backgroundHeight = flag ? int.Parse(args[2]) : 1768;
                }
                storyManager.StoryScene.ChangeBackground(bgId, backgroundWidth, backgroundHeight);
                //storyManager.BgType = StoryHistoryInformation.eBackgroundType.BACK_GROUND;
            }
            Debug.Log("StoryCommandBackground: " + args[0]);
            base.ExecCommand();
        }

        private enum eArgs
        {
            BACKGROUND_ID,
            BACKGROUND_TYPE,
            BACKGROUND_SIZE,
            MAX,
        }
    }
}
