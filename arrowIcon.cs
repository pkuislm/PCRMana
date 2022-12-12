using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowIcon : MonoBehaviour
{
    LTDescr action;

    private void OnEnable()
    {
        action = LeanTween.moveLocalY(gameObject, -90f, 0.4f).setFrom(-80f).setEaseOutCubic().setLoopPingPong();
    }

    private void OnDisable()
    {
        LeanTween.cancel(action.uniqueId);
    }
}
