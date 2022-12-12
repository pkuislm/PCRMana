using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StoryPlateController : MonoBehaviour
{
    [SerializeField]
    GameObject view;

    [SerializeField] 
    GameObject PlatePrefab;
    [SerializeField] 
    GameObject EndOfListPrefab;
    

    DataBaseManager dbman;
    AssestManager asman;
    SceneLoader scman;

    List<GameObject> Plates;

    // Use this for initialization
    void Awake()
    {
        dbman = Singleton<DataBaseManager>.Instance;
        asman = Singleton<AssestManager>.Instance;
        scman = Singleton<SceneLoader>.Instance;

        if(Plates == null)
        {
            Plates = new List<GameObject>();
            DontDestroyOnLoad(view);
        }
    }

    public void StartSotryByStoryId(int _storyId)
    {
        //Init StoryManager, Set the StoryId
        //swap the scene
        StoryManagerBase<Elements.StoryManager>.CreateInstance().SetStoryId(_storyId);
        Singleton<PageControl>.Instance.StopAllMedia();
        scman.EnterStory();
    }

    public void LoadMainStoryChaptersByStoryGroupId(int _storyGroupId, string title)
    {
        var a = dbman.CreateQuery(string.Format("select title, sub_title, story_id from story_detail WHERE story_group_id == {0} ORDER BY story_id DESC", _storyGroupId));

        while (a.Step())
        {
            GameObject PlateInstance = Instantiate(PlatePrefab, view.transform);

            Plates.Add(PlateInstance);
            var st = a.GetText(0);
            if (st.Length != title.Length) st = st.Replace(title, "");
            PlateInstance.GetComponent<StoryPlate>().SetUpStoryPlate(a.GetText(1), null, st, asman.LoadStoryThumbById(a.GetInt(2)), StartSotryByStoryId, a.GetInt(2));
        }
        var idx = 0;
        foreach (var i in Plates)
        {
            i.transform.SetSiblingIndex(idx++);
        }
        a.Dispose();
    }


    public void SetupStoryPlatesByStoryType(int _storyType)
    {
        if(!dbman)
        {
            Debug.Log("Cannot find a instance of DatabeseManager.");
        }
        foreach (Transform child in view.transform)
        {
            Destroy(child.gameObject);
        }
        Plates.Clear();

        var a = dbman.CreateQuery(string.Format("SELECT title, story_group_id, thumbnail_id, disp_order FROM story_data WHERE story_type == {0} ORDER BY disp_order DESC", _storyType));

        while (a.Step())
        {
            GameObject PlateInstance = Instantiate(PlatePrefab, view.transform);

            Plates.Add(PlateInstance);
            var script = PlateInstance.GetComponent<StoryPlate>();
            switch (_storyType)
            {
                case 1:
                case 3:
                {
                    script.SetUpStoryPlate(a.GetText(0), null, null, asman.LoadStoryThumbById(a.GetInt(2)), null, a.GetInt(1));
                    break;
                }
                case 2:
                {
                    var title = a.GetText(0).Split('_');
                    script.SetUpStoryPlate(title[0], title[1], null, asman.LoadStoryThumbById(a.GetInt(2)), null, a.GetInt(1));
                    break;
                }
                default:
                    throw new System.Exception("Unknown Story Id");
            }
        }
        GameObject EndOfList = Instantiate(EndOfListPrefab, view.transform);
        Plates.Insert(0, EndOfList);

        var idx = 0;
        foreach (var i in Plates)
        {
            i.transform.SetSiblingIndex(idx++);
        }

        a.Dispose();
    }

    public void Clear()
    {
        foreach(var i in Plates)
        {
            Destroy(i);
        }
    }
}
