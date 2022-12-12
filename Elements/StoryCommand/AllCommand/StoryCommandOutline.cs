// Decompiled with JetBrains decompiler
// Type: Elements.StoryCommandOutline
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A7E03188-4A33-4E31-B2AA-6FF711CC1BCD
// Assembly location: C:\Users\ASUS\Documents\Tencent Files\1668911954\FileRecv\MobileFile\ksdumper-mod\princessconnectredive_11ED3000.dll

using System.Text.RegularExpressions;
using UnityEngine;

namespace Elements
{
    public class StoryCommandOutline : StoryCommandBase
    {
        private StorySkipDialogParams skipParam;
        private Regex deleteDoubleQuotation = new Regex("^\"(.*)\"$");
        private Regex userNameImplement = new Regex("\\{0\\}");

        protected override void SetCommandParam()
        {
            string userName = "Pkuism";//Singleton<UserData>.Instance.UserInfo.UserName;
            skipParam.SynopsisLabelText = userNameImplement.Replace(deleteDoubleQuotation.Replace(args[0], "$1"), userName).ReplaceNewLine();
        }

        public override void ExecCommand()
        {
            skipParam = storyManager.StorySkipDialogParams;
            Debug.Log("StoryCommandOutline: " + args[0]);
            SetCommandParam();
            base.ExecCommand();
        }


        private enum eArgs
        {
            OUTLINE,
            MAX,
        }
    }
}
