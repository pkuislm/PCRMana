using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuPage : MonoBehaviour
{
    [SerializeField] AnimationCurve fadeoutCurve;
    [SerializeField] AnimationCurve fadeinCurve;
    [SerializeField] AnimationCurve fadeinAlphaCurve;
    [SerializeField] TextMeshProUGUI title;
    public string bgm;
    public string mov;
    public string bg;
    public bool isStatic;
    public bool isTemp;

    public void OnSwapOut()
    {
        LeanTween.size(gameObject.GetComponent<RectTransform>(), new Vector2(3000, 720), 0.15f).setEase(fadeoutCurve);
        LeanTween.alphaCanvas(gameObject.GetComponent<CanvasGroup>(), 0f, 0.08f);
    }

    public void OnSwapIn()
    {
        LeanTween.size(gameObject.GetComponent<RectTransform>(), new Vector2(1280, 720), 0.15f).setEase(fadeinCurve).setDelay(0.2f);
        LeanTween.alphaCanvas(gameObject.GetComponent<CanvasGroup>(), 1f, 0.12f).setDelay(0.2f);
    }

    public void SetTitle(string t)
    {
        if (t == null) return;
        if(t.Length > 1)
        {
            title.text = string.Format("<size=50>{0}</size>{1}", t.Substring(0,1), t.Substring(1));
        }
        else if(t.Length == 1)
        {
            title.text = string.Format("<size=50>{0}</size>", t);
        }
    }
}
