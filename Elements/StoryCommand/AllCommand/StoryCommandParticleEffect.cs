// Decompiled with JetBrains decompiler
// Type: Elements.StoryCommandParticleEffect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A7E03188-4A33-4E31-B2AA-6FF711CC1BCD
// Assembly location: C:\Users\ASUS\Documents\Tencent Files\1668911954\FileRecv\MobileFile\ksdumper-mod\princessconnectredive_11ED3000.dll

using System.Collections.Generic;
using UnityEngine;

namespace Elements
{
    public class StoryCommandParticleEffect : StoryCommandBase
    {
        private int effectId;
        private float angle;
        private float effectPosX;
        private string playSeName = "";
        private bool isPlaySe;
        private bool isPlayLoop;

        protected override void SetCommandParam()
        {
            effectId = int.Parse(args[0]);
            isPlaySe = false;
            if (args.Length > 1)
            {
                isPlaySe = true;
                playSeName = args[1];
            }
            angle = 0.0f;
            if (args.Length > 2)
                angle = float.Parse(args[2]);
            isPlayLoop = false;
            if (args.Length <= 4)
                return;
            isPlayLoop = int.Parse(args[4]) == 1;
        }

        public override void ExecCommand()
        {
            StoryScene storyScene = storyManager.StoryScene;
            SetCommandParam();
            effectPosX = 0.0f;
            /*if (args.Length > 3)
            {
                StoryCharacter characterWithPos = storyScene.GetCharacterWithPos(args[3]);
                if (Object.op_Inequality((Object) characterWithPos, (Object) null))
                    effectPosX = ((Component) characterWithPos).transform.localPosition.x;
            }
            storyManager.StoryPlayEffectDic[effectId] = playParticle(storyScene.ParticleEffectObj, false, (float) storyScene.CommandTimeScale);*/
            base.ExecCommand();
        }

        /*private GameObject playParticle(GameObject _particleParentObj, bool _isTutorial, float _simulationSpeed = 1f)
        {
            GameObject gameObject = ManagerSingleton<ResourceManager>.Instance.LoadImmediately(eResourceId.STORY_PARTICLE_EFFECT, _particleParentObj.transform, (long)effectId);
            gameObject.transform.localPosition = new Vector3(effectPosX, 0f, 0f);
            gameObject.transform.rotation = Quaternion.Euler(0f, 0f, angle);
            ParticleSystem componentInChildren = gameObject.GetComponentInChildren<ParticleSystem>();
            componentInChildren.main.simulationSpeed = _simulationSpeed;
            ParticleSystem[] componentsInChildren = componentInChildren.GetComponentsInChildren<ParticleSystem>();
            if (isPlayLoop)
            {
                for (int i = 0; i < componentsInChildren.Length; i++)
                {
                    componentsInChildren[i].main.loop = isPlayLoop;
                }
            }
            ParticleSystemRenderer[] componentsInChildren2 = componentInChildren.GetComponentsInChildren<ParticleSystemRenderer>();
            for (int j = 0; j < componentsInChildren2.Length; j++)
            {
                if (componentsInChildren2[j].sharedMaterial != null)
                {
                    componentsInChildren2[j].sharedMaterial.color = componentsInChildren2[j].material.color;
                }
            }
            if (_isTutorial)
            {
                int depth = tutorialStoryManager.TutorialScene.Depth;
                for (int k = 0; k < componentsInChildren.Length; k++)
                {
                    componentsInChildren[k].gameObject.layer = LayerDefine.LAYER_DIALOG;
                    Renderer component = componentsInChildren[k].GetComponent<Renderer>();
                    int num = component.sortingOrder % 100;
                    component.sortingOrder = depth + num;
                }
            }
            componentInChildren.Play();
            if (isPlaySe)
            {
                soundManager.PlaySeFromName(playSeName, playSeName, false);
            }
            return gameObject;
        }*/

        public static int GetEffectId(List<string> _args)
        {
            int result = -1;
            int.TryParse(_args[0], out result);
            return result;
        }

        public static string GetSeId(List<string> _args) => _args.Count >= 2 ? _args[1] : (string) null;

        private enum eArgs
        {
            EFFECT_ID,
            SE_NAME,
            ANGLE,
            POSITION,
            LOOP_FLAG,
            MAX,
        }
    }
}
