// Decompiled with JetBrains decompiler
// Type: Sqlite3Plugin.AFBIOHMLCFK
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A7E03188-4A33-4E31-B2AA-6FF711CC1BCD
// Assembly location: C:\Users\ASUS\Documents\Tencent Files\1668911954\FileRecv\MobileFile\ksdumper-mod\princessconnectredive_11ED3000.dll

using System;

namespace Sqlite3Plugin
{
  public class Sqlite3Exception : Exception
  {
    public Sqlite3Exception(int errcode)
      : base(string.Format("Database is corrupted: code {0}", errcode))
    {
    }
  }
}
