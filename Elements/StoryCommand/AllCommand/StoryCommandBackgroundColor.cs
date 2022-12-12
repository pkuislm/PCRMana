// Decompiled with JetBrains decompiler
// Type: Elements.StoryCommandBackgroundColor
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A7E03188-4A33-4E31-B2AA-6FF711CC1BCD
// Assembly location: C:\Users\ASUS\Documents\Tencent Files\1668911954\FileRecv\MobileFile\ksdumper-mod\princessconnectredive_11ED3000.dll

using System.Collections.Generic;
using UnityEngine;

namespace Elements
{
    public class StoryCommandBackgroundColor : StoryCommandBase
    {
        private const float COLOR_RATE = 255f;

        public float Red { get; private set; }

        public float Green { get; private set; }

        public float Blue { get; private set; }

        public float Alpha { get; private set; }

        public override void ExecCommand()
        {
            StoryScene storyScene = storyManager.StoryScene;
            Red = float.Parse(args[0]);
            Green = float.Parse(args[1]);
            Blue = float.Parse(args[2]);
            Alpha = 1f;
            if (args.Length >= 4)
                Alpha = float.Parse(args[3]);
            //Color _color = new(Red / byte.MaxValue, Green / byte.MaxValue, Blue / byte.MaxValue, Alpha);
            Debug.Log("StoryCommandBgColor");
            //storyScene.ChangeColorBackground(_color);
            //storyManager.BgType = StoryHistoryInformation.eBackgroundType.BACK_GROUND_COLOR;
            base.ExecCommand();
        }

        public static Color GetBackgroundColor(List<string> _args) => new Color((float) ((double) float.Parse(_args[0]) / (double) byte.MaxValue), float.Parse(_args[1]) / (float) byte.MaxValue, float.Parse(_args[2]) / (float) byte.MaxValue, 1f);

        private enum eArgs
        {
            RED,
            GREEN,
            BLUE,
            ALPHA,
            MAX,
        }
    }
}
