using System;
using System.Collections.Generic;
using UnityEngine;

namespace Elements
{
	// Token: 0x02000496 RID: 1174
	public class StoryCommandCharacterFull : StoryCommandBase
	{
		// Token: 0x17000944 RID: 2372
		// (get) Token: 0x06002AC8 RID: 10952 RVA: 0x0001DDF3 File Offset: 0x0001BFF3
		// (set) Token: 0x06002AC9 RID: 10953 RVA: 0x0001DDFB File Offset: 0x0001BFFB
		public bool NoFade { get; set; }

		protected override void SetCommandParam()
		{
			unitId = int.Parse(args[0]);
			characterPos = args[1];
			faceId = (int.Parse(args[2]) == 0) ? 1 : int.Parse(args[2]);
			isEyeClose = false;
			defaultCharaPos = "Chara" + characterPos;
			if (args.Length > 3)
			{
				isEyeClose = (int.Parse(args[3]) == 1);
			}
		}

		// Token: 0x06002ACB RID: 10955 RVA: 0x00193440 File Offset: 0x00191640
		public override void ExecCommand()
		{
			storyManager.SetTouchDelegate(new TouchDelegate(OnTouchDelegate));
			SetCommandParam();
			/*			StoryCharacter characterWithName = storyManager.StoryScene.GetCharacterWithName(unitId.ToString());
						if (characterWithName != null)
						{
							characterWithName.StoryCharacterSetUp(0, 1, false, eSpineType.SD_FULL_NGUI, false);
							characterWithName.name = defaultCharaPos;
						}
						StoryCharacter characterWithPos = storyManager.StoryScene.GetCharacterWithPos(characterPos);
						if (NoFade)
						{
							NoFade = false;
							onCompleteFadeOut(characterWithPos);
							return;
						}
						if (characterWithPos.name != defaultCharaPos)
						{
							int commandTimeScale = storyManager.StoryScene.CommandTimeScale;
							characterFadeout(characterWithPos, commandTimeScale);
							return;
						}
						noCharachange(characterWithPos);*/
			Debug.Log("StoryCommandCharacter: " + args[0] + " at " + args[1]);
			base.OnCompleteCommand();
		}

		// Token: 0x06002ACC RID: 10956 RVA: 0x0019350C File Offset: 0x0019170C
/*		private void onCompleteFadeOut(StoryCharacter _chara)
		{
			_chara.name = unitId.ToString();
			_chara.StoryCharacterSetUp(unitId, faceId, false, eSpineType.STORY_FULL_NGUI, isEyeClose);
			playEyeAndMouthAnimation(_chara.NGUIUnitSpine);
			storyManager.StoryScene.ChangeBustUpFaceSpine(faceId);
			storyManager.StoryScene.SetCharacterSoftClipMask();
			base.OnCompleteCommand();
		}*/

		// Token: 0x06002ACD RID: 10957 RVA: 0x00193580 File Offset: 0x00191780
/*		private void noCharachange(StoryCharacter _chara)
		{
			_chara.name = unitId.ToString();
			_chara.StoryCharacterSetUp(unitId, faceId, false, eSpineType.STORY_FULL_NGUI, isEyeClose);
			_chara.SaveFace();
			_chara.SetVisible(false);
			playEyeAndMouthAnimation(_chara.NGUIUnitSpine);
			storyManager.StoryScene.ChangeBustUpFaceSpine(faceId);
			_chara.LoadFace();
			storyManager.StoryScene.SetCharacterSoftClipMask();
			base.OnCompleteCommand();
		}*/

		// Token: 0x06002ACE RID: 10958 RVA: 0x000043CB File Offset: 0x000025CB
		public override bool OnTouchDelegate()
		{
			return true;
		}

		// Token: 0x06002ACF RID: 10959 RVA: 0x00193604 File Offset: 0x00191804
/*		private void characterFadeout(StoryCharacter _chara, int _timeScale)
		{
			if (_chara.Color.a != 0f)
			{
				Color white = Color.white;
				white.a = 1f;
				_chara.Color = white;
				float timeMax = 0.3f / (float)_timeScale;
				Action <> 9__1;
				_chara.FadeOut(timeMax, delegate
				{
					_chara.ReservedFadeIn = true;
					UnityEngine.Object.Destroy(_chara.NGUIUnitSpine.gameObject);
					onCompleteFadeOut(_chara);
					if (_chara.NGUIUnitSpine != null)
					{
						float num = 0.3f / (float)_timeScale;
						StoryCharacter chara = _chara;
						float timeMax3 = num;
						Action onFinish;
						if ((onFinish = <> 9__1) == null)
						{
							onFinish = (<> 9__1 = delegate ()
							{
								_chara.LoadFace();
								_chara.ReservedFadeIn = false;
							});
						}
						chara.FadeIn(timeMax3, onFinish);
					}
				});
				return;
			}
			if (_chara.NGUIUnitSpine != null)
			{
				float timeMax2 = 0.3f / (float)_timeScale;
				_chara.FadeIn(timeMax2, delegate
				{
					_chara.LoadFace();
					_chara.ReservedFadeIn = false;
				});
			}
			onCompleteFadeOut(_chara);
		}*/

		/*private void playEyeAndMouthAnimation(NGUISpineController _spineController)
		{
			if (!isEyeClose)
			{
				_spineController.PlayAnime(0, eSpineCharacterAnimeId.STORY_EYE_IDLE, true);
			}
			_spineController.PlayAnime(1, eSpineCharacterAnimeId.STORY_MOUTH_CLOSE, true);
		}*/

		public static int GetCharacterId(List<string> _args)
		{
			return int.Parse(_args[0]);
		}

		private int unitId;

		private string characterPos = "";

		private int faceId = 1;

		private bool isEyeClose;

		private string defaultCharaPos = "";

		// Token: 0x04001B04 RID: 6916
		//private const eSpineType LOAD_SPINE_TYPE = eSpineType.STORY_FULL_NGUI;

		private enum eArgs
		{
			CHARACTER_ID,
			POSITION,
			FACE_ID,
			EYE_CLOSE,
			MAX
		}
	}
}
