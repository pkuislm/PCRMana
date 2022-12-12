// Decompiled with JetBrains decompiler
// Type: Elements.StoryCommandFocus
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A7E03188-4A33-4E31-B2AA-6FF711CC1BCD
// Assembly location: C:\Users\ASUS\Documents\Tencent Files\1668911954\FileRecv\MobileFile\ksdumper-mod\princessconnectredive_11ED3000.dll

using System.Collections.Generic;
using UnityEngine;

namespace Elements
{
    public class StoryCommandFocus : StoryCommandBase
    {
        private List<GameObject> charaObjects;
        private int charaCount;
        private string[] targets;

       /* public override void OnLoad()
        {
            charaObjects = new List<GameObject>();
            StoryFindHelper instance = SingletonMonoBehaviour<StoryFindHelper>.Instance;
            charaObjects.Add(instance.GetStoryCharacter(0));
            charaObjects.Add(instance.GetStoryCharacter(1));
            charaObjects.Add(instance.GetStoryCharacter(2));
            charaObjects.Add(instance.GetStoryCharacter(3));
            charaObjects.Add(instance.GetStoryCharacter(4));
            charaCount = charaObjects.Count;
            base.OnLoad();
        }*/

        protected override void SetCommandParam() => targets = args[0].Split(':');

        public override void ExecCommand()
        {
            /*SetCommandParam();
            for (int index1 = 0; index1 < charaCount; ++index1)
            {
                string name = ((Object) charaObjects[index1]).name;
                int length = targets.Length;
                bool _isFocus = false;
                for (int index2 = 0; index2 < length; ++index2)
                {
                    if (name == targets[index2])
                    _isFocus = true;
                }
                toFocus(charaObjects[index1], _isFocus);
            }*/
            base.ExecCommand();
        }

        //private void toFocus(GameObject _target, bool _isFocus) => _target.GetComponent<StoryCharacter>().SetFocus(_isFocus);

        private enum eArgs
        {
            CHARACTER_ID,
            MAX,
        }
    }
}
