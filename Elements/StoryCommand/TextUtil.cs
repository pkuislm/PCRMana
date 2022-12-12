// Decompiled with JetBrains decompiler
// Type: Elements.TextUtil
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A7E03188-4A33-4E31-B2AA-6FF711CC1BCD
// Assembly location: C:\Users\ASUS\Documents\Tencent Files\1668911954\FileRecv\MobileFile\ksdumper-mod\princessconnectredive_11ED3000.dll

using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Elements
{
    public static class TextUtil
    {
        private const int MAX_DAYS = 9999;
        private static readonly string[] HAN_KATAKANA_TABLE = new string[120]
        {
            "ｶﾞ",
            "ｷﾞ",
            "ｸﾞ",
            "ｹﾞ",
            "ｺﾞ",
            "ｻﾞ",
            "ｼﾞ",
            "ｽﾞ",
            "ｾﾞ",
            "ｿﾞ",
            "ﾀﾞ",
            "ﾁﾞ",
            "ﾂﾞ",
            "ﾃﾞ",
            "ﾄﾞ",
            "ﾊﾞ",
            "ﾋﾞ",
            "ﾌﾞ",
            "ﾍﾞ",
            "ﾎﾞ",
            "ｳﾞ",
            "ﾜﾞ",
            "ｲﾞ",
            "ｴﾞ",
            "ｦﾞ",
            "ﾊﾟ",
            "ﾋﾟ",
            "ﾌﾟ",
            "ﾍﾟ",
            "ﾎﾟ",
            "カﾞ",
            "キﾞ",
            "クﾞ",
            "ケﾞ",
            "コﾞ",
            "サﾞ",
            "シﾞ",
            "スﾞ",
            "セﾞ",
            "ソﾞ",
            "タﾞ",
            "チﾞ",
            "ツﾞ",
            "テﾞ",
            "トﾞ",
            "ハﾞ",
            "ヒﾞ",
            "フﾞ",
            "ヘﾞ",
            "ホﾞ",
            "ウﾞ",
            "ワﾞ",
            "イﾞ",
            "エﾞ",
            "ヲﾞ",
            "ハﾟ",
            "ヒﾟ",
            "フﾟ",
            "ヘﾟ",
            "ホﾟ",
            "ｱ",
            "ｲ",
            "ｳ",
            "ｴ",
            "ｵ",
            "ｶ",
            "ｷ",
            "ｸ",
            "ｹ",
            "ｺ",
            "ｻ",
            "ｼ",
            "ｽ",
            "ｾ",
            "ｿ",
            "ﾀ",
            "ﾁ",
            "ﾂ",
            "ﾃ",
            "ﾄ",
            "ﾅ",
            "ﾆ",
            "ﾇ",
            "ﾈ",
            "ﾉ",
            "ﾊ",
            "ﾋ",
            "ﾌ",
            "ﾍ",
            "ﾎ",
            "ﾏ",
            "ﾐ",
            "ﾑ",
            "ﾒ",
            "ﾓ",
            "ﾔ",
            "ﾕ",
            "ﾖ",
            "ﾗ",
            "ﾘ",
            "ﾙ",
            "ﾚ",
            "ﾛ",
            "ﾜ",
            "ｦ",
            "ﾝ",
            "ｴ",
            "ｧ",
            "ｨ",
            "ｩ",
            "ｪ",
            "ｫ",
            "ｬ",
            "ｭ",
            "ｮ",
            "ｯ",
            "ﾞ",
            "ﾟ",
            "､",
            "｡"
        };
        private static readonly string[] ZEN_KATAKANA_TABLE = new string[120]
        {
            "ガ",
            "ギ",
            "グ",
            "ゲ",
            "ゴ",
            "ザ",
            "ジ",
            "ズ",
            "ゼ",
            "ゾ",
            "ダ",
            "ヂ",
            "ヅ",
            "デ",
            "ド",
            "バ",
            "ビ",
            "ブ",
            "ベ",
            "ボ",
            "ヴ",
            "ヷ",
            "ヸ",
            "ヹ",
            "ヺ",
            "パ",
            "ピ",
            "プ",
            "ペ",
            "ポ",
            "ガ",
            "ギ",
            "グ",
            "ゲ",
            "ゴ",
            "ザ",
            "ジ",
            "ズ",
            "ゼ",
            "ゾ",
            "ダ",
            "ヂ",
            "ヅ",
            "デ",
            "ド",
            "バ",
            "ビ",
            "ブ",
            "ベ",
            "ボ",
            "ヴ",
            "ヷ",
            "ヸ",
            "ヹ",
            "ヺ",
            "パ",
            "ピ",
            "プ",
            "ペ",
            "ポ",
            "ア",
            "イ",
            "ウ",
            "エ",
            "オ",
            "カ",
            "キ",
            "ク",
            "ケ",
            "コ",
            "サ",
            "シ",
            "ス",
            "セ",
            "ソ",
            "タ",
            "チ",
            "ツ",
            "テ",
            "ト",
            "ナ",
            "ニ",
            "ヌ",
            "ネ",
            "ノ",
            "ハ",
            "ヒ",
            "フ",
            "ヘ",
            "ホ",
            "マ",
            "ミ",
            "ム",
            "メ",
            "モ",
            "ヤ",
            "ユ",
            "ヨ",
            "ラ",
            "リ",
            "ル",
            "レ",
            "ロ",
            "ワ",
            "ヲ",
            "ン",
            "ヱ",
            "ァ",
            "ィ",
            "ゥ",
            "ェ",
            "ォ",
            "ャ",
            "ュ",
            "ョ",
            "ッ",
            "゛",
            "゜",
            "、",
            "。"
        };
        public const string STRING_HALF_WIDTH_SPACE = " ";
        public const string STRING_NEW_LINE = "\n";
        private const string BBCODE_PATTERN = "(\\[[a-z0-9\\/\\-]*\\])";
        public static readonly string ILLEGAL_CHARACTERS_HEAD = Regex.Escape("､、｡。)）］」』}｝】,〕〉＞》≫〟’”.・:; 　!?！？…ー～－☆★♪ヽヾぁぃぅぇぉっゃゅょゎァィゥェォッャュョヮヵヶ‐＝゛゜％+＋々");
        private static readonly string ILLEGAL_CHARACTERS_TAIL = Regex.Escape("(（［{｛〔〈＜《≪「『【〝‘“×");
        private static readonly string LINE_HEAD_WRAP_PATTERN = string.Format("^{0}*[{1}]", (object) "(\\[[a-z0-9\\/\\-]*\\])", (object) ILLEGAL_CHARACTERS_HEAD);
        private static readonly string LINE_TRAIL_WRAP_PATTERN = string.Format("[{0}]{1}*$", (object) ILLEGAL_CHARACTERS_TAIL, (object) "(\\[[a-z0-9\\/\\-]*\\])");
        private static readonly string LINE_TRAIL_IGNORE_PATTERN = string.Format("[{0}]*{1}*$", (object) ILLEGAL_CHARACTERS_TAIL, (object) "(\\[[a-z0-9\\/\\-]*\\])");
        private static readonly string LINE_HEAD_TRAIL_IGNORE_PATTERN = string.Format("[{0}]*.[{1}]*{2}*$", (object) ILLEGAL_CHARACTERS_TAIL, (object) ILLEGAL_CHARACTERS_HEAD, (object) "(\\[[a-z0-9\\/\\-]*\\])");
        private static StringBuilder stringBuilder = new StringBuilder();

        public static string ReplaceNewLine(this string _value) => _value.ReplaceNewLineWithString("\n");

        public static string ReplaceNewLineWithString(this string _value, string _replaceString)
        {
            if (_value.Contains("/\\n"))
            return _value.Replace("/\\n", _replaceString);
            return _value.Contains("\\n") ? _value.Replace("\\n", _replaceString) : _value;
        }

        public static string DeleteNewLine(this string _value)
        {
            if (_value.Contains("/\\n"))
            return _value.Replace("/\\n", "");
            if (_value.Contains("\\n"))
            return _value.Replace("\\n", "");
            return _value.Contains("\n") ? _value.Replace("\n", "") : _value;
        }

        public static string ConvertHanKanaToZenKana(string _srcString)
        {
            if (string.IsNullOrEmpty(_srcString))
            return "";
            for (int index = 0; index < HAN_KATAKANA_TABLE.Length; ++index)
            _srcString = _srcString.Replace(HAN_KATAKANA_TABLE[index], ZEN_KATAKANA_TABLE[index]);
            return _srcString;
        }

       /* public static string CorrectIllegalCharactersForUILabel(CustomUILabel _label)
        {
            string text = _label.text;
            if (_label.overflowMethod == UILabel.Overflow.ResizeFreely || _label.overflowMethod == UILabel.Overflow.ScalingWidth || text.IsNullOrEmpty() || ILLEGAL_CHARACTERS_HEAD.IsNullOrEmpty() && ILLEGAL_CHARACTERS_TAIL.IsNullOrEmpty())
            return text;
            string final1 = string.Empty;
            if (!_label.Wrap(text, out final1))
            final1 = text;
            if (final1.Equals(text))
            return text;
            List<string> stringList = new List<string>(final1.Split('\n'));
            string input1 = string.Empty;
            for (int index = 0; index < stringList.Count; ++index)
            {
            string str1 = stringList[index];
            string str2 = index < stringList.Count - 1 ? stringList[index + 1] : string.Empty;
            if (Regex.Match(str1, LINE_TRAIL_WRAP_PATTERN).Success)
            {
                Match match1 = Regex.Match(str1, LINE_TRAIL_IGNORE_PATTERN);
                if (match1.Success)
                {
                string input2 = str1.Substring(match1.Index, match1.Length);
                if (str2 == string.Empty)
                {
                    Match match2 = Regex.Match(input2, LINE_TRAIL_WRAP_PATTERN);
                    if (!match2.Success || input2.Length != match2.Length)
                    stringList.Add(str2 = string.Empty);
                    else
                    break;
                }
                str2 = str2.Insert(0, input2);
                str1 = str1.Substring(0, match1.Index);
                }
            }
            if (input1 != string.Empty)
            {
                if (Regex.Match(str1, LINE_HEAD_WRAP_PATTERN).Success)
                {
                Match match = Regex.Match(input1, LINE_HEAD_TRAIL_IGNORE_PATTERN);
                if (match.Success && match.Index > 0)
                {
                    str1 = str1.Insert(0, input1.Substring(match.Index, match.Length));
                    input1 = input1.Substring(0, match.Index);
                }
                }
                if (str1.Length > 1)
                {
                string final2 = string.Empty;
                if (!_label.Wrap(str1, out final2))
                    final2 = str1;
                if (final2.Contains("\n"))
                {
                    int length = final2.LastIndexOf("\n");
                    if (length > 0)
                    {
                    if (str2 == string.Empty)
                        stringList.Add(str2 = string.Empty);
                    str2 = str2.Insert(0, final2.Substring(length + 1));
                    str1 = final2.Substring(0, length);
                    }
                }
                }
            }
            if (input1 != string.Empty)
                stringList[index - 1] = input1;
            if (str2 != string.Empty)
                stringList[index + 1] = str2;
            stringList[index] = input1 = str1;
            }
            stringBuilder.Length = 0;
            int index1 = 0;
            for (int count = stringList.Count; index1 < count; ++index1)
            {
            stringBuilder.Append(stringList[index1]);
            if (index1 < count - 1)
                stringBuilder.Append("\n");
            }
            if (_label.overflowMethod == UILabel.Overflow.ClampContent && _label.overflowEllipsis)
            {
            int num1 = _label.height / (_label.fontSize + _label.spacingY);
            string _s = stringBuilder.ToString();
            int num2 = countChar(_s, '\n');
            string str = "";
            if (num1 <= num2)
            {
                string[] strArray = _s.Split('\n');
                for (int index2 = 0; index2 < strArray.Length; ++index2)
                {
                if (num1 > index2)
                    str = str + strArray[index2] + "\n";
                }
                int num3 = str.LastIndexOf('\n');
                return str.Substring(0, num3 - 1) + "…";
            }
            }
            return stringBuilder.ToString();
        }*/

        private static int countChar(string _s, char _c) => _s.Length - _s.Replace(_c.ToString(), "").Length;

        public static string DeleteVersionText(string _text)
        {
            string str = _text;
            int length1 = str.IndexOf("（");
            if (length1 > 0)
            return str.Substring(0, length1);
            int length2 = str.IndexOf("(");
            return length2 > 0 ? str.Substring(0, length2) : str;
        }

        public static string DeleteColorCode(string _text)
        {
            string str1 = string.Empty;
            for (int index = 0; index < _text.Length; ++index)
            {
            char ch = _text[index];
            if (ch.Equals('['))
            {
                int num = _text.IndexOf(']', index);
                if (num > 0)
                index = num + 1;
            }
            if (index < _text.Length)
            {
                string str2 = str1;
                ch = _text[index];
                string str3 = ch.ToString();
                str1 = str2 + str3;
            }
            else
                break;
            }
            return str1;
        }

        public static string ReplaceLast(this string _source, string _oldValue, string _newValue)
        {
            int startIndex = _source.LastIndexOf(_oldValue);
            return startIndex == -1 ? _source : _source.Remove(startIndex, _oldValue.Length).Insert(startIndex, _newValue);
        }
    }
}
