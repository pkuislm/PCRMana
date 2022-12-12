// Decompiled with JetBrains decompiler
// Type: Elements.StoryDataConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A7E03188-4A33-4E31-B2AA-6FF711CC1BCD
// Assembly location: C:\Users\ASUS\Documents\Tencent Files\1668911954\FileRecv\MobileFile\ksdumper-mod\princessconnectredive_11ED3000.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Elements
{

    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public interface ICommandConfig
    {
        int GetCommandIndex(ref string name);
        string GetCommandName(int index);
        CommandNumber GetCommandNumber(int index);
        int GetCommandConfigListCount();
        string GetSpacer();
    }

    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [ComDefaultInterface(typeof (ICommandConfig))]
    public class StoryDataConfig : ICommandConfig
    {     
        private List<StoryDataCommandConfig> _commandConfigList = new List<StoryDataCommandConfig>()
        {
            new StoryDataCommandConfig(CommandNumber.TITLE, "title", "StoryCommandTitle", CommandCategory.System, 1, 1),
            new StoryDataCommandConfig(CommandNumber.OUTLINE, "outline", "StoryCommandOutline", CommandCategory.System, 1, 1),
            new StoryDataCommandConfig(CommandNumber.VISIBLE, "visible", "StoryCommandVisible", CommandCategory.System, 2, 2),
            new StoryDataCommandConfig(CommandNumber.FACE, "face", "StoryCommandFace", CommandCategory.System, 2, 2),
            new StoryDataCommandConfig(CommandNumber.FOCUS, "focus", "StoryCommandFocus", CommandCategory.System, 1, 1),
            new StoryDataCommandConfig(CommandNumber.BACKGROUND, "background", "StoryCommandBackground", CommandCategory.System, 1, 3),
            new StoryDataCommandConfig(CommandNumber.PRINT, "print", "StoryCommandPrint", CommandCategory.System, 2, 2),
            new StoryDataCommandConfig(CommandNumber.TAG, "tag", "StoryCommandTag", CommandCategory.System, 1, 1),
            new StoryDataCommandConfig(CommandNumber.GOTO, "goto", "StoryCommandGoto", CommandCategory.System, 1, 1),
            new StoryDataCommandConfig(CommandNumber.BGM, "bgm", "StoryCommandBgm", CommandCategory.System, 1, 6),
            new StoryDataCommandConfig(CommandNumber.TOUCH, "touch", "StoryCommandTouch", CommandCategory.System, 0, 0),
            new StoryDataCommandConfig(CommandNumber.CHOICE, "choice", "StoryCommandChoice", CommandCategory.System, 2, 4),
            new StoryDataCommandConfig(CommandNumber.VO, "vo", "StoryCommandVo", CommandCategory.System, 1, 1),
            new StoryDataCommandConfig(CommandNumber.WAIT, "wait", "StoryCommandWait", CommandCategory.System, 1, 1),
            default,//new StoryDataCommandConfig(CommandNumber.IN_L, "in_L", "StoryCommandInL", CommandCategory.Motion, 1, 3),
            default,//new StoryDataCommandConfig(CommandNumber.IN_R, "in_R", "StoryCommandInR", CommandCategory.Motion, 1, 3),
            default,//new StoryDataCommandConfig(CommandNumber.OUT_L, "out_L", "StoryCommandOutL", CommandCategory.Motion, 1, 3),
            default,//new StoryDataCommandConfig(CommandNumber.OUT_R, "out_R", "StoryCommandOutR", CommandCategory.Motion, 1, 3),
            new StoryDataCommandConfig(CommandNumber.FADEIN, "fadein", "StoryCommandFadein", CommandCategory.Motion, 1, 2),
            default,//new StoryDataCommandConfig(CommandNumber.FADEOUT, "fadeout", "StoryCommandFadeout", CommandCategory.Motion, 0, 2),
            default,//new StoryDataCommandConfig(CommandNumber.IN_FLOAT, "in_float", "StoryCommandInFloat", CommandCategory.Motion, 1, 2),
            default,//new StoryDataCommandConfig(CommandNumber.OUT_FLOAT, "out_float", "StoryCommandOutFloat", CommandCategory.Motion, 1, 2),
            default,//new StoryDataCommandConfig(CommandNumber.JUMP, "jump", "StoryCommandJump", CommandCategory.Motion, 1, 2),
            default,//new StoryDataCommandConfig(CommandNumber.SHAKE, "shake", "StoryCommandShake", CommandCategory.Motion, 1, 2),
            default,//new StoryDataCommandConfig(CommandNumber.POP, "pop", "StoryCommandPop", CommandCategory.Motion, 1, 2),
            default,//new StoryDataCommandConfig(CommandNumber.NOD, "nod", "StoryCommandNod", CommandCategory.Motion, 1, 2),
            default,//new StoryDataCommandConfig(CommandNumber.SE, "se", "StoryCommandSe", CommandCategory.System, 1, 1),
            default,//new StoryDataCommandConfig(CommandNumber.BLACK_OUT, "black_out", "StoryCommandBlackOut", CommandCategory.System, 0, 2),
            default,//new StoryDataCommandConfig(CommandNumber.BLACK_IN, "black_in", "StoryCommandBlackIn", CommandCategory.System, 0, 2),
            default,//new StoryDataCommandConfig(CommandNumber.WHITE_OUT, "white_out", "StoryCommandWhiteOut", CommandCategory.System, 0, 2),
            default,//new StoryDataCommandConfig(CommandNumber.WHITE_IN, "white_in", "StoryCommandWhiteIn", CommandCategory.System, 0, 2),
            default,//new StoryDataCommandConfig(CommandNumber.TRANSITION, "transition", "StoryCommandTransition", CommandCategory.System, 1, 2),
            new StoryDataCommandConfig(CommandNumber.SITUATION, "situation", "StoryCommandSituation", CommandCategory.System, 1, 1),
            default,//new StoryDataCommandConfig(CommandNumber.COLOR_FADEIN, "color_fadein", "StoryCommandColorFadein", CommandCategory.System, 3, 3),
            default,//new StoryDataCommandConfig(CommandNumber.FLASH, "flash", "StoryCommandFlash", CommandCategory.System, 0, 0),
            default,//new StoryDataCommandConfig(CommandNumber.SHAKE_TEXT, "shake_text", "StoryCommandShakeText", CommandCategory.System, 0, 0),
            default,//new StoryDataCommandConfig(CommandNumber.TEXT_SIZE, "text_size", "StoryCommandTextSize", CommandCategory.System, 0, 1),
            default,//new StoryDataCommandConfig(CommandNumber.SHAKE_SCREEN, "shake_screen", "StoryCommandShakeScreen", CommandCategory.System, 0, 0),
            default,//new StoryDataCommandConfig(CommandNumber.DOUBLE, "double", "StoryCommandDouble", CommandCategory.System, 2, 4),
            default,//new StoryDataCommandConfig(CommandNumber.SCALE, "scale", "StoryCommandScale", CommandCategory.Motion, 1, 4),
            default,//new StoryDataCommandConfig(CommandNumber.TITLE_TELOP, "title_telop", "StoryCommandTitleTelop", CommandCategory.System, 1, 1),
            default,//new StoryDataCommandConfig(CommandNumber.WINDOW_VISIBLE, "window_visible", "StoryCommandWindowVisible", CommandCategory.System, 1, 1),
            default,//new StoryDataCommandConfig(CommandNumber.LOG, "log", "StoryCommandLog", CommandCategory.System, 3, 4),
            default,//new StoryDataCommandConfig(CommandNumber.NOVOICE, "novoice", "StoryCommandNoVoice", CommandCategory.System, 0, 0),
            default,//new StoryDataCommandConfig(CommandNumber.CHANGE, "change", "StoryCommandChange", CommandCategory.Motion, 2, 3),
            default,//new StoryDataCommandConfig(CommandNumber.FADEOUT_ALL, "fadeout_all", "StoryCommandFadeoutAll", CommandCategory.Motion, 0, 1),
            default,//new StoryDataCommandConfig(CommandNumber.MOVIE, "movie", "StoryCommandMovie", CommandCategory.System, 1, 4),
            default,//new StoryDataCommandConfig(CommandNumber.MOVIE_STAY, "movie_stay", "StoryCommandMovieStay", CommandCategory.System, 1, 4),
            default,//new StoryDataCommandConfig(CommandNumber.BATTLE, "battle", "StoryCommandBattle", CommandCategory.System, 0, 0),
            default,//new StoryDataCommandConfig(CommandNumber.STILL, "still", "StoryCommandStill", CommandCategory.System, 1, 6),
            default,//new StoryDataCommandConfig(CommandNumber.BUSTUP, "bust", "StoryCommandBustup", CommandCategory.System, 1, 3),
            new StoryDataCommandConfig(CommandNumber.ENV, "amb", "StoryCommandEnv", CommandCategory.System, 1, 4),
            default,//new StoryDataCommandConfig(CommandNumber.TUTORIAL_REWARD, "reward", "StoryCommandTutorialReward", CommandCategory.System, 0, 0),
            default,//new StoryDataCommandConfig(CommandNumber.NAME_EDIT, "name_dialog", "StoryCommandPlayerNameEdit", CommandCategory.System, 0, 0),
            new StoryDataCommandConfig(CommandNumber.EFFECT, "effect", "StoryCommandParticleEffect", CommandCategory.Effect, 1, 5),
            default,//new StoryDataCommandConfig(CommandNumber.EFFECT_DELETE, "effect_delete", "StoryCommandParticleDelete", CommandCategory.Effect, 1, 2),
            default,//new StoryDataCommandConfig(CommandNumber.EYE_OPEN, "eye_open", "StoryCommandEyeOpen", CommandCategory.System, 1, 1),
            default,//new StoryDataCommandConfig(CommandNumber.MOUTH_OPEN, "mouth_open", "StoryCommandMouthOpen", CommandCategory.System, 1, 1),
            default,//new StoryDataCommandConfig(CommandNumber.AUTO_END, "end", "StoryCommandForcedEnd", CommandCategory.System, 0, 0),
            default,//new StoryDataCommandConfig(CommandNumber.EMOTION, "emotion", "StoryCommandEmotion", CommandCategory.Effect, 1, 5),
            default,//new StoryDataCommandConfig(CommandNumber.EMOTION_END, "emotion_end", "StoryCommandEmotionEnd", CommandCategory.Effect, 1, 1),
            default,//new StoryDataCommandConfig(CommandNumber.ENV_STOP, "amb_stop", "StoryCommandEnvStop", CommandCategory.System, 1, 2),
            default,//new StoryDataCommandConfig(CommandNumber.BGM_PAUSE, "bgm_stop", "StoryCommandBgmPause", CommandCategory.System, 0, 2),
            default,//new StoryDataCommandConfig(CommandNumber.BGM_RESUME, "bgm_resume", "StoryCommandBgmResume", CommandCategory.System, 0, 2),
            default,//new StoryDataCommandConfig(CommandNumber.BGM_VOLUME_CHANGE, "bgm_volume", "StoryCommandBgmVolumeChange", CommandCategory.System, 1, 2),
            default,//new StoryDataCommandConfig(CommandNumber.ENV_RESUME, "amb_resume", "StoryCommandEnvResume", CommandCategory.System, 0, 2),
            default,//new StoryDataCommandConfig(CommandNumber.ENV_VOLUME, "amb_volume", "StoryCommandEnvVolumeChange", CommandCategory.System, 1, 2),
            default,//new StoryDataCommandConfig(CommandNumber.SE_PAUSE, "se_pause", "StoryCommandSeStop", CommandCategory.System, 0, 2),
            new StoryDataCommandConfig(CommandNumber.CHARA_FULL, "chara_full", "StoryCommandCharacterFull", CommandCategory.System, 3, 4),
            default,//new StoryDataCommandConfig(CommandNumber.SWAY, "sway", "StoryCommandSway", CommandCategory.Motion, 1, 1),
            new StoryDataCommandConfig(CommandNumber.BACKGROUND_COLOR, "bg_color", "StoryCommandBackgroundColor", CommandCategory.System, 3, 4),
            default,//new StoryDataCommandConfig(CommandNumber.PAN, "pan", "StoryCommandStillPan", CommandCategory.Motion, 1, 1),
            default,//new StoryDataCommandConfig(CommandNumber.STILL_UNIT, "still_unit", "StoryCommandStillUnit", CommandCategory.System, 1, 1),
            default,//new StoryDataCommandConfig(CommandNumber.SLIDE_CHARA, "slide", "StoryCommandSlideCharacter", CommandCategory.Motion, 1, 1),
            default,//new StoryDataCommandConfig(CommandNumber.SHAKE_SCREEN_ONCE, "shake_once", "StoryCommandShakeScreenOnce", CommandCategory.System, 1, 1),
            default,//new StoryDataCommandConfig(CommandNumber.TRANSITION_RESUME, "transition_resume", "StoryCommandTransitionResume", CommandCategory.System, 0, 0),
            default,//new StoryDataCommandConfig(CommandNumber.SHAKE_LOOP, "shake_loop", "StoryCommandShakeLoop", CommandCategory.System, 0, 0),
            default,//new StoryDataCommandConfig(CommandNumber.SHAKE_DELETE, "shake_delete", "StoryCommandShakeDelete", CommandCategory.System, 0, 0),
            default,//new StoryDataCommandConfig(CommandNumber.UNFACE, "unface", "StoryCommandUnface", CommandCategory.System, 1, 1),
            default,//new StoryDataCommandConfig(CommandNumber.WAIT_TOKEN, "token", "StoryCommandWaitToken", CommandCategory.System, 0, 1),
            default,//new StoryDataCommandConfig(CommandNumber.EFFECT_ENV, "effect_env", "StoryCommandParticleEffectEnv", CommandCategory.Effect, 1, 1),
            default,//new StoryDataCommandConfig(CommandNumber.BRIGHT_CHANGE, "bright_change", "StoryCommandBrightChange", CommandCategory.System, 2, 2),
            default,//new StoryDataCommandConfig(CommandNumber.CHARA_SHADOW, "chara_shadow", "StoryCommandCharacterShadow", CommandCategory.System, 2, 2),
            default,//new StoryDataCommandConfig(CommandNumber.UI_VISIBLE, "ui_visible", "StoryCommandMenuVisible", CommandCategory.System, 1, 1),
            default,//new StoryDataCommandConfig(CommandNumber.FADEIN_ALL, "fadein_all", "StoryCommandFadeinAll", CommandCategory.System, 0, 1),
            default,//new StoryDataCommandConfig(CommandNumber.CHANGE_WINDOW, "change_window", "StoryCommandChangeWindow", CommandCategory.System, 0, 1),
            new StoryDataCommandConfig(CommandNumber.BG_PAN, "bg_pan", "StoryCommandBackgroundPan", CommandCategory.System, 2, 3),
            default,//new StoryDataCommandConfig(CommandNumber.STILL_MOVE, "still_move", "StoryCommandStillMove", CommandCategory.System, 2, 3),
            default,//new StoryDataCommandConfig(CommandNumber.STILL_NORMALIZE, "still_normalize", "StoryCommandStillNormalize", CommandCategory.System, 1, 1),
            new StoryDataCommandConfig(CommandNumber.VOICE_EFFECT, "vo_effect", "StoryCommandVoiceEffect", CommandCategory.System, 0, 1),
            //new StoryDataCommandConfig(CommandNumber.TRIAL_END, "trial_end", "StoryCommandTrialEnd", CommandCategory.System, 0, 0),
            //new StoryDataCommandConfig(CommandNumber.SE_EFFECT, "se_effect", "StoryCommandSeEffect", CommandCategory.System, 0, 1),
            //new StoryDataCommandConfig(CommandNumber.CHARACTER_UP_DOWN, "updown", "StoryCommandCharacterUpdown", CommandCategory.Motion, 4, 4),
            new StoryDataCommandConfig(CommandNumber.BG_CAMERA_ZOOM, "bg_zoom", "StoryCommandBgCameraZoom", CommandCategory.System, 2, 2),
            new StoryDataCommandConfig(CommandNumber.BACKGROUND_SPLIT, "split", "StoryCommandBackgroundSplit", CommandCategory.System, 2, 6),
            //new StoryDataCommandConfig(CommandNumber.CAMERA_ZOOM, "camera_zoom", "StoryCommandCameraZoom", CommandCategory.System, 2, 2),
            new StoryDataCommandConfig(CommandNumber.SPLIT_SLIDE, "split_slide", "StoryCommandBackgroundSplitSlide", CommandCategory.System, 0, 6),
            //new StoryDataCommandConfig(CommandNumber.BGM_TRANSITION, "bgm_transition", "StoryCommandBgmTransition", CommandCategory.System, 2, 2),
            new StoryDataCommandConfig(CommandNumber.SHAKE_ANIME, "shake_anime", "StoryCommandBackgroundAnimation", CommandCategory.System, 0, 1),
            //new StoryDataCommandConfig(CommandNumber.INSERT_STORY, "insert", "StoryCommandInsertStory", CommandCategory.System, 0, 0),
            //new StoryDataCommandConfig(CommandNumber.PLACE, "place", "StoryCommandPlace", CommandCategory.System, 1, 1),
            //new StoryDataCommandConfig(CommandNumber.IGNORE_BGM, "bgm_overview", "StoryCommandBgmIgnoreStop", CommandCategory.System, 1, 5),
            //new StoryDataCommandConfig(CommandNumber.MULTI_LIPSYNC, "multi_talk", "StoryCommandMultiLipsync", CommandCategory.System, 0, 1),
            //new StoryDataCommandConfig(CommandNumber.JINGLE, "jingle_start", "StoryCommandJingle", CommandCategory.System, 1, 1),
            //new StoryDataCommandConfig(CommandNumber.TOUCH_TO_START, "touch_to_start", "StoryCommandTouchToStart", CommandCategory.System, 0, 0),
            //new StoryDataCommandConfig(CommandNumber.EVENT_ADV_MOVE_HORIZONTAL, "event_change", "StoryCommandEventCharacterChange", CommandCategory.System, 1, 3),
            new StoryDataCommandConfig(CommandNumber.BG_PAN_X, "bg_pan_slide", "StoryCommandBackgroundPanX", CommandCategory.System, 1, 3),
            new StoryDataCommandConfig(CommandNumber.BACKGROUND_BLUR, "bg_blur", "StoryCommandBackgroundBlur", CommandCategory.System, 1, 3),
            //new StoryDataCommandConfig(CommandNumber.SEASONAL_REWARD, "seasonal_reward", "StoryCommandSeasonalReward", CommandCategory.System, 0, 0),
            //new StoryDataCommandConfig(CommandNumber.MINI_GAME, "mini_game", "StoryCommandMiniGame", CommandCategory.System, 0, 1),
            //new StoryDataCommandConfig(CommandNumber.DIALOG_ANIMATION, "dialog_anime", "StoryCommandDialogAnimation", CommandCategory.System, 0, 1),
            //new StoryDataCommandConfig(CommandNumber.NEXT_AUTO_CHOICE_DISABLE, "next_auto_choice_disable", "StoryCommandNextAutoChoiceDisable", CommandCategory.System, 0, 0)
        };

        public int GetCommandIndex(ref string name)
        {
            int count = _commandConfigList.Count;
            for (int index = 0; index < count; ++index)
            {
                if (_commandConfigList[index].Name != null && _commandConfigList[index].Name.Equals(name))
                    return index;
            }
            return -1;
        }

        public string GetCommandName(int index) => index >= _commandConfigList.Count | index < 0 ? null : _commandConfigList[index].Name;

        public string GetCommandClassName(int index) => index >= _commandConfigList.Count | index < 0 ? null : _commandConfigList[index].ClassName;

        public CommandCategory GetCommandCategory(int index) => index >= _commandConfigList.Count | index < 0 ? CommandCategory.Non : _commandConfigList[index].Category;

        public int GetCommandMinArgCount(int index) => index >= _commandConfigList.Count | index < 0 ? 0 : _commandConfigList[index].MinArgCount;

        public int GetCommandMaxArgCount(int index) => index >= _commandConfigList.Count | index < 0 ? 0 : _commandConfigList[index].MaxArgCount;

        public int GetCommandConfigListCount() => _commandConfigList.Count;

        public string GetSpacer() => char.ToString(' ');

        public CommandNumber GetCommandNumber(int index) => index >= _commandConfigList.Count | index < 0 ? CommandNumber.NONE : _commandConfigList[index].Number;
    }
}
