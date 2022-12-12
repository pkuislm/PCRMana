// Decompiled with JetBrains decompiler
// Type: Elements.StoryCommandBackgroundBlur
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A7E03188-4A33-4E31-B2AA-6FF711CC1BCD
// Assembly location: C:\Users\ASUS\Documents\Tencent Files\1668911954\FileRecv\MobileFile\ksdumper-mod\princessconnectredive_11ED3000.dll

using System.Collections;
using UnityEngine;

namespace Elements
{
    public class StoryCommandBackgroundBlur : StoryCommandBase
    {
        private bool isBlurEnable;
        private float blurDuration;
        private float blurSize;
        //private BlurOptimized bgBlur;
        private IEnumerator blurCoroutine;

/*        public override void OnLoad()
        {
            //bgBlur = SingletonMonoBehaviour<StoryFindHelper>.Instance.BgCameraBlur;
            base.OnLoad();
        }*/

        protected override void SetCommandParam()
        {
            isBlurEnable = int.Parse(args[0]) == 1;
            int length = args.Length;
            blurDuration = 0.0f;
            if (length >= 2)
            blurDuration = float.Parse(args[1]);
            blurSize = isBlurEnable ? 1f : 0.0f;
            if (length < 3)
            return;
            blurSize = float.Parse(args[2]);
            if (blurSize <= 3.0)
            return;
            blurSize = 3f;
        }

        public override void ExecCommand()
        {
            if (blurCoroutine != null)
            {
            storyManager.StoryScene.StopCoroutine(blurCoroutine);
            blurCoroutine = null;
            }
            SetCommandParam();
            Debug.Log("StoryCommandBackgroundBlur");
            /*            float _duration = blurDuration / storyManager.StoryScene.CommandTimeScale;
                        if (isBlurEnable)
                        {
                        ((Behaviour) bgBlur).enabled = true;
                        blurCoroutine = FadeUtil.Fade(bgBlur.blurSize, blurSize, _duration, (System.Action<float>) (_newBlurSize => bgBlur.blurSize = _newBlurSize), (System.Action) null);
                        }
                        else
                        blurCoroutine = FadeUtil.Fade(bgBlur.blurSize, blurSize, _duration, (System.Action<float>) (_newBlurSize => bgBlur.blurSize = _newBlurSize), (System.Action) (() => ((Behaviour) bgBlur).enabled = false));
                        storyManager.StoryScene.StartCoroutine(blurCoroutine);*/
            base.ExecCommand();
        }

        private enum eArgs
        {
            BLUR_ENABLE,
            PLAY_TIME,
            BLUR_SIZE,
            MAX,
        }
    }
}
