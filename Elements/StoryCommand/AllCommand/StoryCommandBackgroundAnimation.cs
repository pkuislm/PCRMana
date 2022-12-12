using UnityEngine;

namespace Elements
{
    public class StoryCommandBackgroundAnimation : StoryCommandBase
    {
        public string BgAnimationName { get; private set; }

        public override void ExecCommand()
        {
            int num = 0;
            if (args.Length != 0)
            num = int.Parse(args[0]);
            BgAnimationName = string.Format("ADV_background_anime_{0:D3}", num);
            //storyManager.StoryScene.PlayBackgroundAnimation(BgAnimationName, num != 0);
            Debug.Log("StoryCommandBackgroundAnimation: " + BgAnimationName);
            base.ExecCommand();
        }

        private enum eArgs
        {
            ANIMATION_NAME,
            MAX,
        }
    }
}
