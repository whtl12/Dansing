//using UnityEngine;
//using System.Collections;

//public class GamePath
//{



//    public static string GoogleSheetBaseUrl = "https://docs.google.com/spreadsheet/pub?key={0}&single=true&output=csv&gid={1}";

//    public static string _gamebasedataFileName = "_patchFileVersion.xml";


//    public static string GoogleSheetKey
//    {
//        get
//        {
//            return "1juWuj8kuhx4NCRtRgNP7ZPTZF4BqDfphJLENEYkACqo";
//        }
//    }


//    public static string GetStreamingAssetForder(bool attachFileAppendSuffix = true)
//    {
//        string filePath = Application.streamingAssetsPath;
//        if ((RuntimePlatform.WindowsEditor == Application.platform || RuntimePlatform.WindowsPlayer == Application.platform
//            || RuntimePlatform.OSXEditor == Application.platform || RuntimePlatform.IPhonePlayer == Application.platform) && attachFileAppendSuffix)
//        {
//            filePath = "file://" + filePath;
//        }

//        filePath = AppendSuffix(filePath, '/');

//        return filePath;

//    }

//    /// <summary>
//    /// 기기에서 패치 파일을 저장하는 저장소 Path 반환.
//    /// </summary>
//    /// <param name="bWWWPath"></param>
//    /// <returns></returns>
//    public static string getPatchDataPath(bool bWWWPath)
//    {
//        string filePath = "";
//        switch (Application.platform)
//        {
//            case RuntimePlatform.Android:
//            case RuntimePlatform.IPhonePlayer:
//                {
//                    filePath = Application.persistentDataPath;
//                    filePath = AppendSuffix(filePath, '/');
//                }
//                break;
//            default:
//                {
//                    filePath = Application.dataPath;
//                    int nIdx = filePath.LastIndexOf("Assets");
//                    if (nIdx > 0)
//                        filePath = filePath.Substring(0, nIdx);
//                    filePath = AppendSuffix(filePath, '/');
//                    filePath = filePath + "PatchFiles/";
//                }
//                break;

//        }

//        switch (Application.platform)
//        {
//            case RuntimePlatform.WindowsPlayer:
//                filePath += "Window/";
//                break;
//            case RuntimePlatform.Android:
//            case RuntimePlatform.WindowsEditor:
//            case RuntimePlatform.OSXEditor:
//                filePath += "Android/";
//                break;
//            case RuntimePlatform.IPhonePlayer:
//                filePath += "iOS/";
//                break;
//            default:
//                filePath += "Android/";
//                break;
//        }

//        if (bWWWPath)
//            filePath = "file://" + filePath;
//        return filePath;
//    }

//    /// <summary>
//    /// 기기에서 패치 파일을 저장하는 저장소 Path 반환.
//    /// </summary>
//    /// <param name="bWWWPath"></param>
//    /// <returns></returns>
//    public static string getPatchDataPath(bool bWWWPath, RuntimePlatform _platform)
//    {
//        string filePath = "";
//        switch (Application.platform)
//        {
//            case RuntimePlatform.Android:
//            case RuntimePlatform.IPhonePlayer:
//                {
//                    filePath = Application.persistentDataPath;
//                    filePath = AppendSuffix(filePath, '/');
//                }
//                break;
//            default:
//                {
//                    filePath = Application.dataPath;
//                    int nIdx = filePath.LastIndexOf("Assets");
//                    if (nIdx > 0)
//                        filePath = filePath.Substring(0, nIdx);
//                    filePath = AppendSuffix(filePath, '/');
//                    filePath = filePath + "PatchFiles/";
//                }
//                break;

//        }

//        switch (_platform)
//        {
//            case RuntimePlatform.WindowsPlayer:
//                filePath += "Window/";
//                break;
//            case RuntimePlatform.Android:
//            case RuntimePlatform.WindowsEditor:
//            case RuntimePlatform.OSXEditor:
//                filePath += "Android/";
//                break;
//            case RuntimePlatform.IPhonePlayer:
//                filePath += "iOS/";
//                break;
//            default:
//                filePath += "Android/";
//                break;
//        }

//        if (bWWWPath)
//            filePath = "file://" + filePath;
//        return filePath;
//    }

//    public static string getPatchDataXMLPath(bool bWWWPath, RuntimePlatform _platform)
//    {
//        string filePath = "";

//        filePath = Application.dataPath;
//        int nIdx = filePath.LastIndexOf("Assets");
//        if (nIdx > 0)
//            filePath = filePath.Substring(0, nIdx);
//        filePath = AppendSuffix(filePath, '/');
//        filePath = filePath + "PatchFileXML/";


//        switch (_platform)
//        {
//            case RuntimePlatform.WindowsPlayer:
//                filePath += "Window/";
//                break;
//            case RuntimePlatform.Android:
//            case RuntimePlatform.WindowsEditor:
//            case RuntimePlatform.OSXEditor:
//                filePath += "Android/";
//                break;
//            case RuntimePlatform.IPhonePlayer:
//                filePath += "iOS/";
//                break;
//            default:
//                filePath += "Android/";
//                break;
//        }

//        if (bWWWPath)
//            filePath = "file://" + filePath;
//        return filePath;
//    }

//    public static string AppendSuffix(string _str, char _suffix)
//    {
//        if (_str[_str.Length - 1] != _suffix)
//            _str += _suffix;

//        return _str;
//    }

//}
