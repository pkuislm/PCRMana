using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class IconEffect : MonoBehaviour
{
    public Image icon;
    public Sprite spriteIdle;
    public Sprite spriteAct;
    public AnimationCurve effectCurve;
    public AnimationCurve effectCurveScaleY;
    //public AnimationCurve effectCurveScaleX;
    LTDescr action;
    LTDescr action2;
    Vector3 tf;
    Vector3 sc;

    public void OnActivated()
    {
        var dst = gameObject.transform.position;
        var dstsc = gameObject.transform.localScale;
        tf = dst;
        sc = dstsc;
        dst.y += 6;
        dstsc.y = 1.2f;

        icon.sprite = spriteAct;
        icon.SetNativeSize();

        action = LeanTween.move(gameObject, dst, 1.7f).setFrom(tf).setEase(effectCurve).setLoopClamp();
        action2 = LeanTween.scale(gameObject, dstsc, 1.7f).setFrom(sc).setEase(effectCurveScaleY).setLoopClamp();
        //action = LeanTween.move(gameObject, dst, 1.5f).setFrom(gameObject.transform.position).setEase(effectCurve).setLoopClamp();
    }

    public void OnDeactivated()
    {
        icon.sprite = spriteIdle;
        icon.SetNativeSize();
        LeanTween.cancel(action.uniqueId);
        LeanTween.cancel(action2.uniqueId);
        gameObject.transform.position = tf;
        gameObject.transform.localScale = sc;
        //gameObject.transform.localPosition = tf.localPosition;
    }

    private void Start()
    {
        icon = GetComponent<Image>();
    }
}
