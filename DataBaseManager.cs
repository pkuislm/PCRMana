using System.Collections;
using UnityEngine;
using Sqlite3Plugin;

public class DataBaseManager : Singleton<DataBaseManager>
{
    Sqlite3Proxy proxy;
    // Use this for initialization
    void Start()
    {
        if (proxy == null)
        {
            proxy = new Sqlite3Proxy();
            if (!proxy.Open("F:\\master.mdb"))
            {
                Debug.LogWarning("Cannot open database");
            }
            else
            {
                Debug.Log("Database Opened Successfully.");
            }
        }
    }

    public Sqlite3Query CreateQuery(string sql) => proxy.Query(sql);
}
