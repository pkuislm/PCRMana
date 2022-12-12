using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

namespace Elements
{

    public interface IParser
    {
        void ConvertStoryDataTextToBinary(ref string srcPath, ref string dstPath);

        void Init();
    }


    [ClassInterface(ClassInterfaceType.None)]
    [ComVisible(true)]
    [ComDefaultInterface(typeof (IParser))]
    public class Parser : IParser
    {
        private byte[] _binaryFileBuffer;
        private int _binaryFileBufferSize;
        private List<CommandStruct> _commandList;
        private StoryDataConfig _config;
        private Regex _headOnly;
        private Regex _tailOnly;
        private Regex _commentOut;
        private Regex _commentMultiOutHead;
        private Regex _commentMultiOutFoot;
        private Regex _commentMultiOut;
        private Regex _logParentheses;
        private string beforeStr = "";

        public static Parser Create()
        {
            Parser parser = new Parser();
            parser.Init();
            return parser;
        }

        public void Init()
        {
            _binaryFileBuffer = new byte[61440];
            _commandList = new List<CommandStruct>();
            _config = new StoryDataConfig();
            _headOnly = new Regex("^[\"](.*)");
            _tailOnly = new Regex("(.*)[\"]$");
            _commentOut = new Regex("//.*");
            _commentMultiOutHead = new Regex("/\\*.*");
            _commentMultiOutFoot = new Regex(".*\\*/");
            _commentMultiOut = new Regex("/\\*.*\\*/");
            _logParentheses = new Regex("log ([0-9]*) (\".*\") \"(.*)\"", RegexOptions.Compiled);
        }

        public string GetBinaryBufString() => BitConverter.ToString(_binaryFileBuffer, 0, _binaryFileBufferSize);

        private void AllocateFileBuffer(int size)
        {
            if (size <= _binaryFileBuffer.Length)
                return;
            _binaryFileBuffer = new byte[size];
        }

        public List<CommandStruct> ConvertBinaryToCommandList(byte[] byteData)
        {
            _binaryFileBuffer.Initialize();
            _commandList.Clear();
            _binaryFileBuffer = byteData;
            _binaryFileBufferSize = _binaryFileBuffer.Length;
            return Deserialize(ref _binaryFileBuffer, _binaryFileBufferSize);
        }

        public List<byte[]> LoadPlaneFile(ref string path)
        {
            using (StreamReader streamReader = new StreamReader(path, Encoding.UTF8))
            {
                bool flag = false;
                List<string> fileData = new List<string>();
                while (streamReader.Peek() >= 0)
                {
                    try
                    {
                        string input = _commentMultiOut.Replace(_commentOut.Replace(streamReader.ReadLine(), ""), "");
                        if (flag)
                        {
                            if (_commentMultiOutFoot.IsMatch(input))
                            {
                            input = _commentMultiOutFoot.Replace(input, "");
                            flag = false;
                            }
                            else
                            input = "";
                        }
                        else if (_commentMultiOutHead.IsMatch(input))
                        {
                            input = _commentMultiOutHead.Replace(input, "");
                            flag = true;
                        }
                        fileData.Add(input);
                    }
                    catch (Exception ex)
                    {
                        streamReader.Close();
                        throw ex;
                    }
                }
                streamReader.Close();
                return Serialize(ref fileData);
            }
        }

        public void WriteSerializeData(ref string path, ref List<byte[]> byteList)
        {
            FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
            int count = byteList.Count;
            for (int index = 0; index < count; ++index)
            {
                byte[] buffer = byteList[index];
                try
                {
                    fileStream.Write(buffer, 0, buffer.Length);
                }
                catch (Exception ex)
                {
                    fileStream.Close();
                    throw ex;
                }
            }
            fileStream.Close();
        }

        public void ConvertStoryDataTextToBinary(ref string srcPath, ref string dstPath)
        {
            List<byte[]> byteList = LoadPlaneFile(ref srcPath);
            try
            {
                WriteSerializeData(ref dstPath, ref byteList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<byte[]> Serialize(ref List<string> fileData)
        {
            List<byte[]> numArrayList = new List<byte[]>();
            int count = fileData.Count;
            for (int index = 0; index < count; ++index)
            {
                try
                {
                    byte[] numArray = SerializeLine(fileData[index]);
                    numArrayList.Add(numArray);
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("StoryData Convert Error {0} : {1}", (object) (index + 1), (object) ex), ex);
                }
            }
            return numArrayList;
        }

        private List<CommandStruct> Deserialize(ref byte[] byteList, int arraySize)
        {
            List<List<byte[]>> numArrayListList = SplitCommandByteRow(ref byteList, arraySize);
            int count = numArrayListList.Count;
            for (int index = 0; index < count; ++index)
            {
                CommandStruct commandStruct = DeserializeLine(numArrayListList[index]);
                if (commandStruct.Name != null)
                    _commandList.Add(commandStruct);
            }
            return _commandList;
        }

        private CommandStruct DeserializeLine(List<byte[]> commandByte)
        {
            CommandStruct commandStruct = new CommandStruct();
            commandStruct.Args = new List<string>();
            int int16 = (int) BitConverter.ToInt16(commandByte[0], 0);
            commandStruct.Name = GetCommandName(int16);
            int count = commandByte.Count;
            for (int index = 1; index < count; ++index)
            commandStruct.Args.Add(ConvertStringArgs(commandByte[index]));
            commandStruct.Category = GetCommandCategory(int16);
            commandStruct.Number = GetCommandNumber(int16);
            return commandStruct;
        }

        private List<List<byte[]>> SplitCommandByteRow(ref byte[] byteList, int arraySize)
        {
            List<List<byte[]>> numArrayListList = new List<List<byte[]>>();
            byte[] destinationArray1 = new byte[4];
            int num;
            for (int index = 2; index < arraySize; index = num + 2)
            {
                List<byte[]> numArrayList = new List<byte[]>();
                byte[] destinationArray2 = new byte[2];
                Array.Copy((Array) byteList, index - 2, (Array) destinationArray2, 0, 2);
                Array.Reverse((Array) destinationArray2);
                numArrayList.Add(destinationArray2);
                int sourceIndex = index;
                while (true)
                {
                    Array.Copy((Array) byteList, sourceIndex, (Array) destinationArray1, 0, 4);
                    Array.Reverse((Array) destinationArray1);
                    int int32 = BitConverter.ToInt32(destinationArray1, 0);
                    if (int32 != 0)
                    {
                        byte[] destinationArray3 = new byte[int32];
                        Array.Copy((Array) byteList, sourceIndex + 4, (Array) destinationArray3, 0, int32);
                        numArrayList.Add(destinationArray3);
                        sourceIndex += 4 + int32;
                    }
                    else
                        break;
                }
                num = sourceIndex + 4;
                numArrayListList.Add(numArrayList);
            }
            return numArrayListList;
        }

        private byte[] ByteListAppend(ref byte[] baseList, ref byte[] addList)
        {
            int length1 = baseList.Length;
            int length2 = addList.Length;
            byte[] destinationArray = new byte[length1 + length2];
            Array.Copy((Array) baseList, (Array) destinationArray, length1);
            Array.Copy((Array) addList, 0, (Array) destinationArray, length1, length2);
            return destinationArray;
        }

        private byte[] SerializeLine(string commandLine)
        {
            commandLine = _logParentheses.Replace(commandLine, "log $1 $2 \"（$3）\"");
            List<string> stringList1 = SplitString(ref commandLine);
            List<List<string>> stringListList = new List<List<string>>();
            int count1 = stringList1.Count;
            int index1 = 0;
            for (int index2 = 0; index2 < count1; ++index2)
            {
                if (stringList1[index2] == "<")
                {
                    List<string> range = stringList1.GetRange(index1, index2 - index1);
                    index1 = index2 + 1;
                    stringListList.Add(range);
                }
            }
            if (index1 < count1)
            {
                List<string> range = stringList1.GetRange(index1, count1 - index1);
                stringListList.Add(range);
            }
            byte[] baseList = new byte[0];
            byte[] bytes1 = BitConverter.GetBytes(0);
            int count2 = stringListList.Count;
            for (int index3 = 0; index3 < count2; ++index3)
            {
                List<string> stringList2 = stringListList[index3];
                byte[] addList1 = ConvertByteCommand(stringList2[0]);
                baseList = ByteListAppend(ref baseList, ref addList1);
                int count3 = stringList2.Count;
                string name = stringList2[0];
                int commandIndex = _config.GetCommandIndex(ref name);
                int num = count3 - 1;
                if (commandIndex == -1)
                {
                    if (num > 0 || name != "")
                        throw new Exception("不正なコマンドです : " + name);
                }
                else
                {
                    int commandMinArgCount = _config.GetCommandMinArgCount(commandIndex);
                    int commandMaxArgCount = _config.GetCommandMaxArgCount(commandIndex);
                    if (num < commandMinArgCount || num > commandMaxArgCount)
                        throw new ArgumentOutOfRangeException("直前のコマンド" + beforeStr + "\nエラーコマンド名 : " + name + ",引数の数が合いません。[mim " + (object) commandMinArgCount + "] [max " + (object) commandMaxArgCount + "] [now " + (object) num + "]");
                    for (int index4 = 1; index4 < count3; ++index4)
                    {
                    byte[] addList2 = ConvertByteArgs(stringList2[index4]);
                    byte[] bytes2 = BitConverter.GetBytes(addList2.Length);
                    Array.Reverse((Array) bytes2);
                    baseList = ByteListAppend(ref baseList, ref bytes2);
                    baseList = ByteListAppend(ref baseList, ref addList2);
                    }
                    baseList = ByteListAppend(ref baseList, ref bytes1);
                }
            }
            if (stringList1.IndexOf("print") >= 0 || stringList1.IndexOf("double") >= 0)
            {
                byte[] addList = ConvertByteCommand("touch");
                baseList = ByteListAppend(ref baseList, ref addList);
                baseList = ByteListAppend(ref baseList, ref bytes1);
            }
            beforeStr = commandLine;
            return baseList;
        }

        private List<string> SplitString(ref string commandLine)
        {
            List<string> stringList1 = new List<string>();
            List<bool> boolList = new List<bool>();
            int length = commandLine.Length;
            int startIndex1 = 0;
            for (int startIndex2 = 0; startIndex2 < length; ++startIndex2)
            {
                string str1 = commandLine.Substring(startIndex2, 1);
                int index1 = boolList.Count - 1;
                if (str1 == " " && boolList.Count == 0)
                {
                    string str2 = commandLine.Substring(startIndex1, startIndex2 - startIndex1);
                    stringList1.Add(str2);
                    startIndex1 = startIndex2 + 1;
                }
                else if (str1 == "\"")
                {
                    if (boolList.Count == 0)
                        boolList.Add(true);
                    else if (!boolList[index1])
                        boolList.Add(true);
                    else
                        boolList.RemoveAt(index1);
                }
                else if (str1 == "<")
                {
                    string str3 = commandLine.Substring(startIndex1, startIndex2 - startIndex1);
                    stringList1.Add(str3);
                    startIndex1 = startIndex2 + 1;
                    stringList1.Add("<");
                    boolList.Add(false);
                }
                else if (str1 == ">")
                {
                    if (!boolList[index1])
                        boolList.RemoveAt(index1);
                    string commandLine1 = commandLine.Substring(startIndex1, startIndex2 - startIndex1);
                    List<string> stringList2 = SplitString(ref commandLine1);
                    int count1 = stringList2.Count;
                    for (int index2 = 0; index2 < count1; ++index2)
                        stringList1.Add(stringList2[index2]);
                    stringList1.Add("<");
                    int count2 = stringList1.Count;
                    for (int index3 = 0; index3 < count2 && stringList1[index3] != "<"; ++index3)
                    {
                        string str4 = stringList1[index3];
                        stringList1.Add(str4);
                    }
                    stringList1.RemoveAt(stringList1.Count - 1);
                    startIndex1 = startIndex2 + 1;
                }
            }
            if (startIndex1 < length)
            {
                string str = commandLine.Substring(startIndex1, length - startIndex1);
                stringList1.Add(str);
            }
            int count = stringList1.Count;
            for (int index = 0; index < count; ++index)
            {
                if (stringList1[index] == "print" || stringList1[index] == "double")
                {
                    string str = stringList1[index + 2];
                    if (str.Length == 0 || str.Length == 1 && str == "\"")
                    {
                        stringList1.RemoveRange(index, 3);
                        if (stringList1.Count > index && stringList1[index] == "<")
                            stringList1.RemoveAt(index);
                        count = stringList1.Count;
                    }
                }
                else
                {
                    string str = _tailOnly.Replace(_headOnly.Replace(stringList1[index], "$1"), "$1");
                    stringList1[index] = str;
                }
            }
            stringList1.Remove("");
            return stringList1;
        }

        private int GetCommandIndex(ref string command) => _config.GetCommandIndex(ref command);

        private string GetCommandName(int index) => _config.GetCommandName(index);

        private CommandCategory GetCommandCategory(int index) => _config.GetCommandCategory(index);

        private CommandNumber GetCommandNumber(int index) => _config.GetCommandNumber(index);

        private byte[] ConvertByteCommand(string command)
        {
            byte[] bytes = BitConverter.GetBytes(GetCommandIndex(ref command));
            Array.Resize<byte>(ref bytes, 2);
            Array.Reverse((Array) bytes);
            return bytes;
        }

        private byte[] ConvertByteArgs(string args)
        {
            Encoding utF8 = Encoding.UTF8;
            byte[] bytes = utF8.GetBytes(Convert.ToBase64String(utF8.GetBytes(args)));
            BitInverse(ref bytes);
            return bytes;
        }

        private string ConvertStringArgs(byte[] byteArgs)
        {
            BitInverse(ref byteArgs);
            return Encoding.UTF8.GetString(Convert.FromBase64String(Encoding.UTF8.GetString(byteArgs)));
        }

        private void BitInverse(ref byte[] byteList)
        {
            int length = byteList.Length;
            for (int index = 0; index < length; ++index)
            {
                if (index % 3 == 0)
                    byteList[index] = BitConverter.GetBytes((int) ~byteList[index])[0];
            }
        }
    }
}
