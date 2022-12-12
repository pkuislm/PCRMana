using UnityEngine;

using System;

namespace Elements
{
    public class StoryCommandBackgroundSplitSlide : StoryCommandBase
    {
        private float textureScale;
        private float slideAmount;
        private float slideTime;
        private float texturePosX;
        private float texturePosY;
        private float slideOffset;

        public override void ExecCommand()
        {
            storyManager.SetTouchDelegate(new TouchDelegate(((StoryCommandBase) this).OnTouchDelegate));
            int length = args.Length;
            Debug.Log("StoryCommandBackgroundSplitSlide");
            if (length > 0)
            {
                textureScale = float.Parse(args[0]);
                slideAmount = 0.0f;
                if (length > 1)
                    slideAmount = float.Parse(args[1]);
                slideTime = 0.0f;
                if (length > 2)
                    slideTime = (float) (float.Parse(args[2]) / storyManager.StoryScene.CommandTimeScale / 30.0);
                texturePosX = 0.0f;
                if (length > 3)
                    texturePosX = float.Parse(args[3]);
                texturePosY = 0.0f;
                if (length > 4)
                    texturePosY = float.Parse(args[4]);
                slideOffset = 0.0f;
                if (length > 5)
                    slideOffset = float.Parse(args[5]);
                //storyManager.StoryScene.SlideSplitBackground(textureScale, slideAmount, slideTime, texturePosX, texturePosY, slideOffset, new Action(((StoryCommandBase) this).OnCompleteCommand));
            }
            else
            {
                //storyManager.StoryScene.SetEnableSplitBackground(true);
                OnCompleteCommand();
            }
        }

        public override bool OnTouchDelegate() => true;

        protected override void OnCompleteCommand() => base.OnCompleteCommand();

        private enum eArgs
        {
            TEXTURE_SCALE,
            SLIDE_AMOUNT,
            SLIDE_FRAME,
            POSITION_X,
            POSITION_Y,
            SLIDE_OFFSET,
            MAX,
        }
    }
}
