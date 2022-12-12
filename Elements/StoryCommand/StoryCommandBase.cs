// Decompiled with JetBrains decompiler
// Type: Elements.StoryCommandBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A7E03188-4A33-4E31-B2AA-6FF711CC1BCD
// Assembly location: C:\Users\ASUS\Documents\Tencent Files\1668911954\FileRecv\MobileFile\ksdumper-mod\princessconnectredive_11ED3000.dll

//using Cute;
using System;

namespace Elements
{
    public delegate bool TouchDelegate();
    public class StoryCommandBase
    {
        protected string name = "";
        protected string[] args;
        protected int index;
        protected Action<int> onComplete;
        protected const int CALC_BASE_FPS = 60;
        protected StoryManager storyManager;
        //protected TutorialStoryManager tutorialStoryManager;
        protected StorySoundManager StorySoundManager;

        public virtual void OnLoad()
        {
        }

        public void SetStoryManager()
        {
            storyManager = StoryManagerBase<StoryManager>.Instance;
            StorySoundManager = Singleton<StorySoundManager>.Instance;
        }

        public virtual void InitParam(string _name, string[] _args, int _index)
        {
            name = _name;
            args = _args;
            index = _index;
        }

        public void SetCallback(Action<int> _callback) => onComplete = _callback;

        public virtual void ExecCommand()
        {
            storyManager.SetTouchDelegate(new TouchDelegate(OnTouchDelegate));
            OnCompleteCommand();
        }

        public virtual bool OnTouchDelegate() => AdvDefine.INTERCEPT_TOUCH;

        protected virtual void OnCompleteCommand()
        {
            storyManager.RemoveTouchDelegate(new TouchDelegate(OnTouchDelegate));
            DumpLog();
            onComplete(index);
        }

        public virtual void DumpLog() => string.Join(", ", args);

        public bool IsSetCommandCompleteAction() => onComplete != null;

        protected int getArgInt(int _index, int _default = -1) => args.Length > _index ? int.Parse(args[_index]) : _default;

        protected virtual void SetCommandParam()
        {
        }
    }
}
