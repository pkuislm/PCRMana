// Decompiled with JetBrains decompiler
// Type: Elements.WaitComponent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A7E03188-4A33-4E31-B2AA-6FF711CC1BCD
// Assembly location: C:\Users\ASUS\Documents\Tencent Files\1668911954\FileRecv\MobileFile\ksdumper-mod\princessconnectredive_11ED3000.dll

using System;
using System.Collections;
using UnityEngine;

namespace Elements
{
    public delegate void WaitCompleteDelegate();
    public static class ExtensionMethods
    { 
        // Token: 0x0600E02B RID: 57387 RVA: 0x000890AE File Offset: 0x000872AE
        public static IEnumerator Timer(this MonoBehaviour obj, float time, Action onComplete)
        {
            return obj.Timer(time, 0f, onComplete);
        }

        // Token: 0x0600E02C RID: 57388 RVA: 0x00329AD4 File Offset: 0x00327CD4
        public static IEnumerator Timer(this MonoBehaviour obj, float time, float delay, Action onComplete)
        {
            IEnumerator enumerator = ExtensionMethods.timerCoroutine(obj, time, delay, onComplete);
            obj.StartCoroutine(enumerator);
            return enumerator;
        }
        private static IEnumerator timerCoroutine(MonoBehaviour obj, float time, float delay, Action onComplete)
        {
            if (delay > 0f)
            {
                yield return new WaitForSeconds(delay);
            }
            yield return new WaitForSeconds(time);
            onComplete();
            yield break;
        }
        
    }
    

    public class WaitComponent : MonoBehaviour
    {
        public int TimeCount;
        public int MaxTimeCount;
        public WaitCompleteDelegate WaitComplete;

        private void Start()
        {
            Debug.Log(string.Format("Wait: Set for {0} ms", MaxTimeCount * 10));
            LeanTweenExt.LeanDelayedCall(gameObject, (float)MaxTimeCount / 40.0f, ()=> {
                Debug.Log("Wait: Complete");
                WaitComplete();
            });
        }
    }
}
