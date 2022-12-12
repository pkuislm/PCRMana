using System.Collections.Generic;

namespace Elements
{
  public struct CommandStruct
  {
    public string Name;
    public List<string> Args;
    public CommandCategory Category;
    public CommandNumber Number;
  }
}
