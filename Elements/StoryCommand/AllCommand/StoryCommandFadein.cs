// Decompiled with JetBrains decompiler
// Type: Elements.StoryCommandFadein
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A7E03188-4A33-4E31-B2AA-6FF711CC1BCD
// Assembly location: C:\Users\ASUS\Documents\Tencent Files\1668911954\FileRecv\MobileFile\ksdumper-mod\princessconnectredive_11ED3000.dll

using System.Collections.Generic;
using UnityEngine;

namespace Elements
{
    public class StoryCommandFadein : StoryCommandBase
    {
        private List<GameObject> charaObjects;
        private int charaCount;
        private float fadeTime;
        private int maxFadeCharaCount;
        private int fadeEndCharaCount;
        private string[] targets;

        public override void OnLoad()
        {
/*            charaObjects = new List<GameObject>();
            StoryFindHelper instance = SingletonMonoBehaviour<StoryFindHelper>.Instance;
            charaObjects.Add(instance.GetStoryCharacter(0));
            charaObjects.Add(instance.GetStoryCharacter(1));
            charaObjects.Add(instance.GetStoryCharacter(2));
            charaObjects.Add(instance.GetStoryCharacter(3));
            charaObjects.Add(instance.GetStoryCharacter(4));
            charaCount = charaObjects.Count;*/
            base.OnLoad();
        }

        protected override void SetCommandParam()
        {
            targets = args[0].Split(':');
            maxFadeCharaCount = targets.Length;
            fadeEndCharaCount = 0;
            if (args.Length >= 2)
            fadeTime = float.Parse(args[1]) / 60f;
            else
            fadeTime = 0.3f;
        }

        public override void ExecCommand()
        {
            storyManager.SetTouchDelegate(new TouchDelegate(OnTouchDelegate));
            fadeTime /= storyManager.StoryScene.CommandTimeScale;
            SetCommandParam();
            /*            for (int index1 = 0; index1 < charaCount; ++index1)
                        {
                            string name = ((Object) charaObjects[index1]).name;
                            int length = targets.Length;
                            for (int index2 = 0; index2 < length; ++index2)
                            {
                                if (name == targets[index2])
                                {
                                    StoryCharacter component = charaObjects[index1].GetComponent<StoryCharacter>();
                                    component.SaveFace();
                                    component.SetVisible(false);
                                    toFadein(component);
                                }
                            }
                        }*/
            Debug.Log("StoryCommandCharacterFadein: " + args[0]);
            OnCompleteCommand();
        }

        /*private void toFadein(StoryCharacter _storyCharacter) => _storyCharacter.FadeIn(fadeTime, (System.Action) (() =>
        {
            _storyCharacter.LoadFace();
            AdvUtility.RandomStartEyeAnimationWaitTime(_storyCharacter, storyManager.StoryScene);
            OnCompleteCommand();
        }));

        protected override void OnCompleteCommand()
        {
            ++fadeEndCharaCount;
            if (fadeEndCharaCount < maxFadeCharaCount)
            return;
            GameObject gameObject = storyManager.StoryScene.gameObject;
            WaitComponent waitComponent = gameObject.GetComponent<WaitComponent>();
            if (waitComponent == null)
                waitComponent = gameObject.AddComponent<WaitComponent>();
            waitComponent.TimeCount = 0;
            waitComponent.MaxTimeCount = 1;
            waitComponent.WaitComplete = new WaitCompleteDelegate(OnCompleteCommand);
        }*/

        public override bool OnTouchDelegate() => true;

        public enum eArgs
        {
            CHARACTER_ID,
            FADE_TIME,
            MAX,
        }
    }
}
