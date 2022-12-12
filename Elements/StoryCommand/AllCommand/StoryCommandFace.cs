// Decompiled with JetBrains decompiler
// Type: Elements.StoryCommandFace
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A7E03188-4A33-4E31-B2AA-6FF711CC1BCD
// Assembly location: C:\Users\ASUS\Documents\Tencent Files\1668911954\FileRecv\MobileFile\ksdumper-mod\princessconnectredive_11ED3000.dll

using System;
using System.Collections.Generic;
using UnityEngine;

namespace Elements
{
    public class StoryCommandFace : StoryCommandBase
    {
        private int charaId;
        private int faceId = 1;
        private Action finishAction;
        private Action invalidFinishAction;
        private const float CHANGE_FACE_WAIT_TIME = 0.1f;
        private static readonly List<int> FACE_ANIMATION_TARGET_ID_LIST = new List<int>()
        {
            3,
            4,
            5,
            6
        };

        protected override void SetCommandParam()
        {
            charaId = int.Parse(args[0]);
            faceId = int.Parse(args[1]);
            if (faceId != 0)
            return;
            faceId = 1;
        }

        public override void ExecCommand()
        {
            SetCommandParam();
            /*finishAction = () =>
            {
                storyManager.StoryScene.ChangeBustUpFaceSpine(faceId);
                base.ExecCommand();
            };
            invalidFinishAction = () => base.ExecCommand();
            if (storyManager.StillUnitNum == 0)
            {
                StoryCharacter characterWithName = storyManager.StoryScene.GetCharacterWithName(charaId.ToString());
                if (Object.op_Inequality((Object) characterWithName, (Object) null))
                {
                    float _waitTime = 0.1f / (float) storyManager.StoryScene.CommandTimeScale;
                    changeCharacterFace(characterWithName, (MonoBehaviour) storyManager.StoryScene, _waitTime);
                }
                else if (storyManager.NowTalkUnitID == charaId)
                    finishAction();
                else
                    base.ExecCommand();
            }
            else
            {
                if (storyManager.StillUnitNum <= 0)
                    return;
                if (storyManager.StillUnitIDList.Contains(charaId))
                    finishAction();
                else
                    base.ExecCommand();
            }*/
            base.ExecCommand();
        }

        /*private void changeCharacterFace(
            StoryCharacter _chara,
            MonoBehaviour _timeBehavior,
            float _waitTime = 0.1f)
        {
            if (_chara.IsEyeClose)
            {
                _chara.StoryCharacterSetFace(faceId);
                finishAction();
            }
            else if (_chara.FaceId == 1 && StoryCommandFace.FACE_ANIMATION_TARGET_ID_LIST.Contains(faceId) || StoryCommandFace.FACE_ANIMATION_TARGET_ID_LIST.Contains(_chara.FaceId) && faceId == 1)
            {
                _chara.NGUIUnitSpine.PlayAnime(0, eSpineCharacterAnimeId.STORY_EYE_BLINK, false);
                _timeBehavior.Timer(_waitTime, (Action) (() =>
                {
                    if (_chara.NGUIUnitSpine != null)
                    {
                        _chara.StoryCharacterSetFace(faceId);
                        if (!_chara.IsEyeClose)
                            _chara.NGUIUnitSpine.PlayAnime(0, eSpineCharacterAnimeId.STORY_EYE_IDLE);
                        finishAction();
                    }
                    else
                        invalidFinishAction();
                }));
            }
            else if (Object.op_Inequality((Object) _chara.NGUIUnitSpine, (Object) null))
            {
                _chara.StoryCharacterSetFace(faceId);
                finishAction();
            }
            else
                invalidFinishAction();
        }*/

        public enum eArgs
        {
            CHARACTER_ID,
            FACE_ID,
        }
    }
}
