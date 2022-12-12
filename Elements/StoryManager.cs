using System;
using System.Collections.Generic;
using UnityEngine;

namespace Elements
{
    public class StoryManager : StoryManagerBase<StoryManager>
    {
        private Dictionary<int, int> tagDictionary;
        private Dictionary<int, StoryLogInfo> allLogDictionary;
        private Dictionary<string, int> playingEnvDic = new Dictionary<string, int>();
        private Dictionary<int, GameObject> playParticleEffectDic = new Dictionary<int, GameObject>();
        private Dictionary<string, int> playEnvReferenceCounterDict = new Dictionary<string, int>();

		private AssestManager resourceManager = Singleton<AssestManager>.Instance;

		//
		public List<int> SelectGotoTagList
		{
			get
			{
				return selectGotoTagList;
			}
		}
		private StoryMenu storyMenu;
        private GameObject skipButtonOnlyStoryMenu;
        private Coroutine bustupFadeCoroutine;
        private List<int> stillUnitIDList = new List<int>(10);
        private List<int> subStillUnitIDList = new List<int>(10);
        //private Dictionary<int, StillCharacter> stillUnitSpineDic = new Dictionary<int, StillCharacter>();
        //private Dictionary<int, StillCharacter> subStillUnitSpineDic = new Dictionary<int, StillCharacter>();
        private float beforeMovieVoiceLevel;
        private bool beforeIsMuteVoice;
        //private MovieManager movieManager = ManagerSingleton<MovieManager>.Instance;
        //private SoundManager soundManager = ManagerSingleton<SoundManager>.Instance;
        //public StoryHistoryInformation.eBackgroundType BgType;
        //private Dictionary<int, NIBGCIIGOMC> bgmAudioPlayBackDic = new Dictionary<int, NIBGCIIGOMC>();
        //private StoryHistoryInformation.BGMInfo skipBgmInfo = new StoryHistoryInformation.BGMInfo();
        private float defaultMenuPosY;
        private Animator textFrameAnimator;
        private int ignoreStopBgmChannel = -1;
        private List<int> selectGotoTagList = new List<int>();
		public bool IsUIVisibleCommand { get; private set; }
		public StoryScene StoryScene { get; private set; }

		private int StoryId;

		public void SetStoryId(int id)
        {
			StoryId = id;
        }

		protected Parser getParser()
		{
			if (parser == null)
			{
				parser = new Parser();
				parser.Init();
			}
			return parser;
		}

		public void Init(StoryScene scene)
        {
			storyMenu = scene.MenuBar;
			StoryScene = scene;
			storyCommandList = loadStoryDataImmidately(StoryId);
			setDetailFromStoryData(StoryId, false, storyCommandList);
			currentCommandIndex = 0;
			Init();
            int commandConfigListCount = dataConfig.GetCommandConfigListCount();
            for (int index = 0; index < commandConfigListCount; ++index)
                addCommandClass(dataConfig.GetCommandName(index));

            arrowIcon = scene.ArrowIcon;
            SetArrowIconVisible(false);

            /*StoryFindHelper instance = SingletonMonoBehaviour<StoryFindHelper>.Instance;
            
            textFrame = instance.TextFrameObj;
            SetTextFrameVisible(false);
            storyMenu = instance.StoryMenu;
            skipButtonOnlyStoryMenu = instance.SkipButtonOnlyMenu;
            textFrameAnimator = instance.TextFrameObj.GetComponent<Animator>();
            StoryScene = instance.StoryScene;
            TextFrameState = AdvDefine.eTextFrameState.FADE_OUT;
            storyTemp = Singleton<EHPLBCOOOPK>.Instance.PCLNMOOKCBG;
            IsDispMainStill = false;
            ignoreStopBgmChannel = -1;
            IsBattleCommand = false;
            FadeStopTargetChannel = -1;
            FadeStopRemoveCueSheetName = "";
            IsBackLogVoicePlaying = false;
            IsMiniGameCommand = false;
            StorySkipChangeTextSizeToMovieCommand = false;
            StorySkipChangeTextSize = 23;
            IsPlayBirthdayAdv = storyTemp.FELMNNNFAAJ;
            IsNextAutoChoiceDisable = false;
            stopBustupFadeCoroutine();
            defaultMenuPosY = IsPlayBirthdayAdv ? skipButtonOnlyStoryMenu.transform.localPosition.y : ((Component)storyMenu).transform.localPosition.y;
            StoryScene.StopAutoPlay();
            storyMenu.Init();
            SetStoryMenuVisible(false);*/
        }

        protected void addCommandClass(string _commandName)
        {
            string commandClassName = dataConfig.GetCommandClassName(dataConfig.GetCommandIndex(ref _commandName));
            if (string.IsNullOrEmpty(commandClassName))
                return;
            StoryCommandBase instance = (StoryCommandBase)Activator.CreateInstance(Type.GetType("Elements." + commandClassName));
            instance.OnLoad();
            instance.SetStoryManager();
            instance.SetCallback(new Action<int>(CompleteExecCommand));
            CommandDictionary.Add(_commandName, instance);
        }

        protected void execCommand(int _index)
        {
            int count = storyCommandList.Count;
            if (_index < count)
            {
                CommandStruct storyCommand = storyCommandList[_index];
                setHideScreen(storyCommand.Number);
                string name = storyCommand.Name;
				Debug.Log(string.Format("Executing Command: ({0}){1}", name, _index));
				string[] array = storyCommand.Args.ToArray();
                StoryCommandBase command = CommandDictionary[name];
                command.InitParam(name, array, _index);
                if (!command.IsSetCommandCompleteAction())
                    command.SetCallback(new Action<int>(CompleteExecCommand));
                command.ExecCommand();
                //saveLog(_index);
                if (ExecCommandLogList.Count <= 0)
                    return;
                storyMenu.SetLogButtonEnabled(true);
            }
            else
            {
                onExit();
                StoryScene.EndStory();
            }
        }

		protected virtual void onExit()
		{
			IsEndStory = true;
			PlayingStory = false;
			currentCommandIndex = 0;
			/*SoundManager instance = ManagerSingleton<SoundManager>.Instance;
			instance.StopStory();
			instance.SetStoryVoiceEffect("VoiceReverb", 0f);
			instance.SetStorySeEffect("SeReverb", 0f);*/
		}

		private void setHideScreen(CommandNumber _commandNumber)
        {
            /*switch (_commandNumber)
            {
                case CommandNumber.MOVIE:
                case CommandNumber.MOVIE_STAY:
                    StoryScene.HideScreenObject.SetActive(stillUnitIDList.Count == 0);
                    break;
                case CommandNumber.AUTO_END:
                    if (ManagerSingleton<ViewManager>.Instance.CurrentViewId != eViewId.STORY_ADVENTURE)
                        break;
                    StoryScene.HideScreenObject.SetActive(true);
                    break;
                case CommandNumber.DIALOG_ANIMATION:
                    StoryScene.HideScreenObject.SetActive(getCurrentCommandArgInt(0, 0) == 0);
                    break;
                default:
                    StoryScene.HideScreenObject.SetActive(false);
                    break;
            }*/
        }



		private List<CommandStruct> loadStoryDataImmidately(int _storyId)
		{
			List<CommandStruct> result = null;
			try
			{
				TextAsset textAsset = resourceManager.LoadStoryDataById(_storyId);
				List<CommandStruct> commandList = getParser().ConvertBinaryToCommandList(textAsset.bytes);
				result = commandListFilter(commandList);
			}
			catch (Exception e)
			{
				Debug.LogWarning(e);
			}
			return result;
		}

		public void StartStory()
		{
			IsEndStory = false;
			PlayingStory = true;
			isSkipStory = false;
			IsNextAutoChoiceDisable = false;
			currentCommandIndex = 0;
			StoryScene.StartStory();
			touchDelegateList = new List<TouchDelegate>();
			base.StartStory();
			if (currentCommandIndex == 0)
			{
				//beforeMovieVoiceLevel = movieManager.VolumeVoiceLevel;
				//beforeIsMuteVoice = movieManager.IsMuteVoice;
			}
			if (currentCommandIndex > 0)
			{
				int num = 0;
				if (ExecCommandLogList.Count > 0)
				{
					num = ExecCommandLogList[ExecCommandLogList.Count - 1];
					if (storyCommandList[num].Number != CommandNumber.PRINT)
					{
						num = ExecCommandLogList[ExecCommandLogList.Count - 2];
					}
					//StoryHistoryInformation history = historyInfoDictionary[num];
					//ResetSceneForHistoryInfo(history);
				}
				List<CommandNumber> list = new List<CommandNumber>
				{
					CommandNumber.NOVOICE,
					CommandNumber.TITLE,
					CommandNumber.OUTLINE,
					CommandNumber.BGM,
					CommandNumber.BACKGROUND,
					CommandNumber.PRINT,
					CommandNumber.DOUBLE,
					CommandNumber.TEXT_SIZE,
					CommandNumber.WHITE_IN,
					CommandNumber.WHITE_OUT,
					CommandNumber.BLACK_IN,
					CommandNumber.BLACK_OUT,
					CommandNumber.TAG
				};
				bool flag = true;
				for (int i = 0; i < currentCommandIndex; i++)
				{
					CommandStruct commandStruct = storyCommandList[i];
					if (list.Contains(commandStruct.Number))
					{
						CommandNumber number = commandStruct.Number;
						if (number == CommandNumber.NOVOICE || number == CommandNumber.TITLE || number == CommandNumber.OUTLINE || num <= i)
						{
							StoryCommandBase storyCommandBase = CommandDictionary[commandStruct.Name];
							storyCommandBase.SetCallback(null);
							List<string> args = commandStruct.Args;
							if (number != CommandNumber.TAG)
							{
								switch (number)
								{
									case CommandNumber.BLACK_OUT:
									case CommandNumber.WHITE_OUT:
										args.Clear();
										args.Add("1");
										args.Add("0");
										break;
									case CommandNumber.BLACK_IN:
									case CommandNumber.WHITE_IN:
										args.Clear();
										args.Add("0");
										args.Add("0");
										break;
								}
							}
							else
							{
								int item = int.Parse(args[0]);
								flag = selectGotoTagList.Contains(item);
							}
							storyCommandBase.InitParam(commandStruct.Name, args.ToArray(), 0);
							storyCommandBase.ExecCommand();
							storyCommandBase.SetCallback(new Action<int>(base.CompleteExecCommand));
							if (flag)
							{
								//saveLog(i, false);
							}
						}
					}
				}
				//StoryScene.TextLabel.fontSize = 23;
				//StoryScene.DoubleLabel.fontSize = 23;
				//SetTextFrameVisible(false);
/*				if (storyTemp.OKHKOMODOFL)
				{
					StoryHistoryInformation storyHistoryInformation = new StoryHistoryInformation();
					storyHistoryInformation.SetupCurrentInfo();
					historyInfoDictionary.Add(currentCommandIndex, storyHistoryInformation);
				}*/
				touchDelegateList.Clear();
			}
			SetStoryMenuVisible(true);
/*			if (ExecCommandLogList.Count != 0)
			{
				storyMenu.SetLogButtonEnabled(true);
			}
			else
			{
				storyMenu.SetLogButtonEnabled(false);
			}*/
/*			if (VoiceCueSheetName != "")
			{
				//soundManager.LoadStoryVoice(VoiceCueSheetName, VoiceCueSheetName + ".acb", VoiceCueSheetName + ".awb");
			}
			if (InsertStoryVoiceCueSheetName != "")
			{
				//soundManager.LoadStoryVoice(InsertStoryVoiceCueSheetName, InsertStoryVoiceCueSheetName + ".acb", InsertStoryVoiceCueSheetName + ".awb");
			}*/
			//StoryScene.SetDoubleLabelVisible(false);
			//Singleton<StoryChoiceController>.Instance.ResetChoiceCount();
		}
		public void ReleaseMovieStayCommandAction()
		{
/*			if (StayCommandMovieID != 0L)
			{
				if (ManagerSingleton<MovieManager>.Instance.IsPause(eMovieType.STORY, StayCommandMovieID, 0L))
				{
					ManagerSingleton<MovieManager>.Instance.Stop(eMovieType.STORY, StayCommandMovieID, 0f, null, 0L);
				}
				StayCommandMovieID = 0L;
			}*/
		}
		public override void ExecCurrentCommand()
		{
			if (PlayingStory)
			{
				execCommand(currentCommandIndex);
			}
		}

		public void SetStoryMenuVisible(bool _visible)
		{

			//skipButtonOnlyStoryMenu.gameObject.SetActive(false);
			storyMenu.gameObject.SetActive(_visible);
			IsUIVisibleCommand = _visible;
		}

        public override void FeedPage(bool _isSave = true, bool _playEffect = true)
        {
            if (this.CheckFeedPage())
            {
                int count = this.storyCommandList.Count;
                StoryCommandWait waitCommand = (StoryCommandWait)this.CommandDictionary["wait"];
                if (waitCommand.IsWait)
                {
                    waitCommand.SetCallback(index => waitCommand.SetCallback(new Action<int>(CompleteExecCommand)));
                    waitCommand.OnCompleteWait();
                }
                this.SkipCharaMove();
                if (this.storyCommandList[this.currentCommandIndex].Number != CommandNumber.TOUCH)
                    ++this.currentCommandIndex;
                CommandStruct storyCommand1 = this.storyCommandList[this.currentCommandIndex];
                StoryCommandBase command1 = this.CommandDictionary[storyCommand1.Name];
                if (storyCommand1.Number == CommandNumber.MOVIE || storyCommand1.Number == CommandNumber.MOVIE_STAY)
                {
                    this.FinishTypeWrite(true);
                    List<string> stringList = new List<string>((IEnumerable<string>)storyCommand1.Args);
                    CommandStruct storyCommand2 = this.storyCommandList[this.currentCommandIndex];
                    StoryCommandBase command2 = this.CommandDictionary[storyCommand2.Name];
                    command2.InitParam(storyCommand2.Name, stringList.ToArray(), this.currentCommandIndex);
                    command2.ExecCommand();
                }
                else
                {
                    for (; this.currentCommandIndex < count && this.storyCommandList[this.currentCommandIndex].Number != CommandNumber.TOUCH; ++this.currentCommandIndex)
                    {
                        this.FinishTypeWrite(false);
                        CommandStruct storyCommand3 = this.storyCommandList[this.currentCommandIndex];
                        StoryCommandBase command3 = this.CommandDictionary[storyCommand3.Name];
                        if (storyCommand3.Number == CommandNumber.BUSTUP)
                        {
                            command3.SetCallback((System.Action<int>)null);
                            command3.InitParam(storyCommand3.Name, storyCommand3.Args.ToArray(), this.currentCommandIndex);
                            command3.ExecCommand();
                            command3.SetCallback(new System.Action<int>(((StoryManagerBase<StoryManager>)this).CompleteExecCommand));
                            break;
                        }
                        /*if (_isSave)
                            this.saveLog(this.currentCommandIndex);*/
                        List<string> stringList = new List<string>(storyCommand3.Args);
                        switch (storyCommand3.Number)
                        {
                            case CommandNumber.WAIT:
                                continue;
                            case CommandNumber.IN_L:
                            case CommandNumber.IN_R:
                            case CommandNumber.OUT_L:
                            case CommandNumber.OUT_R:
                                command3.SetCallback(null);
                                command3.InitParam(storyCommand3.Name, stringList.ToArray(), this.currentCommandIndex);
                                command3.ExecCommand();
                                this.SkipCharaMove();
                                this.touchDelegateList.Remove(new TouchDelegate(command3.OnTouchDelegate));
                                command3.SetCallback(new Action<int>(CompleteExecCommand));
                                continue;
                            case CommandNumber.FADEIN:
                                command3.SetCallback(null);
                                if (stringList.Count == 2)
                                {
                                    stringList.RemoveAt(1);
                                    stringList.Insert(1, "0");
                                }
                                command3.InitParam(storyCommand3.Name, stringList.ToArray(), this.currentCommandIndex);
                                command3.ExecCommand();
                                this.touchDelegateList.Remove(new TouchDelegate(command3.OnTouchDelegate));
                                command3.SetCallback(new Action<int>(CompleteExecCommand));
                                break;
                            case CommandNumber.FADEOUT:
                                command3.SetCallback(null);
                                if (stringList.Count == 2)
                                {
                                    stringList.RemoveAt(1);
                                    stringList.Insert(1, "0");
                                }
                                command3.InitParam(storyCommand3.Name, stringList.ToArray(), this.currentCommandIndex);
                                command3.ExecCommand();
                                this.touchDelegateList.Remove(new TouchDelegate(command3.OnTouchDelegate));
                                command3.SetCallback(new Action<int>(CompleteExecCommand));
                                break;
                            case CommandNumber.CHANGE:
                                if (stringList.Count == 3)
                                {
                                    stringList.RemoveAt(2);
                                    stringList.Insert(2, "0");
                                }
                                command3.SetCallback(null);
                                command3.InitParam(storyCommand3.Name, stringList.ToArray(), this.currentCommandIndex);
                                command3.ExecCommand();
                                command3.SetCallback(new Action<int>(CompleteExecCommand));
                                continue;
                            case CommandNumber.PAN:
                                command3.SetCallback(null);
                                command3.InitParam(storyCommand3.Name, stringList.ToArray(), this.currentCommandIndex);
                                command3.ExecCommand();
                                //this.SkipStillPan();
                                this.touchDelegateList.Remove(new TouchDelegate(command3.OnTouchDelegate));
                                command3.SetCallback(new Action<int>(CompleteExecCommand));
                                continue;
                        }
                        switch (storyCommand3.Category)
                        {
                            case CommandCategory.Motion:
                                continue;
                            case CommandCategory.Effect:
                                if (!_playEffect)
                                    continue;
                                break;
                        }
                        command3.SetCallback(null);
                        command3.InitParam(storyCommand3.Name, storyCommand3.Args.ToArray(), this.currentCommandIndex);
                        command3.ExecCommand();
                        command3.SetCallback(new Action<int>(CompleteExecCommand));
                    }
                    this.FinishTypeWrite(true);
                    this.CommandDictionary[this.storyCommandList[this.currentCommandIndex].Name].ExecCommand();
                }
            }
            else
            {
                if (this.touchDelegateList.Count != 0)
                {
                    int count = this.touchDelegateList.Count;
                    for (int index = 0; index < count; ++index)
                    {
                        if (this.touchDelegateList[index]())
                            return;
                    }
                }
                if (this.currentCommandIndex > 0 && this.currentCommandIndex < this.storyCommandList.Count - 1 && this.storyCommandList[this.currentCommandIndex].Number == CommandNumber.TOUCH)
                {
                    /*if (!this.StoryScene.IsAutoPlay)
                        this.soundManager.PlaySe(eSE.SYS_WINDOW_CLOSE);
                    List<StoryCharacter> activeCharacter = this.StoryScene.GetActiveCharacter(true);
                    int count = activeCharacter.Count;
                    for (int index = 0; index < count; ++index)
                    {
                        activeCharacter[index].EndEffect();
                        activeCharacter[index].EndEmotion();
                    }
                    this.soundManager.StopStory();
                    this.StoryScene.StoryCharacterEndTalkAnimation();
                    if (this.IsFadeStopBgm)
                    {
                        if (this.BgmAudioPlayBackDic[this.FadeStopTargetChannel].EHFHMILAFJF.Equals(this.FadeStopRemoveCueSheetName))
                        {
                            this.soundManager.StopFadeBgm(this.FadeStopTargetChannel, 2f / (float)this.StoryScene.CommandTimeScale, (System.Action)(() => this.IsFadeStopBgm = false));
                        }
                        else
                        {
                            this.IsFadeStopBgm = false;
                            this.FadeStopTargetChannel = -1;
                            this.FadeStopRemoveCueSheetName = "";
                        }
                    }*/
                }
                this.ExecNextCommand();
            }
        }


        public void AddChoiceButton(string _labelText, int _tag, int _affectParam, bool _isAutoChoice)
		{
			StoryScene.MenuBar.ChangeAutoButton(false);
/*			StoryScene.SetEnableMask(true, 1200);
			StoryChoiceController instance = Singleton<StoryChoiceController>.Instance;
			instance.OpenChoiceButton(_labelText, _tag, _affectParam, _isAutoChoice);*/
			if (storyCommandList[currentCommandIndex + 1].Number == CommandNumber.CHOICE)
			{
				ExecNextCommand();
				return;
			}
			/*instance.AutoPlayContinuation = StoryScene.IsAutoPlay;
			if (Singleton<UserData>.Instance.IsReleaseAutoChoices())
			{
				bool flag = !(ManagerSingleton<SaveDataManager>.Instance != null) || ManagerSingleton<SaveDataManager>.Instance.AutoChoicesSetting;
				StoryChoiceController instance2 = Singleton<StoryChoiceController>.Instance;
				if (IsNextAutoChoiceDisable || (instance2.ChoiceButtonCount > 1 && !flag))
				{
					StoryScene.StopAutoPlay();
				}
			}
			else
			{
				StoryScene.StopAutoPlay();
			}
			IsNextAutoChoiceDisable = false;
			ReleaseMovieStayCommandAction();
			instance.AdjustChoiceButton();*/
		}
		protected virtual List<CommandStruct> commandListFilter(List<CommandStruct> _commandList)
		{
			return _commandList;
		}

		public void SetTouchDelegate(TouchDelegate _touchDelegate)
        {
            if (touchDelegateList.Contains(_touchDelegate))
                return;
            touchDelegateList.Add(_touchDelegate);
        }

        public void RemoveTouchDelegate(TouchDelegate _touchDelegate)
        {
            if (!touchDelegateList.Contains(_touchDelegate))
                return;
            touchDelegateList.Remove(_touchDelegate);
        }
    }
}