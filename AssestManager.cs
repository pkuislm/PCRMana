using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class AssestManager : Singleton<AssestManager>
{
    // Start is called before the first frame update
    string _root;
    Dictionary<string, AssetBundle> assestCache;

    void Start()
    {
        _root = "E:/PCRDump/files/";
        if(assestCache == null)
        {
            assestCache = new Dictionary<string, AssetBundle>();
        }
    }
    void Init(string ResRoot)
    {
        _root = ResRoot;
    }

    string GetBundleSpecialPath(int type)
    {
        switch(type)
        {
            case 1:
                return "a";
            case 2:
                return "m";
            case 3:
                return "b";
            case 4:
                return "s";
            case 5:
                return "v";
            case 6:
                return "manifest";
            default:
                return "";
        }
    }
    public Texture2D LoadStoryThumbById(int id)
    {
        return LoadAssestFromBundle<Texture2D>(1, string.Format("icon_thumb_story_{0}.unity3d", id), string.Format("thumb_story_{0}.png", id));
    }
    public Texture2D LoadBGById(int id)
    {
        return LoadAssestFromBundle<Texture2D>(1, string.Format("bg_bg_{0:D6}.unity3d", id), string.Format("bg_{0:D6}", id));
    }
    public TextAsset LoadStoryDataById(int id)
    {
        return LoadAssestFromBundle<TextAsset>(1, string.Format("storydata_{0}.unity3d", id), string.Format("storydata_{0}", id));
    }

    public T LoadAssestFromBundle<T>(int bundleType, string bundleName, string assestName) where T : Object
    {
        if (!assestCache.TryGetValue(bundleName, out AssetBundle bund))
        {
            bund = AssetBundle.LoadFromFile(Path.Combine(_root, GetBundleSpecialPath(bundleType), bundleName));
            if (bund == null) return default;
            assestCache.Add(bundleName, bund);
        }
        return bund.LoadAsset<T>(assestName);
    }

}
