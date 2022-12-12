// Decompiled with JetBrains decompiler
// Type: Elements.StorySkipDialogParams
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A7E03188-4A33-4E31-B2AA-6FF711CC1BCD
// Assembly location: C:\Users\ASUS\Documents\Tencent Files\1668911954\FileRecv\MobileFile\ksdumper-mod\princessconnectredive_11ED3000.dll

using System.Collections.Generic;

namespace Elements
{
    public class StorySkipDialogParams
    {
        private List<string> titleLabelText = new List<string>();
        private List<string> synopsisLabelText = new List<string>();

        public string TitleLabelText
        {
            set => titleLabelText.Add(value.ReplaceNewLine());
        }

        public string SynopsisLabelText
        {
            set => synopsisLabelText.Add(value.ReplaceNewLine());
        }

        public string GetTitleLabelText(bool _isInsertStory) => titleLabelText[_isInsertStory ? 1 : 0];

        public string GetSynopsisLabelText(bool _isInsertStory) => synopsisLabelText[_isInsertStory ? 1 : 0];

        private enum eStoryType
        {
            NORMAL,
            INSERT,
        }
    }
}
