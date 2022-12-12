// Decompiled with JetBrains decompiler
// Type: Elements.StoryCommandBackgroundPanX
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A7E03188-4A33-4E31-B2AA-6FF711CC1BCD
// Assembly location: C:\Users\ASUS\Documents\Tencent Files\1668911954\FileRecv\MobileFile\ksdumper-mod\princessconnectredive_11ED3000.dll

using System;

namespace Elements
{
    public class StoryCommandBackgroundPanX : StoryCommandBase
    {
        private float endPoint;
        private float slideTime;
        private bool isCommandFinishWait;

        public override void ExecCommand()
        {
            endPoint = float.Parse(args[0]);
            slideTime = 2f;
            if (args.Length >= 2)
            slideTime = float.Parse(args[1]) / 30f;
            slideTime /= storyManager.StoryScene.CommandTimeScale;
            isCommandFinishWait = false;
            if (args.Length >= 3)
            isCommandFinishWait = int.Parse(args[2]) == 1;
            if (isCommandFinishWait)
            {
                storyManager.SetTouchDelegate(new TouchDelegate(((StoryCommandBase) this).OnTouchDelegate));
                storyManager.StoryScene.SlideBackGroundHorizontal(endPoint, slideTime, new Action(backgroundPanFinishAction));
            }
            else
            {
                storyManager.StoryScene.SlideBackGroundHorizontal(endPoint, slideTime, (Action) null);
                base.ExecCommand();
            }
        }

        private void backgroundPanFinishAction() => OnCompleteCommand();

        public override bool OnTouchDelegate()
        {
            if (!AdvDefine.INTERCEPT_TOUCH)
                storyManager.StoryScene.SkipBackgroundPan();
            return AdvDefine.INTERCEPT_TOUCH;
        }

        private enum eArgs
        {
            END_POINT,
            SLIDE_TIME,
            COMMAND_FINISH_WAIT,
            MAX,
        }
    }
}
