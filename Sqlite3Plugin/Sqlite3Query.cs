// Decompiled with JetBrains decompiler
// Type: Sqlite3Plugin.ODBKLOJPCHG
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A7E03188-4A33-4E31-B2AA-6FF711CC1BCD
// Assembly location: C:\Users\ASUS\Documents\Tencent Files\1668911954\FileRecv\MobileFile\ksdumper-mod\princessconnectredive_11ED3000.dll

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Sqlite3Plugin
{
  public class Sqlite3Query : IDisposable
  {
    protected Sqlite3Proxy _proxy;
    protected IntPtr _stmt = IntPtr.Zero;

    public Sqlite3Query(Sqlite3Proxy proxy, string sql) => _Setup(proxy, sql);

    protected void _Setup(Sqlite3Proxy proxy, string sql)
    {
      _proxy = proxy;
      byte[] bytes = Encoding.UTF8.GetBytes(sql);
      IntPtr stmt;
      int state = Sqlite3API.sqlite3_prepare_v2(proxy.CPJHOACKHFI, bytes, bytes.Length, out stmt, IntPtr.Zero);
      if (state != 0)
      {
        Sqlite3State.CheckCorruption(state);
        throw new Exception(string.Format("sqlite3_prepare_v2 failed(code {0}) with sql: {1}", state, sql));
      }
      _stmt = stmt;
    }

    public virtual void Dispose()
    {
      if (!(_stmt != IntPtr.Zero))
        return;
      int state = Sqlite3API.sqlite3_finalize(_stmt);
      _stmt = IntPtr.Zero;
      if (state == 0)
        return;
      Sqlite3State.CheckCorruption(state);
    }

    public bool Step()
    {
      int state = Sqlite3API.sqlite3_step(_stmt);
      int num = state == 100 ? 1 : 0;
      if (num != 0)
        return num != 0;
      Sqlite3State.CheckCorruption(state);
      return num != 0;
    }

    public int GetInt(int iCol) => Sqlite3API.sqlite3_column_int(_stmt, iCol);

    public double GetDouble(int iCol) => Sqlite3API.sqlite3_column_double(_stmt, iCol);

    public string GetText(int iCol) => Marshal.PtrToStringAnsi(Sqlite3API.sqlite3_column_text(_stmt, iCol));

    public byte[] GetBlob(int iCol)
    {
      int length1 = Sqlite3API.sqlite3_column_bytes(_stmt, iCol);
      if (length1 == 0)
        return null;
      IntPtr source = Sqlite3API.sqlite3_column_blob(_stmt, iCol);
      byte[] blob = new byte[length1];
      byte[] destination = blob;
      int length2 = length1;
      Marshal.Copy(source, destination, 0, length2);
      return blob;
    }

    public bool IsNull(int iCol) => Sqlite3API.sqlite3_column_type(_stmt, iCol) == 5;
  }
}
