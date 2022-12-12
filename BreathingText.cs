using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BreathingText : MonoBehaviour
{
    TextMeshProUGUI text;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        var color = text.color;
        var fadeoutcolor = color;
        fadeoutcolor.a = 0;
        LeanTween.value(gameObject, updateValueExampleCallback, fadeoutcolor, color, 0.6f).setEase(LeanTweenType.easeSpring).setLoopPingPong();
    }

    void updateValueExampleCallback(Color val)
    {
        text.color = val;
    }

}
