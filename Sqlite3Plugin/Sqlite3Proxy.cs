// Decompiled with JetBrains decompiler
// Type: Sqlite3Plugin.IOOJBIAKBHA
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A7E03188-4A33-4E31-B2AA-6FF711CC1BCD
// Assembly location: C:\Users\ASUS\Documents\Tencent Files\1668911954\FileRecv\MobileFile\ksdumper-mod\princessconnectredive_11ED3000.dll

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Sqlite3Plugin
{
  public class Sqlite3Proxy : IDisposable
  {
    public IntPtr CPJHOACKHFI { get; private set; }

    public string dbpath { get; private set; }

    ~Sqlite3Proxy() => CloseDB();

    public Sqlite3Proxy()
    {
      dbpath = null;
      CPJHOACKHFI = IntPtr.Zero;
    }

    public bool Open(string path, string vfs = null)
    {
      dbpath = path;
      IntPtr zero = IntPtr.Zero;
      byte[] bytes = Encoding.UTF8.GetBytes(path + "\0");
      byte[] numArray = null;
      if (!string.IsNullOrEmpty(vfs))
        numArray = Encoding.UTF8.GetBytes(vfs + "\0");
      ref IntPtr local = ref zero;
      int num1 = Sqlite3API.sqlite3_open_v2(bytes, out local, 1, numArray);
      CPJHOACKHFI = zero;
      int num2 = num1 == 0 ? 1 : 0;
      if (num2 == 0)
        return num2 != 0;
      Exec("pragma journal_mode=OFF");
      Exec("pragma synchronous=0");
      Exec("pragma locking_mode=EXCLUSIVE");
      return num2 != 0;
    }

    public bool OpenWritable(string OBODHBGPMEL)
    {
      dbpath = OBODHBGPMEL;
      IntPtr MMGDKAGMKBN = IntPtr.Zero;
      bool flag;
      try
      {
        int num = Sqlite3API.sqlite3_open(Encoding.UTF8.GetBytes(OBODHBGPMEL + "\0"), out MMGDKAGMKBN);
        CPJHOACKHFI = MMGDKAGMKBN;
        flag = num == 0;
        if (flag)
        {
          Exec("pragma journal_mode=MEMORY");
          Exec("pragma synchronous=1");
          Exec("pragma locking_mode=EXCLUSIVE");
        }
      }
      catch (Exception ex)
      {
        if (MMGDKAGMKBN != IntPtr.Zero)
        {
          Sqlite3API.sqlite3_close(MMGDKAGMKBN);
          CPJHOACKHFI = IntPtr.Zero;
        }
        throw ex;
      }
      return flag;
    }

    public bool Begin() => Exec("BEGIN;");

    public bool Commit() => Exec("COMMIT;");

    public bool Rollback() => Exec("ROLLBACK;");

    public bool Vacuum() => Exec("VACUUM;");

    public virtual void Dispose() => CloseDB();

    protected virtual void Dispose(bool FDFGPOKGKFO) => CloseDB();

    private void Terminate() => CloseDB();

    public virtual void CloseDB()
    {
      if (!(this.CPJHOACKHFI != IntPtr.Zero))
        return;
      Sqlite3API.sqlite3_close(this.CPJHOACKHFI);
      this.CPJHOACKHFI = IntPtr.Zero;
    }

    public bool Exec(string sql)
    {
      IntPtr err;
      int state = Sqlite3API.sqlite3_exec(CPJHOACKHFI, Encoding.UTF8.GetBytes(sql + "\0"), IntPtr.Zero, IntPtr.Zero, out err);
      if (state != 0)
      {
        string errmsg = err == IntPtr.Zero ? "" : Marshal.PtrToStringAnsi(err);
        Sqlite3State.CheckCorruption(state, errmsg);
      }
      return state == 0;
    }

    public Sqlite3Query Query(string sql) => new Sqlite3Query(this, sql);

    public Sqlite3PreparedQuery PreparedQuery(string sql) => new Sqlite3PreparedQuery(this, sql);
  }
}
