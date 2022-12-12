// Decompiled with JetBrains decompiler
// Type: Elements.StoryMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A7E03188-4A33-4E31-B2AA-6FF711CC1BCD
// Assembly location: C:\Users\ASUS\Documents\Tencent Files\1668911954\FileRecv\MobileFile\ksdumper-mod\princessconnectredive_11ED3000.dll

//using Elements.Data;
using System.Diagnostics;
using UnityEngine;

namespace Elements
{
    public class StoryMenu : MonoBehaviour
    {
        [SerializeField]
        private CustomUIButton sliderButton;
        [SerializeField]
        private CustomUIButton skipButton;
        [SerializeField]
        private CustomUIButton autoPlayButton;
        //[SerializeField]
        //private CustomUILabel autoLabel;
        //[SerializeField]
        //private UISprite autoIcon;
        [SerializeField]
        private CustomUIButton logButton;
        [SerializeField]
        private CustomUIButton fullDispButton;
        //[SerializeField]
        //private StoryTitleTelop storyTitleTelop;
        [SerializeField]
        private GameObject Menu;
        private bool isMove;
        //private ParamDialogStorySkip storySkipParam;
        private StoryManager storyManager;
        //private DialogManager dialogManager;
        private const string AUTO_MODE_PLAY_ICON_NAME = "adv_btn_icon_auto";
        private const string AUTO_MODE_STOP_ICON_NAME = "adv_btn_icon_stop";
        //private UITweener[] slideTween;
        private bool isDisableSkipButtonNotification;

        SceneLoader scman = Singleton<SceneLoader>.Instance;

        public bool IsOpen { get; private set; }

        public void Init()
        {
            IsOpen = false;
            isMove = false;
            Menu.transform.localScale = new Vector3(0, 0, 1);
        /*     if (Object.op_Inequality((Object) tweenObject, (Object) null))
            {
            slideTween = tweenObject.GetComponents<UITweener>();
            for (int index = 0; slideTween != null && index < slideTween.Length; ++index)
            {
                if (index == 0)
                slideTween[index].SetOnFinished(new EventDelegate.Callback(onCompleteMove));
                slideTween[index].ResetToBeginning();
                ((Behaviour) slideTween[index]).enabled = false;
            }
            }*/
        /*      skipButton.SetOnClickDelegate((MonoBehaviour) this, new System.Action(onclickSkipButton));
            skipButton.SetOnDisabledClickDelegate((MonoBehaviour) this, new System.Action(onDisableClickSkipButton));
            autoPlayButton.SetOnClickDelegate((MonoBehaviour) this, new System.Action(onClickAutoPlayButton));
            logButton.SetOnClickDelegate((MonoBehaviour) this, new System.Action(onClickLogButton));
            fullDispButton.SetOnClickDelegate((MonoBehaviour) this, new System.Action(onClickFullDispButton));
            sliderButton.SetOnClickDelegate((MonoBehaviour) this, new System.Action(onClickSliderButton));
            skipButton.isEnabled = setSkipButtonEnable();*/
        /*      storyManager = StoryManagerBase<StoryManager>.Instance;
            dialogManager = ManagerSingleton<DialogManager>.Instance;*/
        }

        public void onClickSliderButton()
        {
            if (isMove)
            return;
            if (IsOpen)
            CloseMenu();
            else
            openMenu();
        }

        private void openMenu()
        {
            if (IsOpen)
                return;
            IsOpen = true;
            isMove = true;
            Menu.SetActive(true);
            Menu.LeanScale(new Vector3(1, 1, 1), 0.15f).setEaseOutBack().setOnComplete(() =>
            {
                onCompleteMove();
            });

            //storyTitleTelop.CutOffBlur();
            
            //sliderButton.ChangeEnabledSE(CustomUIButton.eButtonSE.CLOSE_MENU);
        }

        public void CloseMenu()
        {
            if (!IsOpen)
                return;
            IsOpen = false;
            isMove = true;
            Menu.LeanScale(new Vector3(0, 0, 1), 0.1f).setEaseOutCubic().setOnComplete(()=> 
            { 
                Menu.SetActive(false);
                onCompleteMove();
            });
            
            //sliderButton.ChangeEnabledSE(CustomUIButton.eButtonSE.OPEN_MENU);
        }

        private void onCompleteMove() => isMove = false;

        public void onClickLogButton()
        {
        /*      storyManager.StoryScene.StopAutoPlay();
            if (!logButton.isEnabled || Singleton<StoryChoiceController>.Instance.IsWaitSelect)
            return;
            ParamDialogStoryLog paramDialogStoryLog = new ParamDialogStoryLog();
            paramDialogStoryLog.SetTitle(eTextId.DIALOG_STORY_BACKLOG_TITLE);
            paramDialogStoryLog.SetOneButtonParam(eTextId.CLOSE, false, (System.Action) null);
            paramDialogStoryLog.SetOneButtonSe(CustomUIButton.eButtonSE.OK);
            dialogManager.OpenFullSizeCommon(eDialogId.STORY_LOG, (ParamDialogCommonAbstract) paramDialogStoryLog);*/
        }

        public void onclickSkipButton()
        {
                scman.LeaveStory();
        /*      storyManager.StoryScene.StopAutoPlay();
            if (storySkipParam == null)
            storySkipParam = new ParamDialogStorySkip();
            bool _isInsertStory = isInsertStorySkip();
            storySkipParam.SetTitle(eTextId.DIALOG_STORY_SKIP_TITLE_TEXT);
            storySkipParam.StoryChapterTitleText = storyManager.StorySkipDialogParams.GetTitleLabelText(_isInsertStory);
            storySkipParam.StoryChapterDetailText = storyManager.StorySkipDialogParams.GetSynopsisLabelText(_isInsertStory);
            storySkipParam.SetAlert(eTextId.STORY_SKIP_CAUTION_MESSAGE);
            storySkipParam.SetTwoButtonParam(eTextId.CANCEL, (System.Action) null, eTextId.SKIP, (System.Action) (() =>
            {
            if (storyManager.InProgressMovieCommand)
                return;
            storyManager.SkipStory();
            }));
            dialogManager.OpenSmallCommon(eDialogId.STORY_SKIP, (ParamDialogCommonAbstract) storySkipParam);*/
        }

        private void onDisableClickSkipButton()
        {
            /* if (!isDisableSkipButtonNotification)
            return;
            ManagerSingleton<ViewManager>.Instance.OpenNoticeWindow(eTextId.ADV_SKIP_BUTTON_DISABLE_NOTIFICATION);*/
        }

        private bool setSkipButtonEnable()
        {
                return false;
            /*int bfjnkgohima = Singleton<EHPLBCOOOPK>.Instance.BFJNKGOHIMA;
            if (!StoryDefine.SKIP_BUTTON_DISABLE_TARGET_UNVIEWING_STORY_IDS.Contains(bfjnkgohima) || Singleton<UserData>.Instance.ViewingStoryIdList.Contains(bfjnkgohima))
            return true;
            isDisableSkipButtonNotification = true;
            return false;*/
        }

        public void onClickAutoPlayButton() => storyManager.StoryScene.OnClickAutoPlay();

        public void onClickFullDispButton() => storyManager.StoryScene.OnClickFullDisp();

        //public void SetLogButtonEnabled(bool _enable) => logButton.isEnabled = _enable;

        //public void SetSkipButtonEnabled(bool _enable) => skipButton.isEnabled = _enable;

        public void ChangeAutoButton(bool _isAutoPlay)
        {
        /*      autoLabel.SetText((_isAutoPlay ? eTextId.STORY_STOP_AUTO_PLAY : eTextId.STORY_AUTO_PLAY).Name());
            autoIcon.spriteName = _isAutoPlay ? "adv_btn_icon_stop" : "adv_btn_icon_auto";
            autoIcon.MakePixelPerfect();*/
        }
        public void SetLogButtonEnabled(bool _enable)
        {
            //this.logButton.isEnabled = _enable;
        }

        // Token: 0x06002E91 RID: 11921 RVA: 0x0002029F File Offset: 0x0001E49F
        public void SetSkipButtonEnabled(bool _enable)
        {
            //this.skipButton.isEnabled = _enable;
        }
        private bool isInsertStorySkip()
        {
                return false;
            //int currentIndex = storyManager.GetCurrentIndex();
            //return (storyManager.StartInsertStoryIndex != 0 || storyManager.EndInsertStoryIndex != 0) && storyManager.StartInsertStoryIndex <= currentIndex && storyManager.EndInsertStoryIndex >= currentIndex;
        }

        private void OnDestroy()
        {
            /*sliderButton = (CustomUIButton) null;
            skipButton = (CustomUIButton) null;
            autoPlayButton = (CustomUIButton) null;
            autoLabel = (CustomUILabel) null;
            autoIcon = (UISprite) null;
            logButton = (CustomUIButton) null;
            fullDispButton = (CustomUIButton) null;
            storyTitleTelop = (StoryTitleTelop) null;
            tweenObject = (GameObject) null;*/
        }

        [Conditional("UNITY_EDITOR")]
        public void Editor_OnClickSkip()
        {
        }

        [Conditional("UNITY_EDITOR")]
        public void Editor_OnClickLog()
        {
        }
    }
}
