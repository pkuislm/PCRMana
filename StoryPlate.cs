using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class StoryPlate : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI TitleText;
    [SerializeField]
    TextMeshProUGUI SubTitleText;
    [SerializeField]
    TextMeshProUGUI SubTitleText2;
    [SerializeField]
    RawImage StoryThumb;

    UnityAction<int> action;
    int _data;
    string nextPageTitle;

    public void SetUpStoryPlate(string t1, string t2, string t3, Texture2D StoryImage, UnityAction<int> OnClickAction, int _storyGroupId)
    {
        TitleText.text = t1;
        nextPageTitle = t1;
        if(t2 == null)
        {
            SubTitleText.enabled = false;
        }
        else
        {
            SubTitleText.text = t2;
        }
        if(t3 == null)
        {
            SubTitleText2.enabled = false;
        }
        else
        {
            SubTitleText2.text = t3;
        }
        if(StoryImage != null)
        {
            StoryThumb.texture = StoryImage;
        }
        action = OnClickAction;
        _data = _storyGroupId;
    }

    public void OnPlateClick()
    {
        if(action == null)
        {
            var pc = Singleton<PageControl>.Instance;

            string bg = "";
            //string bgm = "";
            bool s = false;

            pc.CreateAndEnterStoryDetailPage(_data, bg, null, s, nextPageTitle);
        }
        else
        {
            action(_data);
        }
    }
}
