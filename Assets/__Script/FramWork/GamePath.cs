using UnityEngine;
using System.Collections;

public class GamePath
{
    public enum EnumServerType
    {
        Dev = 0,
        KrLive = 1
    }

#if DEVLOGIN
    public const string WEB_SERVER_DOMAIN = "http://devadvtimeapp.tangentkorea.com/";
    public const string PATCH_SERVER_DOMAIN = "http://devadvtimeimg.tangentkorea.com/";
    public const string PATCH_DEV_SERVER_DOMAIN = "http://devadvtimeimg.tangentkorea.com/";
#else
    public const string WEB_SERVER_DOMAIN = "http://advtimeapp.tangentkorea.com/";
    public const string PATCH_SERVER_DOMAIN = "http://advtimeimg.tangentkorea.com/";
    //public const string WEB_SERVER_DOMAIN = "http://devadvtimeapp.tangentkorea.com/";
    //public const string PATCH_SERVER_DOMAIN = "http://devadvtimeimg.tangentkorea.com/";
    public const string PATCH_DEV_SERVER_DOMAIN = "http://devadvtimeimg.tangentkorea.com/";
#endif
    public static string GoogleSheetBaseUrl = "https://docs.google.com/spreadsheet/pub?key={0}&single=true&output=csv&gid={1}";

    public static string _gamebasedataFileName = "_patchFileVersion.xml";

    public static int ServerVersion
    {
        get
        {
            if (GameDefine.Version_Client == 1)
            {
                return 8;
            }
            else if (GameDefine.Version_Client == 3)
            {
                return 9;
            }
            else if (GameDefine.Version_Client == 4)
            {
                return 10;
            }

            return 8;
        }
    }

    public static string GoogleSheetKey
    {
        get
        {
            if (GameDefine.Version_Client == 1)
            {
                return "1yH4Zxk9jtxMMjieuNiFioyNkPdYatsDlOKrfl5rk8Zg";
            }
            else if (GameDefine.Version_Client == 3)
            {
                return "1-JOWEJ-mqXzyIkgZn5Djv_TnNYEQAXzlHjAX6BHAFuE";
            }
            else if (GameDefine.Version_Client == 4)
            {
                return "1eIpu__C9bbo6OD4_se2l3WO9BRINBruG52Vs4a7Ed18";
            }

            return "1yH4Zxk9jtxMMjieuNiFioyNkPdYatsDlOKrfl5rk8Zg";
        }
    }

    public static string ServerBaseUrl = string.Format("{0}v{1}/", WEB_SERVER_DOMAIN, ServerVersion);

    public static string MarketURL_AOS = "market://details?id=com.tangent.adventuretime";
    public static string MarketURL_iOS = "https://itunes.apple.com/app/at-run/id1072258175";

    // 카카오 이용약관, 정보수집 동의 URL
    public static string KakaoAccessTermURL = "http://devadvtimeapp.tangentkorea.com/adv_management/policy.php";
    public static string KakaoInformationAgreementURL = "http://devadvtimeapp.tangentkorea.com/adv_management/policy.php";
    public static string KakaoCustomerCenterURL = "http://devadvtimeapp.tangentkorea.com/adv_management/index.php";
    public static string FacebookInvitingImageURL = "http://advtimeimg.tangentkorea.com/facebook_img/at_facebook_ico.jpg";
    public static string FacebookURL = "https://www.facebook.com/AdventureRunGame/";
    public static string BuildNumberFileName = "buildNumber";

    #region Static Func
    /// <summary>
    /// 패치 파일 서버 경로 반환.
    /// </summary>
    /// <returns></returns>
    public static string getFileServer(bool replaceDomainIfDevServer = false)
    {
        string url = PATCH_SERVER_DOMAIN + "patch/";

        if (replaceDomainIfDevServer )
            url = PATCH_DEV_SERVER_DOMAIN + "patch/";

        switch (Application.platform)
        {
            case RuntimePlatform.WindowsPlayer:
                url += "Window/";
                break;
            case RuntimePlatform.Android:
            case RuntimePlatform.WindowsEditor:
            case RuntimePlatform.OSXEditor:
                url += "Android/";
                break;
            case RuntimePlatform.IPhonePlayer:
                url += "iOS/";
                break;
            default:
                url += "Android/";
                break;
        }

        url += GameDefine.Version_Client.ToString();
        url += "/";

        return url;
    }

    public static string GetStreamingAssetForder(bool attachFileAppendSuffix = true)
    {
        string filePath = Application.streamingAssetsPath;
        if ((RuntimePlatform.WindowsEditor == Application.platform || RuntimePlatform.WindowsPlayer == Application.platform
            || RuntimePlatform.OSXEditor == Application.platform || RuntimePlatform.IPhonePlayer == Application.platform) && attachFileAppendSuffix)
        {
            filePath = "file://" + filePath;
        }

        filePath = AppendSuffix(filePath, '/');

        return filePath;

    }

    /// <summary>
    /// 기기에서 패치 파일을 저장하는 저장소 Path 반환.
    /// </summary>
    /// <param name="bWWWPath"></param>
    /// <returns></returns>
    public static string getPatchDataPath(bool bWWWPath)
    {
        string filePath = "";
        switch (Application.platform)
        {
            case RuntimePlatform.Android:
            case RuntimePlatform.IPhonePlayer:
                {
                    filePath = Application.persistentDataPath;
                    filePath = AppendSuffix(filePath, '/');
                }
                break;
            default:
                {
                    filePath = Application.dataPath;
                    int nIdx = filePath.LastIndexOf("Assets");
                    if (nIdx > 0)
                        filePath = filePath.Substring(0, nIdx);
                    filePath = AppendSuffix(filePath, '/');
                    filePath = filePath + "PatchFiles/";
                }
                break;

        }

        switch (Application.platform)
        {
            case RuntimePlatform.WindowsPlayer:
                filePath += "Window/";
                break;
            case RuntimePlatform.Android:
            case RuntimePlatform.WindowsEditor:
            case RuntimePlatform.OSXEditor:
                filePath += "Android/";
                break;
            case RuntimePlatform.IPhonePlayer:
                filePath += "iOS/";
                break;
            default:
                filePath += "Android/";
                break;
        }

        if (bWWWPath)
            filePath = "file://" + filePath;
        return filePath;
    }

    /// <summary>
    /// 기기에서 패치 파일을 저장하는 저장소 Path 반환.
    /// </summary>
    /// <param name="bWWWPath"></param>
    /// <returns></returns>
    public static string getPatchDataPath(bool bWWWPath, RuntimePlatform _platform)
    {
        string filePath = "";
        switch (Application.platform)
        {
            case RuntimePlatform.Android:
            case RuntimePlatform.IPhonePlayer:
                {
                    filePath = Application.persistentDataPath;
                    filePath = AppendSuffix(filePath, '/');
                }
                break;
            default:
                {
                    filePath = Application.dataPath;
                    int nIdx = filePath.LastIndexOf("Assets");
                    if (nIdx > 0)
                        filePath = filePath.Substring(0, nIdx);
                    filePath = AppendSuffix(filePath, '/');
                    filePath = filePath + "PatchFiles/";
                }
                break;

        }

        switch (_platform)
        {
            case RuntimePlatform.WindowsPlayer:
                filePath += "Window/";
                break;
            case RuntimePlatform.Android:
            case RuntimePlatform.WindowsEditor:
            case RuntimePlatform.OSXEditor:
                filePath += "Android/";
                break;
            case RuntimePlatform.IPhonePlayer:
                filePath += "iOS/";
                break;
            default:
                filePath += "Android/";
                break;
        }

        if (bWWWPath)
            filePath = "file://" + filePath;
        return filePath;
    }

    public static string getPatchDataXMLPath(bool bWWWPath, RuntimePlatform _platform)
    {
        string filePath = "";

        filePath = Application.dataPath;
        int nIdx = filePath.LastIndexOf("Assets");
        if (nIdx > 0)
            filePath = filePath.Substring(0, nIdx);
        filePath = AppendSuffix(filePath, '/');
        filePath = filePath + "PatchFileXML/";


        switch (_platform)
        {
            case RuntimePlatform.WindowsPlayer:
                filePath += "Window/";
                break;
            case RuntimePlatform.Android:
            case RuntimePlatform.WindowsEditor:
            case RuntimePlatform.OSXEditor:
                filePath += "Android/";
                break;
            case RuntimePlatform.IPhonePlayer:
                filePath += "iOS/";
                break;
            default:
                filePath += "Android/";
                break;
        }

        if (bWWWPath)
            filePath = "file://" + filePath;
        return filePath;
    }

    public static string AppendSuffix(string _str, char _suffix)
    {
        if (_str[_str.Length - 1] != _suffix)
            _str += _suffix;

        return _str;
    }
    #endregion
}
