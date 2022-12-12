// Decompiled with JetBrains decompiler
// Type: Elements.StoryDataCommandConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A7E03188-4A33-4E31-B2AA-6FF711CC1BCD
// Assembly location: C:\Users\ASUS\Documents\Tencent Files\1668911954\FileRecv\MobileFile\ksdumper-mod\princessconnectredive_11ED3000.dll

namespace Elements
{
  public struct StoryDataCommandConfig
  {
    public CommandNumber Number;
    public string Name;
    public string ClassName;
    public CommandCategory Category;
    public int MinArgCount;
    public int MaxArgCount;

    public StoryDataCommandConfig(
      CommandNumber number,
      string commandName,
      string className,
      CommandCategory category,
      int minArgCount,
      int maxArgCount)
    {
      Number = number;
      Name = commandName;
      ClassName = className;
      Category = category;
      MinArgCount = minArgCount;
      MaxArgCount = maxArgCount;
    }
  }
}
