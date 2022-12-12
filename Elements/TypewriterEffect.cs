using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using TMPro;

// Token: 0x02000110 RID: 272
[AddComponentMenu("UGUI/Interaction/Typewriter Effect")]
[RequireComponent(typeof(TextMeshProUGUI))]
public class TypewriterEffect : MonoBehaviour
{
	public static TypewriterEffect current;

	public int charsPerSecond = 20;

	public List<EventDelegate> onFinished = new List<EventDelegate>();

	protected TextMeshProUGUI mTextUI;

	protected string mFullText = "";

	protected int mCurrentOffset;

	protected bool mReset = true;

	protected bool mActive;

	protected float mNextChar;

	public float delayOnPeriod;

	// Token: 0x04000498 RID: 1176
	public float delayOnNewLine;
	public bool isActive
	{
		get
		{
			return mActive;
		}
	}

	public void ResetToBeginning()
	{
		Finish();
		mReset = true;
		mActive = true;
		mCurrentOffset = 0;
		Update();
	}

	public void ResetToOffset(int offset)
	{
		//Debug.Log(string.Format("TypeWriter: Reset to {0}", offset));
		if (offset == 0)
		{
			ResetToBeginning();
			return;
		}
		mTextUI = GetComponent<TextMeshProUGUI>();
		mFullText = mTextUI.text.Replace("</color>", "").Replace("<color=#3C404EFF>", "");
		mReset = false;
		mCurrentOffset = offset;
		mActive = true;
		mNextChar = 0f;
		Update();
	}

	public void Finish()
	{
		//Debug.Log("TypeWriter: Finish");
		if (mActive)
		{
			mActive = false;
			if (!mReset)
			{
				mCurrentOffset = mFullText.Length;
				mTextUI.maxVisibleCharacters = mCurrentOffset;
			}
			current = this;
			EventDelegate.Execute(onFinished);
			current = null;
		}
	}

	private void OnEnable()
	{
		mReset = true;
		mActive = true;
		mTextUI = GetComponent<TextMeshProUGUI>();
	}

	private void OnDisable()
	{
		Finish();
	}

	protected virtual void Update()
	{
		if (!mActive)
		{
			return;
		}
		if (mReset)
		{
			mCurrentOffset = 0;
			mReset = false;
			//reset to 0
			mFullText = mTextUI.text.Replace("</color>", "").Replace("<color=#3C404EFF>", "");
			mTextUI.maxVisibleCharacters = mCurrentOffset;
		}
		if (string.IsNullOrEmpty(mFullText))
		{
			return;
		}
		while (mCurrentOffset < mFullText.Length && mNextChar <= RealTime.time)
		{
			charsPerSecond = Mathf.Max(1, charsPerSecond);
			mCurrentOffset++;
			//Debug.Log(string.Format("<color=#FF0000>TypeWriterUpdate: {0}</color>", mCurrentOffset));
			if (mCurrentOffset > mFullText.Length)
			{
				break;
			}
			float num2 = 1f / charsPerSecond;
			if (mNextChar == 0f)
			{
				mNextChar = RealTime.time + num2;
			}
			else
			{
				mNextChar += num2;
			}

		}
		if (mCurrentOffset >= mFullText.Length)
		{
			//mTextUI.text = mFullText;
			mTextUI.maxVisibleCharacters = mCurrentOffset;
			//Debug.Log(string.Format("<color=#FF0000>TypeWriterFinish: {0}</color>", mCurrentOffset));
			mNextChar = 0f;
			current = this;
			mActive = false;
			EventDelegate.Execute(onFinished);
			current = null;
			return;
		}
		mTextUI.maxVisibleCharacters = mCurrentOffset;
	}
}
