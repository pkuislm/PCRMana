// Decompiled with JetBrains decompiler
// Type: Sqlite3Plugin.ADAKPPDHFFB
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A7E03188-4A33-4E31-B2AA-6FF711CC1BCD
// Assembly location: C:\Users\ASUS\Documents\Tencent Files\1668911954\FileRecv\MobileFile\ksdumper-mod\princessconnectredive_11ED3000.dll

using System;
using System.Runtime.InteropServices;

namespace Sqlite3Plugin
{
  public static class Sqlite3API
  {
    private const string LibraryName = "sqlite3";

    [DllImport(LibraryName)]
    public static extern int sqlite3_open(byte[] filename, out IntPtr ppDb);

    [DllImport(LibraryName)]
    public static extern int sqlite3_open_v2(
      byte[] filename,
      out IntPtr ppDb,
      int KLMHLFBJBCK,
      byte[] MJDHPFBDCJP);

    [DllImport(LibraryName)]
    public static extern int sqlite3_close(IntPtr CKMHMDPHJBB);

    [DllImport(LibraryName)]
    public static extern int sqlite3_exec(
      IntPtr CKMHMDPHJBB,
      byte[] COIANCOFONI,
      IntPtr IMBJJOEJBPO,
      IntPtr HKCAMONHFBE,
      out IntPtr HLNDLAOMGNM);

    [DllImport(LibraryName)]
    public static extern int sqlite3_prepare_v2(
      IntPtr CKMHMDPHJBB,
      byte[] COIANCOFONI,
      int DHCOCMDFJCK,
      out IntPtr MNMCJBKBFNE,
      IntPtr OJPJNLIBKHL);

    [DllImport(LibraryName)]
    public static extern int sqlite3_bind_text(
      IntPtr pStmt,
      int iCol,
      byte[] val,
      int val_len,
      IntPtr DCKHHMOKOLP);

    [DllImport(LibraryName)]
    public static extern int sqlite3_bind_int(IntPtr pStmt, int iCol, int val);

    [DllImport(LibraryName)]
    public static extern int sqlite3_bind_double(
      IntPtr pStmt,
      int iCol,
      double val);

    [DllImport(LibraryName)]
    public static extern int sqlite3_bind_null(IntPtr pStmt, int iCol);

    [DllImport(LibraryName)]
    public static extern int sqlite3_reset(IntPtr pStmt);

    [DllImport(LibraryName)]
    public static extern int sqlite3_step(IntPtr pStmt);

    [DllImport(LibraryName)]
    public static extern int sqlite3_finalize(IntPtr pStmt);

    [DllImport(LibraryName)]
    public static extern int sqlite3_column_int(IntPtr pStmt, int iCol);

    [DllImport(LibraryName)]
    public static extern double sqlite3_column_double(IntPtr pStmt, int iCol);

    [DllImport(LibraryName)]
    public static extern int sqlite3_column_bytes(IntPtr pStmt, int iCol);

    [DllImport(LibraryName)]
    public static extern IntPtr sqlite3_column_blob(IntPtr pStmt, int iCol);

    [DllImport(LibraryName)]
    public static extern IntPtr sqlite3_column_text(IntPtr pStmt, int iCol);

    [DllImport(LibraryName)]
    public static extern int sqlite3_column_type(IntPtr pStmt, int iCol);

    [DllImport(LibraryName)]
    public static extern int sqlite3_vfs_register(IntPtr pStmt, int HGPIFIEEKAI);

    [DllImport(LibraryName)]
    public static extern int sqlite3_vfs_unregister(IntPtr IOGFGIEJMIA);

    [DllImport(LibraryName)]
    public static extern IntPtr sqlite3_vfs_find(byte[] HGICADCIENN);
  }
}
