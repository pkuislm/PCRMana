// Decompiled with JetBrains decompiler
// Type: Elements.StoryCommandBustup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A7E03188-4A33-4E31-B2AA-6FF711CC1BCD
// Assembly location: C:\Users\ASUS\Documents\Tencent Files\1668911954\FileRecv\MobileFile\ksdumper-mod\princessconnectredive_11ED3000.dll

//using Cute;
using System.Collections.Generic;
using UnityEngine;

namespace Elements
{
    public class StoryCommandBustup : StoryCommandBase
    {
        private int talkUnitID;
        private int isDispBustUp;
        private bool isEyeClose;
        private System.Action finishCallback;
        private int nowWindowType;
        private int beforeDispBustUp;
        private GameObject nameFrameObject;
        //private StoryFindHelper findHelper;
        private GameObject textWindowAll;
        private static readonly string[] TEXT_FRAME_ANIMATION_NAME = new string[4]
        {
            "",
            "ADV_anime_Normal_{0}",
            "ADV_anime_heart_{0}",
            "ADV_anime_anger_{0}"
        };
        public static readonly string NONE_ANIMATION_EXTENSION = "NONE";

        public int TalkUnitID => talkUnitID;

        public int IsDispBustUp => isDispBustUp;

        public override void OnLoad()
        {
/*            findHelper = SingletonMonoBehaviour<StoryFindHelper>.Instance;
            nameFrameObject = ((Component) findHelper.NameFrame).gameObject;
            textWindowAll = findHelper.TextWindowAll;*/
            base.OnLoad();
        }

        protected override void SetCommandParam()
        {
            talkUnitID = int.Parse(args[0]);
            if (args.Length > 1)
            {
            beforeDispBustUp = isDispBustUp;
            isDispBustUp = int.Parse(args[1]);
            }
            isEyeClose = false;
            if (args.Length <= 2)
            return;
            isEyeClose = int.Parse(args[2]) == 1;
        }

        public override void ExecCommand()
        {
            storyManager.SetTouchDelegate(new TouchDelegate(OnTouchDelegate));
            SetCommandParam();
            /*nowWindowType = (storyManager.CommandDictionary["change_window"] as StoryCommandChangeWindow).WindowId;
            if (storyManager.NowTalkUnitID == -1)
            {
                finishCallback = new System.Action(((StoryCommandBase) this).OnCompleteCommand);
                fadeWait();
            }
            else if (storyManager.NowTalkUnitID != talkUnitID)
            {
                finishCallback = new System.Action(((StoryCommandBase) this).OnCompleteCommand);
                fadeOut();
            }
            else if (storyManager.StayCommandMovieID != 0L || storyManager.TextFrameState == AdvDefine.eTextFrameState.FADE_OUT || isDispBustUp != beforeDispBustUp || !storyManager.IsWindowVisible)
            {
                storyManager.StoryScene.FadeWaitTalkUnit();
                storyManager.StoryScene.TextLabel.SetText(eTextId.NONE);
                storyManager.StoryScene.NameLabel.SetText(eTextId.NONE);
                finishCallback = new System.Action(((StoryCommandBase) this).OnCompleteCommand);
                fadeWait();
            }
            else*/
            {
                //nameFrameObject.SetActive(storyManager.IsNameFrameVisible());
                OnCompleteCommand();
            }
        }

        private void fadeIn()
        {
            /*storyManager.TextFrameState = AdvDefine.eTextFrameState.FADE_IN;
            if (storyManager.NowTalkUnitID == -1)
            {
                storyManager.StoryScene.TextLabel.SetText(eTextId.NONE);
                storyManager.StoryScene.NameLabel.SetText(eTextId.NONE);
                findHelper.TextFrameObj.gameObject.SetActive(true);
            }
            TweenAlpha[] components = textWindowAll.GetComponents<TweenAlpha>();
            TweenAlpha fadeIn = (TweenAlpha) null;
            if (!storyManager.StoryScene.IsFullDisplayMode)
            {
                int length = components.Length;
                for (int index = 0; index < length; ++index)
                {
                    if (((Behaviour) components[index]).enabled && (double) components[index].from == 0.0 && (double) components[index].to == 1.0)
                    {
                        fadeIn = components[index];
                        break;
                    }
                }
            }
            System.Action fadeFinish = (System.Action) (() =>
            {
                Animator textFrameAnimator = storyManager.TextFrameAnimator;
                textFrameAnimator.speed = (float) storyManager.StoryScene.CommandTimeScale;
                int characterWithIndex = storyManager.StoryScene.GetCharacterWithIndex(talkUnitID.ToString());
                string str = characterWithIndex == -1 ? StoryCommandBustup.NONE_ANIMATION_EXTENSION : AdvDefine.CHARACTER_POS_ARRAY[characterWithIndex];
                if (isDispBustUp == 1)
                {
                    storyManager.StoryScene.ChangeTextFrameSprite(nowWindowType, -1);
                    str = StoryCommandBustup.NONE_ANIMATION_EXTENSION;
                    storyManager.StoryScene.DrawTalkUnit(talkUnitID, isEyeClose);
                    storyManager.StoryScene.FadeInTalkUnit();
                }
                else
                {
                    storyManager.StoryScene.ChangeTextFrameSprite(nowWindowType, characterWithIndex);
                    storyManager.StoryScene.DeleteBustUp();
                }
                textFrameAnimator.Play(string.Format(StoryCommandBustup.TEXT_FRAME_ANIMATION_NAME[nowWindowType], (object) str), 0, 0.0f);
                textFrameAnimator.Update(0.0f);
                AnimatorStateInfo animatorStateInfo = textFrameAnimator.GetCurrentAnimatorStateInfo(0);
                float length = ((AnimatorStateInfo) ref animatorStateInfo).length;
                storyManager.NowTalkUnitID = talkUnitID;
                storyManager.StoryScene.Timer(length, (System.Action) (() => finishCallback()));
            });
            if (!storyManager.StoryScene.IsFullDisplayMode)
            {
            if (Object.op_Equality((Object) fadeIn, (Object) null))
            {
                fadeIn = textWindowAll.AddComponent<TweenAlpha>();
                ((Behaviour) fadeIn).enabled = false;
                fadeIn.duration = 0.01f;
                fadeIn.from = 0.0f;
                fadeIn.to = 1f;
                fadeIn.animationCurve = AnimationCurve.EaseInOut(0.0f, 0.0f, 1f, 1f);
            }
            fadeIn.Timer((System.Action) (() =>
            {
                fadeIn.PlayForward();
                setTweenCoroutine(fadeIn.duration, (System.Action) (() =>
                {
                fadeFinish();
                fadeIn.SetOnFinished((EventDelegate.Callback) (() => { }));
                }));
            }));
            }
            else
            fadeFinish();*/
        }

        private void fadeWait()
        {
            /*storyManager.TextFrameState = AdvDefine.eTextFrameState.FADE_WAIT;
            TweenAlpha[] components = textWindowAll.GetComponents<TweenAlpha>();
            TweenAlpha fadeWait = (TweenAlpha) null;
            int length = components.Length;
            for (int index = 0; index < length; ++index)
            {
                if (((Behaviour) components[index]).enabled && (double) components[index].from == 0.0 && (double) components[index].to == 1.0)
                {
                    fadeWait = components[index];
                    break;
                }
            }
            System.Action fadeFinish = (System.Action) (() =>
            {
                if (storyManager.StayCommandMovieID != 0L)
                    storyManager.ReleaseMovieStayCommandAction();
                Object.Destroy((Object) fadeWait);
                fadeIn();
            });
            if (Object.op_Equality((Object) fadeWait, (Object) null))
            {
                fadeWait = textWindowAll.AddComponent<TweenAlpha>();
                ((Behaviour) fadeWait).enabled = false;
                fadeWait.duration = 0.0f / (float) storyManager.StoryScene.CommandTimeScale;
                fadeWait.from = 0.0f;
                fadeWait.to = 1f;
                fadeWait.animationCurve = AnimationCurve.EaseInOut(0.0f, 0.0f, 1f, 0.0f);
                fadeWait.Timer((System.Action) (() =>
                {
                    fadeWait.PlayForward();
                    setTweenCoroutine(fadeWait.duration, fadeFinish);
                }));
            }
            else
            setTweenCoroutine(fadeWait.duration, fadeFinish);*/
        }

        private void fadeOut()
        {
            /*if (storyManager.TextFrameState == AdvDefine.eTextFrameState.FADE_OUT)
            {
                storyManager.StoryScene.TextLabel.SetText(eTextId.NONE);
                storyManager.StoryScene.NameLabel.SetText(eTextId.NONE);
                fadeWait();
            }
            else
            {
                storyManager.TextFrameState = AdvDefine.eTextFrameState.FADE_OUT;
                TweenAlpha[] components = textWindowAll.GetComponents<TweenAlpha>();
                TweenAlpha fadeOut = (TweenAlpha) null;
                int length = components.Length;
                for (int index = 0; index < length; ++index)
                {
                    if (((Behaviour) components[index]).enabled && (double) components[index].from == 0.0 && (double) components[index].to == 1.0)
                    {
                    fadeOut = components[index];
                    break;
                    }
                }
                System.Action fadeFinish = (System.Action) (() =>
                {
                    Object.Destroy((Object) fadeOut);
                    fadeWait();
                });
                if (Object.op_Equality((Object) fadeOut, (Object) null))
                {
                    fadeOut = textWindowAll.AddComponent<TweenAlpha>();
                    ((Behaviour) fadeOut).enabled = false;
                    fadeOut.duration = 0.1f / (float) storyManager.StoryScene.CommandTimeScale;
                    fadeOut.from = 0.0f;
                    fadeOut.to = 1f;
                    fadeOut.animationCurve = AnimationCurve.EaseInOut(0.0f, 1f, 1f, 0.0f);
                    fadeOut.Timer((System.Action) (() =>
                    {
                        storyManager.StoryScene.TextLabel.SetText(eTextId.NONE);
                        storyManager.StoryScene.NameLabel.SetText(eTextId.NONE);
                        storyManager.StoryScene.FadeOutTalkUnit();
                        fadeOut.PlayForward();
                        setTweenCoroutine(fadeOut.duration, fadeFinish);
                    }));
                }
                else
                    setTweenCoroutine(fadeOut.duration, fadeFinish);
            }*/
        }

        //private void setTweenCoroutine(float _duration, System.Action _finishAction) => storyManager.BustupCommandFadeCoroutine(_duration, _finishAction);

        public override bool OnTouchDelegate() => true;

        public static string GetCharacterId(List<string> _args) => _args[0];

        public static bool GetDispBustUpFlag(List<string> _args)
        {
            bool dispBustUpFlag = false;
            if (_args.Count > 1)
            dispBustUpFlag = int.Parse(_args[1]) == 1;
            return dispBustUpFlag;
        }

        private enum eArgs
        {
            TALK_UNIT_ID,
            BUSTUP_DISP,
            EYE_CLOSE,
            MAX,
        }
    }
}
