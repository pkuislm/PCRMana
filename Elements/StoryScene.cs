using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Elements
{
    public class StoryScene : MonoBehaviour
    {
        //storyMenu
        [SerializeField]
        private StoryMenu storyMenuBar;

        private StoryManager storyManager;
        public bool IsAutoPlay { get; set; }
        public StoryMenu MenuBar => storyMenuBar;
        public int CommandTimeScale { get; private set; }


        //Choice buttons
        //situtationSprite
        //backgroundTexture
        [SerializeField]
        private RawImage backgroundTexture;

        public Image ArrowIcon;

        LTDescr bgMovement;
        //backgroundAnimation
        //storyCharacters
        //textLabel
        public TextMeshProUGUI TextLabel;
        //nameLabel
        public TextMeshProUGUI NameLabel;
        //nameDeco
        //placeIcon
        private void Start()
        {
            storyMenuBar.Init();
            storyManager = StoryManagerBase<StoryManager>.Instance;
            
            SetupStory();
            LeanTween.delayedCall(1f, () =>
            {
                storyManager.StartStory();
                storyManager.ExecCurrentCommand();
            });
        }

        public void StartStory()
        {
            //int length = storyCharacters.Length;
            //for (int index = 0; index < length; ++index)
            //    storyCharacters[index].StartStory();
            //shakeUICamera = ((Component)viewManager.CurCamera).GetComponent<UIShake>();
            CommandTimeScale = 1;
            //SetTouchEnabled(true);
        }

        private void SetupStory()
        {
            /*viewManager.CurPartsBackGround.BlackBG.SetActiveWithCheck(false);
            bgCamera = ((Component)shakeBGCamera).GetComponent<Camera>();
            if (StoryManagerBase<StoryManager>.Instance == null)
                soundManager.StopBgm();
            StoryManagerBase<StoryManager>.CreateInstance();
            storyManager = StoryManagerBase<StoryManager>.Instance;*/
            storyManager.Init(this);
            //storyManager.SetReturnDelegate(new ReturnDelegate(ReturnPrevScene));
            /*Singleton<StoryChoiceController>.CreateInstance();
            Singleton<StoryChoiceController>.Instance.Init();
            StartCoroutine(coroutineStartView());
            ((Behaviour)backgroundAnimation).enabled = false;*/
        }

        public void ChangeBackground(int _bgId, int _bgWidth = 1414, int _bgHeight = 1060)
        {
            Texture2D texture2D = Singleton<AssestManager>.Instance.LoadBGById(_bgId);
            if (texture2D != null)
            {
                
                backgroundTexture.texture = texture2D;
                
                //backgroundTexture.color = Color.white;
                LeanTween.size(backgroundTexture.rectTransform, new Vector3(_bgWidth, _bgHeight, 0), 0);
                //LeanTween.scale(backgroundTexture.gameObject
                //backgroundTexture.width = _bgWidth;
                //backgroundTexture.height = _bgHeight;
            }
        }
        public void SlideBackGroundVertical(float _startPoint, float _endPoint, float _slideTime, Action _slideFinishCallback)
        {
            if (backgroundTexture.transform.position.y != _endPoint)
                bgMovement = LeanTween.moveY(backgroundTexture.gameObject, _endPoint, _slideTime).setFrom(_startPoint).setEaseInQuad().setOnComplete(_slideFinishCallback);
            else
                _slideFinishCallback();
        }
        public void SlideBackGroundHorizontal(float _endPoint, float _slideTime, Action _slideFinishCallback)
        {
            bgMovement = LeanTween.moveX(backgroundTexture.gameObject, _endPoint, _slideTime).setEaseInQuad().setOnComplete(_slideFinishCallback);
        }
        public void SkipBackgroundPan()
        {
           /* if (bgMovement != null && bgMovement.com)
            {
                component.from = component.to;
                component.duration = 0f;
                component.ResetToBeginning();
                UnityEngine.Object.Destroy(component);
            }*/
        }
        public void onClickNextCommand(bool _autoClick = false)
        {
            /*            if (_autoClick ^ IsAutoPlay || storyManager == null || !storyManager.PlayingStory)
                            return;
                        if (isFullDisplay)
                        {
                            soundManager.PlaySe(eSE.SYS_BUTTON_SMALL);
                            setFullDisp(false);
                        }
                        else
                            storyManager.FeedPage(true, true);*/
            storyManager.FeedPage(true, true);
        }

        public void OnClickFullDisp()
        {
            StopAutoPlay();
            //setFullDisp(true);
        }

        public void StartAutoPlay()
        {
            //autoAnnounce.alpha = 1f;
            //((Component)autoStopButton).gameObject.SetActive(true);
            IsAutoPlay = true;
            storyMenuBar.ChangeAutoButton(IsAutoPlay);
            storyMenuBar.CloseMenu();
            //Screen.sleepTimeout = -1;
        }

        public void StopAutoPlay()
        {
            //autoAnnounce.alpha = 0.0f;
            //((Component)autoStopButton).gameObject.SetActive(false);
            IsAutoPlay = false;
            storyMenuBar.ChangeAutoButton(IsAutoPlay);
            //Screen.sleepTimeout = -2;
        }

        public void OnClickAutoPlay()
        {
            if (IsAutoPlay)
                StopAutoPlay();
            else
                StartAutoPlay();
        }

        public void EndStory()
        {
            StopAutoPlay();

            Singleton<SceneLoader>.Instance.LeaveStory();
            //base.dialogManager.OpenStoryEndTouch();
        }

        private void OnDestroy()
        {
            StoryManagerBase<StoryManager>.DeleteInstance();
            storyManager = null;
        }
    }
}

