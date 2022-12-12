using UnityEngine;

namespace Elements
{
    public class StoryCommandBackgroundSplit : StoryCommandBase
    {
        private int backgroundId;
        private float splitAngle;

        public override void ExecCommand()
        {
            this.backgroundId = int.Parse(this.args[0]);
            this.splitAngle = float.Parse(this.args[1]);
            Debug.Log(string.Format("StoryCommandBackgroundSplit: {0}@{1}", backgroundId, splitAngle));
            //this.storyManager.StoryScene.Splitbackground(this.backgroundId, this.splitAngle);
            base.ExecCommand();
        }

        public enum eArgs
        {
            BACKGROUND_ID,
            SPLIT_ANGLE,
            MAX,
        }
    }
}
