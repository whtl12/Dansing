using UnityEngine;
using System.Collections;

public partial class GameDefine : MonoBehaviour
{


 
    #region semifixed
    /// <summary>
    /// 다이나믹 스크롤 활성화 여부.
    /// </summary>
    public static bool DynamicScrollOn = true;

    /// <summary>
    /// 테스트를 위해 항상 패치를 다운 받는다. 차후 서비스 시 반드시 false 로 변경해야 됨.
    /// </summary>
    public static bool AlwaysDownloadPatchFile = false;
    

    /// <summary>
    /// 구글 독스 테이블(게임 데이터) 암호화 여부.
    /// </summary>
    public static bool isGoogleDocsEncrypted = true;
    public static bool isServerPacketEncrypted = true;

    public static string StageLoadingIndicatorName = "StageLoadingIndicator";
    public static string StageBlindName = "StageBlind";

    public static float MaxWaitingTime_ConnectPatchServer = 10f;

    public static float SendPacketToServer_DelayTime = 0.5f;

   // public static string SerializeKey = "8ac0f0c039c77d2c3a97d2cd447237dc";
   // public static string SerializeIV = "514365216be9a3cb6fbcfac1f888f6ba";

    public static int kakaoGetInvitableFriendLimitNumber = 50;

    public static bool isTableEncodedAsJson = true;
  
    public static bool WhetherLoadUIABWhenOutGameLoading = false;
    public static bool WhetherLoadObjectABWhenOutGameLoading = false;
    public static bool WhetherUseResourceScene = true;
    public static bool WhetherDeleteDocsTxtFileOfResourcesFolder = false;
    public static bool isAbleToPay = true;

    public static string GoogleSheetKey
    {
        get
        {
            return "1juWuj8kuhx4NCRtRgNP7ZPTZF4BqDfphJLENEYkACqo";
        }
    }
    public static string GoogleSheetBaseUrl = "https://docs.google.com/spreadsheet/pub?key={0}&single=true&output=csv&gid={1}";
    #endregion
}
