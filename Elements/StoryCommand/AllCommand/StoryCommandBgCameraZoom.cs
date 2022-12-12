// Decompiled with JetBrains decompiler
// Type: Elements.StoryCommandBgCameraZoom
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A7E03188-4A33-4E31-B2AA-6FF711CC1BCD
// Assembly location: C:\Users\ASUS\Documents\Tencent Files\1668911954\FileRecv\MobileFile\ksdumper-mod\princessconnectredive_11ED3000.dll

using System;

namespace Elements
{
    public class StoryCommandBgCameraZoom : StoryCommandBase
    {
        private float zoomRate = 1f;
        private int zoomActionFrame;

        public override void ExecCommand()
        {
            this.zoomRate = float.Parse(this.args[0]);
            if ((double) this.zoomRate < 1.0)
            this.zoomRate = 1f;
            else if ((double) this.zoomRate > 1.5)
            this.zoomRate = 1.5f;
            this.zoomActionFrame = int.Parse(this.args[1]) / this.storyManager.StoryScene.CommandTimeScale;
            if (this.zoomActionFrame == 0)
            this.zoomActionFrame = 1;
            this.storyManager.SetTouchDelegate(new TouchDelegate(((StoryCommandBase) this).OnTouchDelegate));
            //this.storyManager.StoryScene.BgCameraZoom(this.zoomRate, this.zoomActionFrame, new Action(((StoryCommandBase) this).OnCompleteCommand));
        }

        public override bool OnTouchDelegate() => true;

        private enum eArgs
        {
            ZOOM_RATE,
            ZOOM_ACTION_FRAME,
        }
    }
}
