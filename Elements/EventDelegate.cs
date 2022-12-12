using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

// Token: 0x02000162 RID: 354
[Serializable]
public class EventDelegate
{

	public MonoBehaviour target
	{
		get
		{
			return mTarget;
		}
		set
		{
			mTarget = value;
			mCachedCallback = null;
			mRawDelegate = false;
			mCached = false;
			mMethod = null;
			mParameterInfos = null;
			mParameters = null;
		}
	}

	// Token: 0x17000100 RID: 256
	// (get) Token: 0x0600093A RID: 2362 RVA: 0x00008F13 File Offset: 0x00007113
	// (set) Token: 0x0600093B RID: 2363 RVA: 0x00008F1B File Offset: 0x0000711B
	public string methodName
	{
		get
		{
			return mMethodName;
		}
		set
		{
			mMethodName = value;
			mCachedCallback = null;
			mRawDelegate = false;
			mCached = false;
			mMethod = null;
			mParameterInfos = null;
			mParameters = null;
		}
	}

	// Token: 0x17000101 RID: 257
	// (get) Token: 0x0600093C RID: 2364 RVA: 0x00008F4E File Offset: 0x0000714E
	public EventDelegate.Parameter[] parameters
	{
		get
		{
			if (!mCached)
			{
				Cache();
			}
			return mParameters;
		}
	}

	// Token: 0x17000102 RID: 258
	// (get) Token: 0x0600093D RID: 2365 RVA: 0x00008F64 File Offset: 0x00007164
	public bool isValid
	{
		get
		{
			if (!mCached)
			{
				Cache();
			}
			return (mRawDelegate && mCachedCallback != null) || (mTarget != null && !string.IsNullOrEmpty(mMethodName));
		}
	}

	// Token: 0x17000103 RID: 259
	// (get) Token: 0x0600093E RID: 2366 RVA: 0x0011EAAC File Offset: 0x0011CCAC
	public bool isEnabled
	{
		get
		{
			if (!mCached)
			{
				Cache();
			}
			if (mRawDelegate && mCachedCallback != null)
			{
				return true;
			}
			if (mTarget == null)
			{
				return false;
			}
			MonoBehaviour monoBehaviour = mTarget;
			return monoBehaviour == null || monoBehaviour.enabled;
		}
	}

	// Token: 0x0600093F RID: 2367 RVA: 0x00003BD4 File Offset: 0x00001DD4
	public EventDelegate()
	{
	}

	// Token: 0x06000940 RID: 2368 RVA: 0x00008FA4 File Offset: 0x000071A4
	public EventDelegate(EventDelegate.Callback call)
	{
		Set(call);
	}

	// Token: 0x06000941 RID: 2369 RVA: 0x00008FB3 File Offset: 0x000071B3
	public EventDelegate(MonoBehaviour target, string methodName)
	{
		Set(target, methodName);
	}

	// Token: 0x06000942 RID: 2370 RVA: 0x00008FC3 File Offset: 0x000071C3
	private static string GetMethodName(EventDelegate.Callback callback)
	{
		return callback.Method.Name;
	}

	// Token: 0x06000943 RID: 2371 RVA: 0x00008FD0 File Offset: 0x000071D0
	private static bool IsValid(EventDelegate.Callback callback)
	{
		return callback != null && callback.Method != null;
	}

	// Token: 0x06000944 RID: 2372 RVA: 0x0011EB04 File Offset: 0x0011CD04
	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return !isValid;
		}
		if (obj is EventDelegate.Callback)
		{
			EventDelegate.Callback callback = obj as EventDelegate.Callback;
			if (callback.Equals(mCachedCallback))
			{
				return true;
			}
			MonoBehaviour y = callback.Target as MonoBehaviour;
			return mTarget == y && string.Equals(mMethodName, EventDelegate.GetMethodName(callback));
		}
		else
		{
			if (obj is EventDelegate)
			{
				EventDelegate eventDelegate = obj as EventDelegate;
				return mTarget == eventDelegate.mTarget && string.Equals(mMethodName, eventDelegate.mMethodName);
			}
			return false;
		}
	}

	// Token: 0x06000945 RID: 2373 RVA: 0x00008FE3 File Offset: 0x000071E3
	public override int GetHashCode()
	{
		return EventDelegate.s_Hash;
	}

	// Token: 0x06000946 RID: 2374 RVA: 0x0011EBA4 File Offset: 0x0011CDA4
	private void Set(EventDelegate.Callback call)
	{
		Clear();
		if (call != null && EventDelegate.IsValid(call))
		{
			mTarget = (call.Target as MonoBehaviour);
			if (mTarget == null)
			{
				mRawDelegate = true;
				mCachedCallback = call;
				mMethodName = null;
				return;
			}
			mMethodName = EventDelegate.GetMethodName(call);
			mRawDelegate = false;
		}
	}

	// Token: 0x06000947 RID: 2375 RVA: 0x00008FEA File Offset: 0x000071EA
	public void Set(MonoBehaviour target, string methodName)
	{
		Clear();
		mTarget = target;
		mMethodName = methodName;
	}

	// Token: 0x06000948 RID: 2376 RVA: 0x0011EC0C File Offset: 0x0011CE0C
	private void Cache()
	{
		mCached = true;
		if (mRawDelegate)
		{
			return;
		}
		if ((mCachedCallback == null || mCachedCallback.Target as MonoBehaviour != mTarget || EventDelegate.GetMethodName(mCachedCallback) != mMethodName) && mTarget != null && !string.IsNullOrEmpty(mMethodName))
		{
			Type type = mTarget.GetType();
			mMethod = null;
			while (type != null)
			{
				try
				{
					mMethod = type.GetMethod(mMethodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
					if (mMethod != null)
					{
						break;
					}
				}
				catch (Exception)
				{
				}
				type = type.BaseType;
			}
			if (mMethod == null)
			{
				return;
			}
			if (mMethod.ReturnType != typeof(void))
			{
				return;
			}
			mParameterInfos = mMethod.GetParameters();
			if (mParameterInfos.Length == 0)
			{
				mCachedCallback = (EventDelegate.Callback)Delegate.CreateDelegate(typeof(EventDelegate.Callback), mTarget, mMethodName);
				mArgs = null;
				mParameters = null;
				return;
			}
			mCachedCallback = null;
			if (mParameters == null || mParameters.Length != mParameterInfos.Length)
			{
				mParameters = new EventDelegate.Parameter[mParameterInfos.Length];
				int i = 0;
				int num = mParameters.Length;
				while (i < num)
				{
					mParameters[i] = new EventDelegate.Parameter();
					i++;
				}
			}
			int j = 0;
			int num2 = mParameters.Length;
			while (j < num2)
			{
				mParameters[j].expectedType = mParameterInfos[j].ParameterType;
				j++;
			}
		}
	}

	// Token: 0x06000949 RID: 2377 RVA: 0x0011EDEC File Offset: 0x0011CFEC
	public bool Execute()
	{
		if (!mCached)
		{
			Cache();
		}
		if (mCachedCallback != null)
		{
			mCachedCallback();
			return true;
		}
		if (mMethod != null)
		{
			if (mParameters == null || mParameters.Length == 0)
			{
				mMethod.Invoke(mTarget, null);
			}
			else
			{
				if (mArgs == null || mArgs.Length != mParameters.Length)
				{
					mArgs = new object[mParameters.Length];
				}
				int i = 0;
				int num = mParameters.Length;
				while (i < num)
				{
					mArgs[i] = mParameters[i].value;
					i++;
				}
				try
				{
					mMethod.Invoke(mTarget, mArgs);
				}
				catch (ArgumentException ex)
				{
					string text = "Error calling ";
					if (mTarget == null)
					{
						text += mMethod.Name;
					}
					else
					{
						text = string.Concat(new object[]
						{
							text,
							mTarget.GetType(),
							".",
							mMethod.Name
						});
					}
					text = text + ": " + ex.Message;
					text += "\n  Expected: ";
					if (mParameterInfos.Length == 0)
					{
						text += "no arguments";
					}
					else
					{
						text += mParameterInfos[0];
						for (int j = 1; j < mParameterInfos.Length; j++)
						{
							text = text + ", " + mParameterInfos[j].ParameterType;
						}
					}
					text += "\n  Received: ";
					if (mParameters.Length == 0)
					{
						text += "no arguments";
					}
					else
					{
						text += mParameters[0].type;
						for (int k = 1; k < mParameters.Length; k++)
						{
							text = text + ", " + mParameters[k].type;
						}
					}
					text += "\n";
				}
				int l = 0;
				int num2 = mArgs.Length;
				while (l < num2)
				{
					if (mParameterInfos[l].IsIn || mParameterInfos[l].IsOut)
					{
						mParameters[l].value = mArgs[l];
					}
					mArgs[l] = null;
					l++;
				}
			}
			return true;
		}
		return false;
	}

	// Token: 0x0600094A RID: 2378 RVA: 0x0011F094 File Offset: 0x0011D294
	public void Clear()
	{
		mTarget = null;
		mMethodName = null;
		mRawDelegate = false;
		mCachedCallback = null;
		mParameters = null;
		mCached = false;
		mMethod = null;
		mParameterInfos = null;
		mArgs = null;
	}

	// Token: 0x0600094B RID: 2379 RVA: 0x0011F0E0 File Offset: 0x0011D2E0
	public override string ToString()
	{
		if (mTarget != null)
		{
			string text = mTarget.GetType().ToString();
			int num = text.LastIndexOf('.');
			if (num > 0)
			{
				text = text.Substring(num + 1);
			}
			if (!string.IsNullOrEmpty(methodName))
			{
				return text + "/" + methodName;
			}
			return text + "/[delegate]";
		}
		else
		{
			if (!mRawDelegate)
			{
				return null;
			}
			return "[delegate]";
		}
	}

	// Token: 0x0600094C RID: 2380 RVA: 0x0011F160 File Offset: 0x0011D360
	public static void Execute(List<EventDelegate> list)
	{
		if (list != null)
		{
			for (int i = 0; i < list.Count; i++)
			{
				EventDelegate eventDelegate = list[i];
				if (eventDelegate != null)
				{
					try
					{
						eventDelegate.Execute();
						goto IL_4B;
					}
					catch (Exception ex)
					{
						Exception innerException = ex.InnerException;
						goto IL_4B;
					}
IL_2A:
					if (list[i] != eventDelegate)
					{
						continue;
					}
					if (eventDelegate.oneShot)
					{
						list.RemoveAt(i);
						continue;
					}
					goto IL_45;
IL_4B:
					if (i >= list.Count)
					{
						break;
					}
					goto IL_2A;
				}
IL_45:;
			}
		}
	}

	// Token: 0x0600094D RID: 2381 RVA: 0x0011F1D4 File Offset: 0x0011D3D4
	public static bool IsValid(List<EventDelegate> list)
	{
		if (list != null)
		{
			int i = 0;
			int count = list.Count;
			while (i < count)
			{
				EventDelegate eventDelegate = list[i];
				if (eventDelegate != null && eventDelegate.isValid)
				{
					return true;
				}
				i++;
			}
		}
		return false;
	}

	// Token: 0x0600094E RID: 2382 RVA: 0x0011F210 File Offset: 0x0011D410
	public static EventDelegate Set(List<EventDelegate> list, EventDelegate.Callback callback)
	{
		if (list != null)
		{
			EventDelegate eventDelegate = new EventDelegate(callback);
			list.Clear();
			list.Add(eventDelegate);
			return eventDelegate;
		}
		return null;
	}

	// Token: 0x0600094F RID: 2383 RVA: 0x00009000 File Offset: 0x00007200
	public static void Set(List<EventDelegate> list, EventDelegate del)
	{
		if (list != null)
		{
			list.Clear();
			list.Add(del);
		}
	}

	// Token: 0x06000950 RID: 2384 RVA: 0x00009012 File Offset: 0x00007212
	public static EventDelegate Add(List<EventDelegate> list, EventDelegate.Callback callback)
	{
		return EventDelegate.Add(list, callback, false);
	}

	// Token: 0x06000951 RID: 2385 RVA: 0x0011F238 File Offset: 0x0011D438
	public static EventDelegate Add(List<EventDelegate> list, EventDelegate.Callback callback, bool oneShot)
	{
		if (list != null)
		{
			int i = 0;
			int count = list.Count;
			while (i < count)
			{
				EventDelegate eventDelegate = list[i];
				if (eventDelegate != null && eventDelegate.Equals(callback))
				{
					return eventDelegate;
				}
				i++;
			}
			EventDelegate eventDelegate2 = new EventDelegate(callback);
			eventDelegate2.oneShot = oneShot;
			list.Add(eventDelegate2);
			return eventDelegate2;
		}
		return null;
	}

	// Token: 0x06000952 RID: 2386 RVA: 0x0000901C File Offset: 0x0000721C
	public static void Add(List<EventDelegate> list, EventDelegate ev)
	{
		EventDelegate.Add(list, ev, ev.oneShot);
	}

	// Token: 0x06000953 RID: 2387 RVA: 0x0011F28C File Offset: 0x0011D48C
	public static void Add(List<EventDelegate> list, EventDelegate ev, bool oneShot)
	{
		if (!ev.mRawDelegate && !(ev.target == null) && !string.IsNullOrEmpty(ev.methodName))
		{
			if (list != null)
			{
				int i = 0;
				int count = list.Count;
				while (i < count)
				{
					EventDelegate eventDelegate = list[i];
					if (eventDelegate != null && eventDelegate.Equals(ev))
					{
						return;
					}
					i++;
				}
				EventDelegate eventDelegate2 = new EventDelegate(ev.target, ev.methodName);
				eventDelegate2.oneShot = oneShot;
				if (ev.mParameters != null && ev.mParameters.Length != 0)
				{
					eventDelegate2.mParameters = new EventDelegate.Parameter[ev.mParameters.Length];
					for (int j = 0; j < ev.mParameters.Length; j++)
					{
						eventDelegate2.mParameters[j] = ev.mParameters[j];
					}
				}
				list.Add(eventDelegate2);
			}
			return;
		}
		EventDelegate.Add(list, ev.mCachedCallback, oneShot);
	}

	// Token: 0x06000954 RID: 2388 RVA: 0x0011F374 File Offset: 0x0011D574
	public static bool Remove(List<EventDelegate> list, EventDelegate.Callback callback)
	{
		if (list != null)
		{
			int i = 0;
			int count = list.Count;
			while (i < count)
			{
				EventDelegate eventDelegate = list[i];
				if (eventDelegate != null && eventDelegate.Equals(callback))
				{
					list.RemoveAt(i);
					return true;
				}
				i++;
			}
		}
		return false;
	}

	// Token: 0x06000955 RID: 2389 RVA: 0x0011F374 File Offset: 0x0011D574
	public static bool Remove(List<EventDelegate> list, EventDelegate ev)
	{
		if (list != null)
		{
			int i = 0;
			int count = list.Count;
			while (i < count)
			{
				EventDelegate eventDelegate = list[i];
				if (eventDelegate != null && eventDelegate.Equals(ev))
				{
					list.RemoveAt(i);
					return true;
				}
				i++;
			}
		}
		return false;
	}

	// Token: 0x040006CE RID: 1742
	[SerializeField]
	private MonoBehaviour mTarget;

	// Token: 0x040006CF RID: 1743
	[SerializeField]
	private string mMethodName;

	// Token: 0x040006D0 RID: 1744
	[SerializeField]
	private EventDelegate.Parameter[] mParameters;

	// Token: 0x040006D1 RID: 1745
	public bool oneShot;

	// Token: 0x040006D2 RID: 1746
	[NonSerialized]
	private EventDelegate.Callback mCachedCallback;

	// Token: 0x040006D3 RID: 1747
	[NonSerialized]
	private bool mRawDelegate;

	// Token: 0x040006D4 RID: 1748
	[NonSerialized]
	private bool mCached;

	// Token: 0x040006D5 RID: 1749
	[NonSerialized]
	private MethodInfo mMethod;

	// Token: 0x040006D6 RID: 1750
	[NonSerialized]
	private ParameterInfo[] mParameterInfos;

	// Token: 0x040006D7 RID: 1751
	[NonSerialized]
	private object[] mArgs;

	// Token: 0x040006D8 RID: 1752
	private static int s_Hash = "EventDelegate".GetHashCode();

	// Token: 0x02000163 RID: 355
	[Serializable]
	public class Parameter
	{
		// Token: 0x06000957 RID: 2391 RVA: 0x0000903C File Offset: 0x0000723C
		public Parameter()
		{
		}

		// Token: 0x06000958 RID: 2392 RVA: 0x00009054 File Offset: 0x00007254
		public Parameter(UnityEngine.Object obj, string field)
		{
			obj = obj;
			field = field;
		}

		// Token: 0x06000959 RID: 2393 RVA: 0x0000907A File Offset: 0x0000727A
		public Parameter(object val)
		{
			mValue = val;
		}

		// Token: 0x17000104 RID: 260
		// (get) Token: 0x0600095A RID: 2394 RVA: 0x0011F3B8 File Offset: 0x0011D5B8
		// (set) Token: 0x0600095B RID: 2395 RVA: 0x00009099 File Offset: 0x00007299
		public object value
		{
			get
			{
				if (mValue != null)
				{
					return mValue;
				}
				if (!cached)
				{
					cached = true;
					fieldInfo = null;
					propInfo = null;
					if (obj != null && !string.IsNullOrEmpty(field))
					{
						Type type = obj.GetType();
						propInfo = type.GetProperty(field);
						if (propInfo == null)
						{
							fieldInfo = type.GetField(field);
						}
					}
				}
				if (propInfo != null)
				{
					return propInfo.GetValue(obj, null);
				}
				if (fieldInfo != null)
				{
					return fieldInfo.GetValue(obj);
				}
				if (obj != null)
				{
					return obj;
				}
				if (expectedType != null && expectedType.IsValueType)
				{
					return null;
				}
				return Convert.ChangeType(null, expectedType);
			}
			set
			{
				mValue = value;
			}
		}

		// Token: 0x17000105 RID: 261
		// (get) Token: 0x0600095C RID: 2396 RVA: 0x000090A2 File Offset: 0x000072A2
		public Type type
		{
			get
			{
				if (mValue != null)
				{
					return mValue.GetType();
				}
				if (obj == null)
				{
					return typeof(void);
				}
				return obj.GetType();
			}
		}

		// Token: 0x040006D9 RID: 1753
		public UnityEngine.Object obj;

		// Token: 0x040006DA RID: 1754
		public string field;

		// Token: 0x040006DB RID: 1755
		[NonSerialized]
		private object mValue;

		// Token: 0x040006DC RID: 1756
		[NonSerialized]
		public Type expectedType = typeof(void);

		// Token: 0x040006DD RID: 1757
		[NonSerialized]
		public bool cached;

		// Token: 0x040006DE RID: 1758
		[NonSerialized]
		public PropertyInfo propInfo;

		// Token: 0x040006DF RID: 1759
		[NonSerialized]
		public FieldInfo fieldInfo;
	}

	// Token: 0x02000164 RID: 356
	// (Invoke) Token: 0x0600095E RID: 2398
	public delegate void Callback();
}
