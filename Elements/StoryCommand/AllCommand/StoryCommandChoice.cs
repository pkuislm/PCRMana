// Decompiled with JetBrains decompiler
// Type: Elements.StoryCommandChoice
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A7E03188-4A33-4E31-B2AA-6FF711CC1BCD
// Assembly location: C:\Users\ASUS\Documents\Tencent Files\1668911954\FileRecv\MobileFile\ksdumper-mod\princessconnectredive_11ED3000.dll

namespace Elements
{
    public class StoryCommandChoice : StoryCommandBase
    {
        private string buttonText = "";
        private int tagNo;
        private int affectParam;
        private bool isAutoChoice;

        protected override void SetCommandParam()
        {
            base.SetCommandParam();
            buttonText = args[0];
            tagNo = int.Parse(args[1]);
            affectParam = 0;
            if (args.Length > 2)
            affectParam = int.Parse(args[2]);
            isAutoChoice = false;
            if (args.Length <= 3)
            return;
            isAutoChoice = args[3] == "true";
        }

        public override void ExecCommand()
        {
            SetCommandParam();
            storyManager.AddChoiceButton(buttonText, tagNo, affectParam, isAutoChoice);
            storyManager.SetTouchDelegate(new TouchDelegate(OnTouchDelegate));
        }

        public override bool OnTouchDelegate() => true;

        public enum eArgs
        {
            LABEL_TEXT,
            TAG_NO,
            AFFECT_PARAM,
            IS_AUTO_CHOICE,
            MAX,
        }
    }
}
