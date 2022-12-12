// Decompiled with JetBrains decompiler
// Type: Elements.StoryLogInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A7E03188-4A33-4E31-B2AA-6FF711CC1BCD
// Assembly location: C:\Users\ASUS\Documents\Tencent Files\1668911954\FileRecv\MobileFile\ksdumper-mod\princessconnectredive_11ED3000.dll

namespace Elements
{
    public struct StoryLogInfo
    {
        public int CommandIndex;
        public string CharaID;
        public string Name;
        public string Text;
        public string PlayVoiceName;
        public float VoEffectValue;

        public void SetStoryLogInfo(
            int _commandIndex,
            string _charaID,
            string _name,
            string _text,
            string _playVoiceName,
            float _voEffectValue)
        {
            CommandIndex = _commandIndex;
            CharaID = _charaID;
            Name = _name;
            Text = _text;
            PlayVoiceName = _playVoiceName;
            VoEffectValue = _voEffectValue;
        }
    }
}
