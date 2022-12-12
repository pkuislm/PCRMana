// Decompiled with JetBrains decompiler
// Type: Elements.StoryCommandBackgroundPan
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A7E03188-4A33-4E31-B2AA-6FF711CC1BCD
// Assembly location: C:\Users\ASUS\Documents\Tencent Files\1668911954\FileRecv\MobileFile\ksdumper-mod\princessconnectredive_11ED3000.dll

using System;
using UnityEngine;

namespace Elements
{
    public class StoryCommandBackgroundPan : StoryCommandBase
    {
        private float startPoint;
        private float endPoint;
        private float slideTime;

        public override void ExecCommand()
        {
            startPoint = float.Parse(args[0]);
            endPoint = float.Parse(args[1]);
            slideTime = 2f;
            if (args.Length > 2)
                slideTime = float.Parse(args[2]) / 30f;
            slideTime /= storyManager.StoryScene.CommandTimeScale;
            storyManager.SetTouchDelegate(new TouchDelegate(OnTouchDelegate));
            Debug.Log("StoryCommandBgPanY: " + args[0] + " -> " + args[1]);
            storyManager.StoryScene.SlideBackGroundVertical(startPoint, endPoint, slideTime, new Action(backgroundPanFinishAction));
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
            START_POINT,
            END_POINT,
            SLIDE_TIME,
            MAX,
        }
    }
}
