using System;
using UnityEngine;

namespace Elements
{
	public class StoryCommandWait : StoryCommandBase
	{
		public bool IsWait
		{
			get
			{
				return isWait;
			}
		}

		protected override void SetCommandParam()
		{
			maxTimeCount = int.Parse(args[0]);
			maxTimeCount /= timeScale;
			if (maxTimeCount < 1)
			{
				maxTimeCount = 1;
			}
		}

		public override void ExecCommand()
		{
			timeScale = storyManager.StoryScene.CommandTimeScale;
			SetCommandParam();
			waitTargetObj = StoryManagerBase<StoryManager>.Instance.StoryScene.TextLabel.gameObject;
			if (!waitTargetObj.activeSelf)
			{
				waitTargetObj = storyManager.StoryScene.gameObject;
			}
			WaitComponent waitComponent = waitTargetObj.GetComponent<WaitComponent>();
			if (waitComponent != null)
			{
				UnityEngine.Object.DestroyImmediate(waitComponent);
			}
			waitComponent = waitTargetObj.AddComponent<WaitComponent>();

			waitComponent.TimeCount = 0;
			waitComponent.MaxTimeCount = maxTimeCount;
			waitComponent.WaitComplete = new WaitCompleteDelegate(OnCompleteWait);
			storyManager.SetTouchDelegate(new TouchDelegate(OnTouchDelegate));
			isWait = true;
			Debug.Log("StoryCommandWait");
		}

		// Token: 0x06002CDA RID: 11482 RVA: 0x000043CB File Offset: 0x000025CB
		public override bool OnTouchDelegate()
		{
			return true;
		}

		// Token: 0x06002CDB RID: 11483 RVA: 0x0001F170 File Offset: 0x0001D370
		public void OnCompleteWait()
		{
			waitTargetObj.GetComponent<WaitComponent>().WaitComplete = null;
			isWait = false;
			OnCompleteCommand();
		}

		private bool isWait;

		private GameObject waitTargetObj;

		private int maxTimeCount;

		private int timeScale;

		private enum eArgs
		{
			WAIT_TIME,
			MAX
		}
	}
}
