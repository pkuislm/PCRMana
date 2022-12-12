// Decompiled with JetBrains decompiler
// Type: Elements.StoryCommandPrint
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A7E03188-4A33-4E31-B2AA-6FF711CC1BCD
// Assembly location: C:\Users\ASUS\Documents\Tencent Files\1668911954\FileRecv\MobileFile\ksdumper-mod\princessconnectredive_11ED3000.dll

using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using TMPro;

namespace Elements
{
    public class StoryCommandPrint : StoryCommandBase
    {
        private TextMeshProUGUI textLabel;
        private TextMeshProUGUI nameLabel;
        private Regex deleteDoubleQuotation = new Regex("^\"(.*)\"$");
        private Regex userNameImplement = new Regex("\\{0\\}");
        private int typewriteSpeed = 13;
        protected bool isDouble;
        private List<string> checkCommandList;
        private const string STORY_TEXT_COLOR_CODE = "[3C404EFF]";
        private string newNameStr = "";
        private string newTextStr = "";
        private bool isBetweenCommand;

        public string NameText { get; private set; }

        public string Text { get; private set; }

        public override void OnLoad()
        {
            checkCommandList = new List<string>();
            checkCommandList.Add("touch");
            checkCommandList.Add("tag");
            checkCommandList.Add("background");
            checkCommandList.Add("chara");
            base.OnLoad();
        }

        protected override void SetCommandParam()
        {
            string userName = "Pkuism";//(string) Singleton<UserData>.Instance.UserInfo.UserName;
            newNameStr = userNameImplement.Replace(deleteDoubleQuotation.Replace(args[0], "$1"), userName);
            newTextStr = "<color=#3C404EFF>" + userNameImplement.Replace(deleteDoubleQuotation.Replace(args[1], "$1"), userName).ReplaceNewLine() + "</color>";
        }

        public override void ExecCommand()
        {
            isBetweenCommand = false;
            textLabel = storyManager.StoryScene.TextLabel;
            nameLabel = storyManager.StoryScene.NameLabel;
            //storyManager.StoryScene.SetDoubleLabelVisible(isDouble);
            isBetweenCommand = storyManager.CheckPrintBetweenCommand(index, checkCommandList);
            storyManager.SetTouchDelegate(new TouchDelegate(OnTouchDelegate));
            SetCommandParam();
            typewriteSpeed = 13 * storyManager.StoryScene.CommandTimeScale;
            setPrintText(new EventDelegate.Callback(OnCompleteTypewrite));
        }

        public void OnCompleteTypewrite()
        {
            EventDelegate.Remove(textLabel.gameObject.GetComponent<TypewriterEffect>().onFinished, new EventDelegate.Callback(OnCompleteTypewrite));
            if (needWait())
            {
                GameObject gameObject = storyManager.StoryScene.gameObject;
                storyManager.SetArrowIconVisible(true);
                WaitComponent waitComponent = gameObject.GetComponent<WaitComponent>();
                if (waitComponent == null)
                    waitComponent = gameObject.AddComponent<WaitComponent>();
                waitComponent.TimeCount = 0;
                waitComponent.MaxTimeCount = 10 / storyManager.StoryScene.CommandTimeScale;
                waitComponent.WaitComplete = new WaitCompleteDelegate(OnCompleteCommand);
            }
            else
                OnCompleteCommand();
        }

        private bool needWait()
        {
            if (storyManager.StoryScene.IsAutoPlay)
            {
                string currentCommandName = storyManager.GetCurrentCommandName();
                string nextCommandName = storyManager.GetNextCommandName();
                if (currentCommandName == "touch" || currentCommandName == "log" || nextCommandName == "touch" || nextCommandName == "log")
                    return true;
            }
            return false;
        }

        public bool IsTypeWriting()
        {
            if (textLabel == null)
                return false;
            TypewriterEffect component = textLabel.gameObject.GetComponent<TypewriterEffect>();
            return !(component == null) && component.isActive;
        }

        public override bool OnTouchDelegate()
        {
            FinishTypeWrite();
            return true;
        }

        public void FinishTypeWrite(bool _isCompleteCallback = true)
        {
            TypewriterEffect component = textLabel.gameObject.GetComponent<TypewriterEffect>();
            if (!_isCompleteCallback)
            {
                EventDelegate.Remove(component.onFinished, new EventDelegate.Callback(OnCompleteTypewrite));
                storyManager.RemoveTouchDelegate(new TouchDelegate(OnTouchDelegate));
            }
            component.Finish();
        }

        private void setPrintText(EventDelegate.Callback _typewriteFinishAction)
        {
            string text = nameLabel.text;
            Debug.Log("Print: " + newNameStr + ": " + newTextStr);
            int offset = 0;
            TypewriterEffect typewriterEffect = textLabel.gameObject.GetComponent<TypewriterEffect>();
            if (typewriterEffect == null)
            {
                typewriterEffect = textLabel.gameObject.AddComponent<TypewriterEffect>();
                typewriterEffect.charsPerSecond = typewriteSpeed;
            }
            else
            {
                EventDelegate.Remove(typewriterEffect.onFinished, _typewriteFinishAction);
                typewriterEffect.Finish();
            }

            if (!isBetweenCommand && text == newNameStr)
            {
                offset = textLabel.textInfo.characterCount;
                newTextStr = textLabel.text + newTextStr;
            }
            nameLabel.SetText(newNameStr);
            textLabel.SetText(newTextStr);
            NameText = newNameStr;
            Text = newTextStr;
            typewriterEffect.ResetToOffset(offset);
            if (textLabel.maxVisibleCharacters > textLabel.textInfo.characterCount)
                _typewriteFinishAction();
            else
                EventDelegate.Add(typewriterEffect.onFinished, _typewriteFinishAction);
        }

        public static string GetName(List<string> _args) => _args[0];

        public static string GetMainText(List<string> _args) => _args[1];

        private enum eArgs
        {
            NAME_TEXT,
            MAIN_TEXT,
            MAX,
        }
    }
}
