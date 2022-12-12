using System.Collections.Generic;
using UnityEngine;
using Elements;
using System;
using UnityEngine.UI;

public class StoryManagerBase<T> where T : class, new()
{
    public static T Instance { get; private set; }

    public static void DeleteInstance() => Instance = default;

	public Dictionary<string, StoryCommandBase> CommandDictionary { get; private set; }

	public bool PlayingStory { get; set; }

	public List<int> LogIconIdList { get; private set; }

	public bool NoVoice { get; set; }

	public string VoiceCueSheetName { get; protected set; }

	public string InsertStoryVoiceCueSheetName { get; protected set; }

	public List<int> ExecCommandLogList { get; protected set; }

	public bool IsEndStory { get; set; }

	public bool IsVoicePage { get; set; }

	protected Image arrowIcon;

	public StorySkipDialogParams StorySkipDialogParams { get; private set; }

	public Dictionary<int, GameObject> StoryPlayEffectDic
	{
		get
		{
			return playParticleEffectDic;
		}
	}

	public bool IsWindowVisible
	{
		get
		{
			return isWindowVisible;
		}
		set
		{
			isWindowVisible = value;
		}
	}

	public bool IsBattleCommand { get; protected set; }

	public float VoEffectValue { get; set; }

	public int StartInsertStoryIndex { get; private set; }

	public int EndInsertStoryIndex { get; private set; }

	public bool IsNextAutoChoiceDisable { get; set; }

	//private protected List<int> logCommandSaveIndexList { protected get; private set; }

	//protected Dictionary<int, StoryHistoryInformation> historyInfoDictionary { get; set; }

	protected List<TouchDelegate> touchDelegateList { get; set; }

	protected bool isSkipStory { get; set; }
	public int NowTalkUnitID = -1;

	protected StoryDataConfig dataConfig;

	protected Parser parser;

	// Token: 0x04001E3B RID: 7739
	protected List<CommandStruct> storyCommandList;

	// Token: 0x04001E3C RID: 7740
	protected int currentCommandIndex;

	// Token: 0x04001E3E RID: 7742
	//protected Dictionary<string, StoryLipSyncData> storyLipSyncDictionary;

	// Token: 0x04001E40 RID: 7744
	//protected ReturnDelegate returnDelegate;

	// Token: 0x04001E42 RID: 7746
	//protected UISprite arrowIcon;

	// Token: 0x04001E43 RID: 7747
	protected GameObject textFrame;

	// Token: 0x04001E45 RID: 7749
	//protected EHPLBCOOOPK.OGEJKAHGHLD storyTemp;

	// Token: 0x04001E46 RID: 7750
	//protected LipSyncData storyLipsyncData;

	// Token: 0x04001E47 RID: 7751
	//protected LipSyncData insertStoryLipsyncData;

	// Token: 0x04001E48 RID: 7752
	private Dictionary<int, int> tagDictionary;

	// Token: 0x04001E49 RID: 7753
	private Dictionary<int, StoryLogInfo> allLogDictionary;

	// Token: 0x04001E4A RID: 7754
	private Dictionary<string, int> playingEnvDic = new Dictionary<string, int>();

	// Token: 0x04001E4B RID: 7755
	private bool isWindowVisible = true;

	// Token: 0x04001E4C RID: 7756
	private Dictionary<int, GameObject> playParticleEffectDic = new Dictionary<int, GameObject>();

	// Token: 0x04001E4D RID: 7757
	private Dictionary<string, int> playEnvReferenceCounterDict = new Dictionary<string, int>();

	// Token: 0x04001E4E RID: 7758
	//private LBJFEFJPFHC downloadObserve;

	// Token: 0x04001E4F RID: 7759
	//private ResourceManager resourceManager = ManagerSingleton<ResourceManager>.Instance;

	// Token: 0x04001E50 RID: 7760
	//private DownloadManager downloadManager = ManagerSingleton<DownloadManager>.Instance;

	// Token: 0x04001E51 RID: 7761
	private const int MOB_ICON_KEY_ID = 0;

	public static T CreateInstance()
    {
        if (Instance == null)
            Instance = new T();
        return Instance;
    }

	public void CompleteExecCommand(int _index)
	{
		if (_index == currentCommandIndex)
		{
			ExecNextCommand();
		}
	}
	public void ExecNextCommand()
	{
		if (touchDelegateList.Count != 0)
		{
			int count = touchDelegateList.Count;
			for (int i = 0; i < count; i++)
			{
				if (touchDelegateList[i]())
				{
					return;
				}
			}
		}
		SetArrowIconVisible(false);
		currentCommandIndex++;
		ExecCurrentCommand();
	}
	public virtual void ExecCurrentCommand()
	{
	}
	public virtual void Init()
	{
		dataConfig = new StoryDataConfig();
		CommandDictionary = new Dictionary<string, StoryCommandBase>();
		PlayingStory = false;
		StorySkipDialogParams = new StorySkipDialogParams();
		StartInsertStoryIndex = 0;
		EndInsertStoryIndex = 0;
		IsWindowVisible = true;
	}

	public string GetNextCommandName()
	{
		try
		{
			int num = currentCommandIndex + 1;
			if (num < storyCommandList.Count)
			{
				return storyCommandList[num].Name;
			}
		}
		catch (Exception)
		{
		}
		return "";
	}
	public bool IsTypeWriting()
	{
		bool result = false;
		if (CommandDictionary != null)
		{
			result = (CommandDictionary["print"] as StoryCommandPrint).IsTypeWriting();
		}
		return result;
	}
	public virtual void FeedPage(bool _isSave = true, bool _playEffect = true)
    {
    }
    public bool CheckFeedPage()
    {
        int count1 = storyCommandList.Count;
        CommandStruct storyCommand1 = storyCommandList[currentCommandIndex];
        CommandNumber number = storyCommand1.Number;
        if (currentCommandIndex >= count1 || number == CommandNumber.BLACK_IN || number == CommandNumber.BLACK_OUT || number == CommandNumber.WHITE_IN || number == CommandNumber.WHITE_OUT)
            return false;
        if (IsTypeWriting())
            return true;
        if (storyCommand1.Category == CommandCategory.Motion)
        {
            switch (number)
            {
                case CommandNumber.IN_L:
                case CommandNumber.IN_R:
                case CommandNumber.OUT_L:
                case CommandNumber.OUT_R:
                case CommandNumber.FADEIN:
                case CommandNumber.FADEOUT:
                case CommandNumber.IN_FLOAT:
                case CommandNumber.SHAKE:
                case CommandNumber.SCALE:
                case CommandNumber.CHANGE:
                case CommandNumber.FADEOUT_ALL:
                case CommandNumber.CHARA_FULL:
                case CommandNumber.SWAY:
                case CommandNumber.PAN:
                case CommandNumber.SLIDE_CHARA:
                case CommandNumber.CHARA_SHADOW:
                case CommandNumber.FADEIN_ALL:
                case CommandNumber.CHARACTER_UP_DOWN:
                    return false;
                default:
                    return true;
            }
        }
        else
        {
            if (number != CommandNumber.WAIT)
                return false;
            bool flag = false;
            int count2 = storyCommandList.Count;
            for (int index = currentCommandIndex + 1; index < count2; ++index)
            {
                CommandStruct storyCommand2 = storyCommandList[index];
                if (storyCommand2.Number == CommandNumber.PRINT)
                {
                    flag = true;
                    break;
                }
                switch (storyCommand2.Number)
                {
                    case CommandNumber.TOUCH:
                    case CommandNumber.CHOICE:
                    case CommandNumber.CHANGE:
                    case CommandNumber.BUSTUP:
                        return false;
                    default:
                        continue;
                }
            }
            for (int index = currentCommandIndex - 1; index > 0; --index)
            {
                CommandStruct storyCommand3 = storyCommandList[index];
                if (storyCommand3.Number == CommandNumber.PRINT)
                {
                    //flag = flag;
                    break;
                }
                if (storyCommand3.Number == CommandNumber.TOUCH)
                    return false;
            }
            return flag;
        }
    }
    // Token: 0x06002E1F RID: 11807 RVA: 0x0019F8A8 File Offset: 0x0019DAA8
    public string GetCurrentCommandName()
	{
		try
		{
			return storyCommandList[currentCommandIndex].Name;
		}
		catch (Exception)
		{
		}
		return "";
	}
    public virtual void FinishTypeWrite(bool _isCallback = true)
    {
    }

    // Token: 0x06002E21 RID: 11809 RVA: 0x00003855 File Offset: 0x00001A55
    public virtual void SkipCharaMove()
    {
    }
    public bool CheckPrintBetweenCommand(int printIndex, List<string> checkCommands)
	{
		int count = checkCommands.Count;
		for (int i = printIndex - 1; i >= 0; i--)
		{
			string name = storyCommandList[i].Name;
			if (name == "print")
			{
				return false;
			}
			for (int j = 0; j < count; j++)
			{
				if (name == checkCommands[j])
				{
					return true;
				}
			}
		}
		return false;
	}

	protected void setDetailFromStoryData(int _storyId, bool _isVoiceDownLoad, List<CommandStruct> _commandList)
	{
        currentCommandIndex = 0;
        //storyLipSyncDictionary = new Dictionary<string, StoryLipSyncData>();
        tagDictionary = new Dictionary<int, int>();
        allLogDictionary = new Dictionary<int, StoryLogInfo>();
        LogIconIdList = new List<int>();
        //logCommandSaveIndexList = new List<int>();
        string text = "";
        string text2 = "";
        string text3 = "";
        string text4 = null;
        int count = _commandList.Count;
        int num = count;
        string text5 = "";
        int num2 = 1;
        int num3 = 0;
        int num4 = 0;
        bool flag = _isVoiceDownLoad;
        NoVoice = !flag;
        float voEffectValue = 0f;
        List<string> list = new List<string>();
        List<string> list2 = new List<string>();
        for (int i = 0; i < count; i++)
        {
            CommandNumber number = _commandList[i].Number;
            List<string> args = _commandList[i].Args;
            if (number <= CommandNumber.ENV)
            {
                if (number <= CommandNumber.DOUBLE)
                {
                    switch (number)
                    {
                        case CommandNumber.PRINT:
                            break;
                        case CommandNumber.TAG:
                            tagDictionary.Add(StoryCommandTag.GetTagId(args), i);
                            continue;
                        case CommandNumber.GOTO:
                        case CommandNumber.BGM:
                        case CommandNumber.CHOICE:
                            continue;
                        case CommandNumber.TOUCH:
                            if (text2.Length != 0)
                            {
                                addLog(num, text4, text2, text3, text, voEffectValue);
                                num = _commandList.Count;
                                text = "";
                                text2 = "";
                                text3 = "";
                                text4 = "101";
                                continue;
                            }
                            continue;
                        case CommandNumber.VO:
                        {
                            text = StoryCommandVo.GetVoiceName(args);
                            text5 = text.Replace("vo_adv_", "").Replace("_", "");
                            num2 = 1;
                            if (flag)
                            {
                                VoiceCueSheetName = string.Format("vo_adv_{0:D7}", _storyId);
                            }
                            int num5 = int.Parse(text5.Substring(0, 7));
                            //LipSyncData lipSyncData = (num5 == _storyId) ? storyLipsyncData : insertStoryLipsyncData;
                            if (num5 != 1900999)
                            {
                                //storyLipSyncDictionary[text5] = AdvUtility.CreateLipsyncData(lipSyncData, text5, ref num3);
                                continue;
                            }
                            //storyLipSyncDictionary[text5] = AdvUtility.CreateLipsyncData(lipSyncData, text5, ref num4);
                            continue;
                        }
                        default:
                            if (number != CommandNumber.DOUBLE)
                            {
                                continue;
                            }
                            break;
                    }
                    text2 = StoryCommandPrint.GetName(args);
                    text3 += StoryCommandPrint.GetMainText(args);
                    if (i < num)
                    {
                        num = i;
                    }
                }
                else if (number != CommandNumber.LOG)
                {
                    if (number != CommandNumber.NOVOICE)
                    {
                        switch (number)
                        {
                            case CommandNumber.BATTLE:
                                IsBattleCommand = true;
                                break;
                            case CommandNumber.BUSTUP:
                                text4 = StoryCommandBustup.GetCharacterId(args);
                                //LogIconIdList.AddIfNoContains(int.Parse(text4));
                                break;
                            case CommandNumber.ENV:
                            {
                                /*list2.Clear();
                                string seId = StoryCommandEnv.GetSeId(args);
                                if (playEnvReferenceCounterDict.ContainsKey(seId))
                                {
                                    Dictionary<string, int> dictionary = playEnvReferenceCounterDict;
                                    string key = seId;
                                    int num6 = dictionary[key];
                                    dictionary[key] = num6 + 1;
                                }
                                else
                                {
                                    playEnvReferenceCounterDict.Add(seId, 1);
                                }
                                list.Add(seId);*/
                                break;
                            }
                        }
                    }
                    else
                    {
                        flag = false;
                    }
                }
                else
                {
                    string charaId = args[0];
                    string name = args[1];
                    string text6 = args[2];
                    string playVoiceName = "";
                    if (args.Count == 4)
                    {
                        playVoiceName = args[3];
                    }
                    int[] array = new int[allLogDictionary.Keys.Count];
                    allLogDictionary.Keys.CopyTo(array, 0);
                    int num7 = array[array.Length - 1];
                    addLog(num7 + 1, charaId, name, text6, playVoiceName, voEffectValue);
                    //logCommandSaveIndexList.Add(num7 + 1);
                    if (_commandList[i - 1].Number == CommandNumber.TOUCH)
                    {
                        _commandList.Reverse(i - 1, 2);
                    }
                }
            }
            else if (number <= CommandNumber.CHARA_FULL)
            {
                if (number != CommandNumber.ENV_STOP)
                {
                    if (number != CommandNumber.ENV_RESUME)
                    {
                        if (number == CommandNumber.CHARA_FULL)
                        {
                            /*int characterId = StoryCommandCharacterFull.GetCharacterId(args);
                            if (characterId != 0)
                            {
                                LogIconIdList.AddIfNoContains(characterId);
                            }*/
                        }
                    }
                    /*else if (StoryCommandEnvResume.IsResumeTargetCueName(args))
                    {
                        string cueName = StoryCommandEnvResume.GetCueName(args);
                        if (playEnvReferenceCounterDict.ContainsKey(cueName))
                        {
                            Dictionary<string, int> dictionary2 = playEnvReferenceCounterDict;
                            string key = cueName;
                            int num6 = dictionary2[key];
                            dictionary2[key] = num6 + 1;
                        }
                    }*/
                    else
                    {
                        for (int j = 0; j < list2.Count; j++)
                        {
                            string text7 = list2[j];
                            if (playEnvReferenceCounterDict.ContainsKey(text7))
                            {
                                Dictionary<string, int> dictionary3 = playEnvReferenceCounterDict;
                                string key = text7;
                                int num6 = dictionary3[key];
                                dictionary3[key] = num6 + 1;
                            }
                        }
                    }
                }
                /*else if (StoryCommandEnvStop.IsStopTargetCueName(args))
                {
                    string cueName2 = StoryCommandEnvStop.GetCueName(args);
                    list2.Add(cueName2);
                    list.Remove(cueName2);
                }*/
                else
                {
                    list2.AddRange(list);
                    list.Clear();
                }
            }
            else if (number != CommandNumber.WAIT_TOKEN)
            {
                if (number != CommandNumber.VOICE_EFFECT)
                {
                    if (number == CommandNumber.MINI_GAME)
                    {
/*                        if (!IsPlayedMiniGame)
                        {
                            IsMiniGameCommand = true;
                        }*/
                    }
                }
                else
                {
                    voEffectValue = 0f;
                    if (args.Count > 0)
                    {
                        voEffectValue = float.Parse(args[0]) * 0.1f;
                    }
                }
            }
            else
            {
                //num2 = (StoryCommandWaitToken.IsExistParameter(args) ? StoryCommandWaitToken.GetWaitCount(args) : num2);
                //num2 = AdvUtility.CreateWaitCommandFromTokenCommand(_commandList, storyLipSyncDictionary, i, text5, num2);
            }
        }
        //LogIconIdList.AddIfNoContains(0);
    }

    private void addLog(int _commandIndex, string _charaId, string _name, string _text, string _playVoiceName, float _voEffectValue)
    {
        StoryLogInfo value = default;
        value.SetStoryLogInfo(_commandIndex, _charaId, _name, _text, _playVoiceName, _voEffectValue);
        allLogDictionary.Add(_commandIndex, value);
    }

    public void GotoTag(int _tag)
	{
		if (tagDictionary.ContainsKey(_tag))
		{
			currentCommandIndex = tagDictionary[_tag];
		}
	}

	public void SetArrowIconVisible(bool _visible)
	{
		if (arrowIcon != null)
		{
			arrowIcon.enabled = _visible;
		}
	}
	public void StartStory()
	{
		if (currentCommandIndex == 0)
		{
			ExecCommandLogList = new List<int>();
			//historyInfoDictionary = new Dictionary<int, StoryHistoryInformation>();
		}
	}

}
