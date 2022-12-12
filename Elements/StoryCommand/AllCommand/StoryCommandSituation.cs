// Decompiled with JetBrains decompiler
// Type: Elements.StoryCommandSituation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A7E03188-4A33-4E31-B2AA-6FF711CC1BCD
// Assembly location: C:\Users\ASUS\Documents\Tencent Files\1668911954\FileRecv\MobileFile\ksdumper-mod\princessconnectredive_11ED3000.dll

using System.Text.RegularExpressions;
using UnityEngine;

namespace Elements
{
    public class StoryCommandSituation : StoryCommandBase
    {
        //private CustomUILabel captionLabel;
        private Regex deleteDoubleQuotation = new Regex("^\"(.*)\"$");
        private GameObject situation;
        private Animator situationAnimController;
        private const int MAX_WAIT_TIME_COUNT = 30;
        private const string PLAY_SITUATION_ANIM_NAME = "ADV_situation_anime";

/*        public override void OnLoad()
        {
            StoryFindHelper instance = SingletonMonoBehaviour<StoryFindHelper>.Instance;
            situation = instance.SituationBase;
            captionLabel = instance.SituationCaptionLabel;
            situationAnimController = instance.SituationAnimController;
            base.OnLoad();
        }*/

        public override void ExecCommand()
        {
            /*            storyManager.SetTouchDelegate(new TouchDelegate(((StoryCommandBase) this).OnTouchDelegate));
                        storyManager.SetTextFrameVisible(false);
                        captionLabel.SetText(deleteDoubleQuotation.Replace(args[0], "$1"));
                        startAnimation();*/

            Debug.Log("StoryCommandSituation: " + args[0]);
/*            LeanTweenExt.LeanDelayedCall(null, 10f, () =>
            {
                OnCompleteCommand();
            });*/
            OnCompleteCommand();
        }

        protected override void OnCompleteCommand()
        {
            /*situationAnimController.enabled = false;
            situation.SetActive(false);*/
            storyManager.RemoveTouchDelegate(new TouchDelegate(OnTouchDelegate));
            base.OnCompleteCommand();
        }

        public override bool OnTouchDelegate() => true;

/*        private void startAnimation()
        {
            situationAnimController.enabled = true;
            situationAnimController.speed = (float) storyManager.StoryScene.CommandTimeScale;
            situationAnimController.Play("ADV_situation_anime", 0, 0.0f);
            soundManager.PlaySe(eSE.SYS_ADV_TITLE_START);
            situationAnimController.Update(0.0f);
            AnimatorStateInfo animatorStateInfo = situationAnimController.GetCurrentAnimatorStateInfo(0);
            storyManager.StoryScene.Timer(((AnimatorStateInfo) ref animatorStateInfo).length, (System.Action) (() => OnCompleteCommand()));
        }*/
    }
}
