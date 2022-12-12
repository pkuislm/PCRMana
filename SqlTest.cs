using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sqlite3Plugin;
public class SqlTest : MonoBehaviour
{
    Sqlite3Proxy proxy;
    // Start is called before the first frame update
    void Start()
    {
        if(proxy == null)
        {
            proxy = new Sqlite3Proxy();
            if (!proxy.Open("F:\\master.mdb"))
            {
                Debug.LogWarning("Cannot open database");
            }
        }
    }

    public void BClick()
    {
        var a = proxy.Query("SELECT * FROM story_data WHERE story_data.disp_order = 1 AND story_data.story_type = 2");
        var b = a.Step();
        var c = a.GetText(3);
        a.Dispose();
        Debug.Log(b);
        Debug.Log(c);
    }
}
