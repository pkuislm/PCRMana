// Decompiled with JetBrains decompiler
// Type: Elements.AdvDefine
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A7E03188-4A33-4E31-B2AA-6FF711CC1BCD
// Assembly location: C:\Users\ASUS\Documents\Tencent Files\1668911954\FileRecv\MobileFile\ksdumper-mod\princessconnectredive_11ED3000.dll

using System.Collections.Generic;
using UnityEngine;

namespace Elements
{
  public class AdvDefine
  {
    public static bool INTERCEPT_TOUCH = true;
    public const char COMMAND_PARAM_SEPARATE_SYMBOL = ':';
    public const string ACTIVATOR_TYPE_HEADER = "Elements.";
    public const int AUTO_PLAY_FEED_PAGE_WAIT = 10;
    public const int TAP_WAIT_FRAME = 10;
    public const int MASK_DEFAULT_SORT_ORDER = 1200;
    public const int MASK_DEFAULT_SORT_ORDER_DIALOG_STORY = 9700;
    public const int INVALID_TALK_UNIT_ID = -1;
    public const int DEFAULT_COMMAND_TIME_SCALE = 1;
    public const int FAST_FORWARD_COMMAND_TIME_SCALE = 16;
    public const int CHANGE_FAST_FORWARD_MODE_WAIT_FRAME = 45;
    public const int TYPEWRITE_SPEED = 13;
    public const float COLOR_RATE = 255f;
    public const int DEFAULT_FONT_SIZE = 23;
    public const string DEFAULT_CHARACTER_HEADER = "Chara";
    public const string CHARA_C = "C";
    public const string CHARA_L = "L";
    public const string CHARA_LC = "LC";
    public const string CHARA_R = "R";
    public const string CHARA_RC = "RC";
    public const int CHARA_ID_C = 0;
    public const int CHARA_ID_L = 1;
    public const int CHARA_ID_LC = 2;
    public const int CHARA_ID_R = 3;
    public const int CHARA_ID_RC = 4;
    public const float CHARACTER_FADE_TIME = 0.3f;
    public const float CHARACTER_CLIPPANEL_HEIGHT = 960f;
    public const float TUTORIAL_CHARACTER_CLIPPANEL_HEIGHT = 1440f;
    public static readonly List<int> TUTORIAL_ADV_CHARACTER_ADD_DEPTH = new List<int>()
    {
      18,
      10,
      14,
      12,
      16
    };
    public static readonly string[] CHARACTER_POS_ARRAY = new string[5]
    {
      "C",
      "L",
      "LC",
      "R",
      "RC"
    };
    public static readonly Dictionary<string, int> CharacterPositionNameToIndexDectionary = new Dictionary<string, int>()
    {
      {
        "C",
        0
      },
      {
        "L",
        1
      },
      {
        "LC",
        2
      },
      {
        "R",
        3
      },
      {
        "RC",
        4
      }
    };
    public static readonly Dictionary<string, int> CharacterPositionCharaNameToIndexDectionary = new Dictionary<string, int>()
    {
      {
        "CharaC",
        0
      },
      {
        "CharaL",
        1
      },
      {
        "CharaLC",
        2
      },
      {
        "CharaR",
        3
      },
      {
        "CharaRC",
        4
      }
    };
    public const int FULL_RENDER_TEXTURE_WIDTH = 1414;
    public const int WIDE_FULL_RENDER_TEXTURE_WIDTH = 1920;
    public const int FULL_RENDER_TEXTURE_HEIGHT = 1024;
    public const int FULL_RENDER_TEXTURE_DISPLAY_OFFSET_Y = 692;
    public const int FULL_RENDER_TEXTURE_RENDER_OFFSET_Y = 0;
    public const float STORY_CHARACTER_CLIPPING_DEFAULT_OFFSET = 0.0f;
    public const float STORY_CHARACTER_CLIPPING_DEFAULT_SIZE = 460f;
    public const float STORY_CHARACTER_CLIPPING_DEFAULT_SOFTNESS = 50f;
    public const float STORY_CHARACTER_CLIPPING_PANEL_FADE_TIME = 0.3f;
    public const float STORY_CHARACTER_CLIPPING_PANEL_SIZE_SCALE = 1.5f;
    public const float CHARACTER_FADEIN_START_EYE_ANIMATION_WAITMAX_LOW = 2.5f;
    public const float CHARACTER_FADEIN_START_EYE_ANIMATION_WAITMAX_HIGH = 5f;
    public const float CHARACTER_FADEIN_START_EYE_ANIMATION_START_MIN_TIME = 0.3f;
    public const float EVENT_ADV_CHARACTER_MOVE_END_POS_X = -285f;
    public const string STORY_VOICE_CUE_SHEET_NAME = "vo_adv_{0:D7}";
    public const string STORY_VOICE_ASSET_NAME = "v/t/vo_adv_{0:D7}";
    public const string STORY_VOICE_ASSET_BIRTHDAY_DRAMA_NAME = "v/vo_adv_{0:D7}";
    public const int STORY_MOVIE_ENDING_CHECK_DIGIT = 100;
    public const int STORY_MOVIE_ENDING_MOVIE_NUMBER = 80;
    public const float MOVIE_TOUCH_CALLBACK_ACTIVE_WAIT = 1.5f;
    public static readonly Vector2 MOVIE_SCREEN_SIZE = new Vector2(1280f, 720f);
    public const string VO_EFFECT_COMMAND_AISAC_REVERB = "VoiceReverb";
    public const string SE_EFFECT_COMMAND_AISAC_REVERB = "SeReverb";
    public const int MAIN_STORY_ENDING_MOVIE_KEY_ID = 80;
    public const int NEXT_NOTICE_MOVIE_KEY_ID = 81;
    public const int NEXT_NOTICE_MOVIE_KEY_DIGIT = 100;
    public const string AISAC_NAME_1 = "Minigame_01";
    public const string AISAC_NAME_2 = "Minigame_02";
    public const int BACKGROUND_WIDTH = 1414;
    public const int BACKGROUND_HEIGHT = 1060;
    public const int HORIZONTAL_BACKGROUND_WIDTH = 1768;
    public const int VERTICAL_BACKGROUND_HEIGHT = 1768;
    public const int COLOR_SELECT_BACKGROUND_WIDTH = 2048;
    public const int COLOR_SELECT_BACKGROUND_HEIGHT = 2048;
    public const int STILL_UNIT_MAX = 10;
    public const float STILL_SPINE_FADE_OUT_TIME = 0.1f;
    public const float STILL_SPINE_FADE_IN_TIME = 0.3f;
    public const float STILL_TEXTURE_FADE_OUT_TIME = 0.4f;
    public const float STILL_TEXTURE_FADE_IN_TIME = 0.4f;
    public const int STILL_TEXTURE_WIDTH = 1280;
    public const int STILL_NORMAL_TEXTURE_HEIGHT = 720;
    public const int STILL_VERTICAL_TEXTURE_HEIGHT = 1333;
    public const float STILL_TEXTURE_BASE_POSITION = -360f;
    public const float STILL_PAN_TWEEN_DURATION = 2f;
    public const float STILL_UNIT_SPINE_OFFSET_X = -0.47f;
    public const float STILL_UNIT_SPINE_OFFSET_Y = 0.47f;
    public const float STILL_MOVE_TWEEN_DURATION = 2f;
    public const float STILL_CROSS_FADE_TIME = 1f;
    public const float STORY_COMMAND_BACKGROUND_SPLIT_PANEL_HEIGHT = 3000f;
    public const float STORY_COMMAND_BACKGROUND_SPLIT_LINE_BASE_ANGLE = 90f;
    public const float SPLIT_SLIDE_TEXTURE_DEFAULT_POSX = -640f;
    public const string STORY_COMMAND_BACKGROUND_ANIMATION_HEADER = "ADV_background_anime_{0:D3}";
    public const float BACKGROUND_DEFAULT_BLUR_SIZE = 1f;
    public const float BACKGROUND_MAX_BLUR_SIZE = 3f;
    public const float UNIT_BUSTUP_SCALE_XY = 0.5f;
    public const float BUSTUP_FADE_IN_TIME = 0.3f;
    public const float BUSTUP_FADE_OUT_TIME = 0.3f;
    public const float BUSTUP_FADE_WAIT_TIME = 0.0f;
    public const string SEARCH_BASTUP_SLOT_NAME = "bustUp";
    public const string CALC_BASTUP_OFFSET_TARGET = "left";
    public const float BUSTUP_PANEL_BASE_SIZE_WIDTH = 1000f;
    public const float BUSTUP_PANEL_BASE_SIZE_HEIGHT = 1500f;
    public const float BUSTUP_PANEL_CENTER_X = -452f;
    public const float BUSTUP_CALC_PANEL_SCALE = 0.5f;
    public const int BUSTUP_COMMAND_IS_DISP_SPINE_FACE = 1;
    public const float WINDOW_PANEL_FADE_OUT_TIME = 0.1f;
    public const float WINDOW_PANEL_FADE_WAIT_TIME = 0.0f;
    public static readonly string NORMAL_TEXTWINDOW_NO_SPEECHOPTION_SPRITE_NAME = "adv_bg_speech_1_0";
    public static readonly string[] NORMAL_TEXTWINDOW_SPRITE_NAME = new string[5]
    {
      "adv_bg_speech_1_3",
      "adv_bg_speech_1_1",
      "adv_bg_speech_1_2",
      "adv_bg_speech_1_1",
      "adv_bg_speech_1_2"
    };
    public static readonly string FEELING_TEXTWINDOW_SPRITE_NAME = "adv_bg_speech_2";
    public static readonly string[] EMPHASIS_TEXTWINDOW_SPRITE_NAME = new string[5]
    {
      "adv_bg_speech_3_3",
      "adv_bg_speech_3_1",
      "adv_bg_speech_3_2",
      "adv_bg_speech_3_1",
      "adv_bg_speech_3_4"
    };
    public static readonly string EMPHASIS_TEXTWINDOW_NO_SPEECHOPTION_SPRITE_NAME = "adv_bg_speech_3";
    public static readonly string EVENT_NORMAL_TEXTWINDOW_NO_SPEECHOPTION_SPRITE_NAME = "adv_bg_speech_event_1_0";
    public static readonly string[] EVENT_NORMAL_TEXTWINDOW_SPRITE_NAMES = new string[5]
    {
      "adv_bg_speech_event_1_3",
      "adv_bg_speech_event_1_1",
      "adv_bg_speech_event_1_2",
      "adv_bg_speech_event_1_4",
      "adv_bg_speech_event_1_5"
    };
    public const int NORMAL_SPEECH_WINDOW_WIDTH = 882;
    public const int NORMAL_SPEECH_WINDOW_HEIGHT = 196;
    public const int NORMAL_SPEECH_WINDOW_NO_OPTION_HEIGHT = 144;
    public const int FEELING_SPEECH_WINDOW_WIDTH = 914;
    public const int FEELING_SPEECH_WINDOW_HEIGHT = 194;
    public const int EMPHASIS_SPEECH_WINDOW_WIDTH = 926;
    public const int EMPHASIS_SPEECH_WINDOW_HEIGHT = 220;
    public const int EMPHASIS_SPEECH_WINDOW_HEIGHT_LC = 240;
    public const int EMPHASIS_SPEECH_WINDOW_NO_OPTION_HEIGHT = 180;
    public static readonly Vector3 NORMAL_TEXTWINDOW_ROTATE = Vector3.zero;
    public static readonly Vector3 REVERSAL_TEXTWINDOW_ROTATE = new Vector3(0.0f, 180f, 0.0f);
    public static readonly Vector3 DIALOG_ADV_NORMAL_WINDOW_POS = new Vector3(0.0f, -98f, 0.0f);
    public static readonly Vector3 DIALOG_ADV_FEELING_WINDOW_POS = new Vector3(0.0f, -118f, 0.0f);
    public static readonly Vector3 DIALOG_ADV_EMPHASIS_WINDOW_POS = new Vector3(0.0f, -121f, 0.0f);
    public const float SWAY_COMMAND_SHAKE_DECAY = 0.006f;
    public const float SWAY_COMMAND_SHAKE_INTENSITY = 0.11f;
    public const float SHAKE_ONCE_COMMAND_DECAY = 0.012f;
    public const float SHAKE_ONCE_COMMAND_INTENSITY = 0.1f;
    public const float SLIDE_COMMAND_DECAY = 0.04f;
    public const float SLIDE_COMMAND_INTENSITY = 0.8f;
    public const float SHAKE_LOOP_COMMAND_INTENSITY = 0.009f;
    public const float SHAKE_SCREEN_COMMAND_CHARACTER_DECAY = 0.002f;
    public const float SHAKE_SCREEN_COMMAND_CHARACTER_INTENSITY = 0.1f;
    public const int TOKEN_COMMAND_DEFAULT_INDEX = 1;
    public const float FADE_COMMAND_BASE_FRAME_RATE = 60f;
    public const float FADE_COMMAND_DEFAULT_FADE_TIME = 0.3f;
    public const float BACKGROUND_PAN_TWEEN_DURATION = 2f;
    public const int TRANSITION_EFFECT_SORT_ORDER = 1250;
    public const float TRANSITION_COMMAND_ENV_VOLUE_FADE_TIME = 1f;
    public const string STORY_COMMAND_CAMERA_ZOOM_CHARA_ZOOM_LAYER_NAME = "Adventure";
    public const float STORY_COMMAND_BGCAMERA_ZOOM_MIN_RATE = 1f;
    public const float STORY_COMMAND_BGCAMERA_ZOOM_MAX_RATE = 1.5f;
    public const string STORY_COMMAND_BGM_STOP_CUE_NAME = "stop";
    public const float STORY_COMMAND_BGM_DEFAULT_FADE_TIME = 0.5f;
    public const float STORY_MENU_OUT_OF_SCREEN_ADD_POS = 2000f;
/*    public static readonly Dictionary<UnitDefine.eCharacterHeightNumber, List<float>> SCALE_COMMAND_DIFF_HEIGT_DIC = new Dictionary<UnitDefine.eCharacterHeightNumber, List<float>>()
    {
      {
        UnitDefine.eCharacterHeightNumber.HIGH,
        new List<float>() { 48f, 105f, 160f, 205f, 260f }
      },
      {
        UnitDefine.eCharacterHeightNumber.MIDDLE,
        new List<float>() { 48f, 96f, 144f, 192f, 240f }
      },
      {
        UnitDefine.eCharacterHeightNumber.LOW,
        new List<float>() { 48f, 80f, 125f, 165f, 200f }
      },
      {
        UnitDefine.eCharacterHeightNumber.SUPER_HIGH,
        new List<float>() { 48f, 110f, 180f, 230f, 280f }
      }
    };*/
    public const int DEFAULT_IGNORE_BGM_CHANNEL = -1;
    public const float DEFAULT_DARKING_TIME = 0.5f;

    public enum eStoryBackgroundType
    {
      NORMAL,
      HORIZONTAL,
      VERTICAL,
      MAX,
    }

    public enum eStoryStillType
    {
      NORMAL,
      VERTICAL,
    }

    public enum eTextFrameState
    {
      FADE_OUT,
      FADE_WAIT,
      FADE_IN,
    }

    public enum eWindowType
    {
      INVALID,
      NORMAL,
      FEELING,
      EMPHASIS,
      MAX,
    }
  }
}
