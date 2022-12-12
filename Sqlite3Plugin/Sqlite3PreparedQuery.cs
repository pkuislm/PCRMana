// Decompiled with JetBrains decompiler
// Type: Sqlite3Plugin.NAOCHNBMGCB
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A7E03188-4A33-4E31-B2AA-6FF711CC1BCD
// Assembly location: C:\Users\ASUS\Documents\Tencent Files\1668911954\FileRecv\MobileFile\ksdumper-mod\princessconnectredive_11ED3000.dll

using System;
using System.Text;

namespace Sqlite3Plugin
{
  public class Sqlite3PreparedQuery : Sqlite3Query
  {
    public Sqlite3PreparedQuery(Sqlite3Proxy proxy, string sql)
      : base(proxy, sql)
    {
    }

    public bool BindText(int iCol, string val)
    {
      byte[] bytes = Encoding.UTF8.GetBytes(val);
      int state = Sqlite3API.sqlite3_bind_text(_stmt, iCol, bytes, bytes.Length, IntPtr.Zero);
      if (state != 0)
        Sqlite3State.CheckCorruption(state);
      return state == 0;
    }

    public bool BindInt(int iCol, int val)
    {
      int state = Sqlite3API.sqlite3_bind_int(_stmt, iCol, val);
      if (state != 0)
        Sqlite3State.CheckCorruption(state);
      return state == 0;
    }

    public bool BindDouble(int iCol, double val)
    {
      int state = Sqlite3API.sqlite3_bind_double(_stmt, iCol, val);
      if (state != 0)
        Sqlite3State.CheckCorruption(state);
      return state == 0;
    }

    public bool Reset()
    {
      int state = Sqlite3API.sqlite3_reset(_stmt);
      if (state != 0)
        Sqlite3State.CheckCorruption(state);
      return state == 0;
    }
  }
}
