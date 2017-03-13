using UnityEngine;
using System.Collections;

public partial class GameDefine : MonoBehaviour
{
    #region enum
    public enum eBuildType
    {
        None,
        GSP_NoSpecificPlatform,
    }
    #endregion

    /// <summary>
    /// 항상 온라인 모드 로그인 여부 (카톡 x )
    /// </summary>
    public static bool OnlineModeWithoutSelectButton = true;


    /// <summary>
    /// 상용화 시 꼭 0으로 변경해야 됨.
    /// </summary>
    public static int UserCode_IfOfflineMode = 3;


    public static bool isDebugMode_CultureLand = true;

    /// <summary>
    /// 추가 시 1. 참조 확인하여 코딩 작업 (LoadDataMgr) 2. 에디터 메타에 에셋번들 설정. 3. EnumPatchFile, Version_PatchFile, Name_OfPatchFile 에 아이템 추가
    /// </summary>
    public enum EnumPatchFile
    {
        GoogleDataTable,
        Object,
        UI,
        Sprite,
        Sound,
        //C00_finn_basic,
        //C01_jake_basic,
        //C02_bubblegum_basic,
        //C03_bubblegum_costume_01,
        //C04_bubblegum_costume_02,
        //C05_jake_costume_01,
        //C06_jake_costume_02,
        //C07_finn_costume_01,
        //C08_finn_costume_02,
        //C09_iceking_basic,
    }

#if UNITY_IPHONE
    /// <summary>
    /// client 버전을 integer로 표현. dbbase 버전 (intDBBaseVersion) 에도 사용된다.
    /// </summary>
    public static int Version_Client = 4;
    static int MajorVersion_Client = 1;
    public static int[] Version_PatchFile = 
    {
          16    //GoogleDataTable     
        , 1     //Object
        , 1     //UI
        , 1     //Sprite
        , 6     //Sound
            //,1  //00
            //,1  //01
            //,1  //02
            //,1  //03
            //,1  //04
            //,1  //05
            //,1  //06
            //,1  //07
            //,1  //08_finn_costume_02
            //,1  //09_iceking_basic
    };  
#else
    /// <summary>
    /// client 버전을 integer로 표현. dbbase 버전 (intDBBaseVersion) 에도 사용된다. 해당 번호를 올리면 꼭 patch build 를 해서 서버의 patch 폴더에 새로운 번호의 폴더가 만들어짐을 확인해야 된다.
    /// </summary>
    public static int Version_Client = 3;
    static int MajorVersion_Client = 1;
    public static int[] Version_PatchFile =
    {
          15     //GoogleDataTable     
        , 1     //Object
        , 1     //UI
        , 1     //Sprite
        , 3     //Sound
            //,1  //00
            //,1  //01
            //,1  //02
            //,1  //03
            //,1  //04
            //,1  //05
            //,1  //06
            //,1  //07
            //,1  //08_finn_costume_02
            //,1  //09_iceking_basic
    };
#endif

    static string GetClientVersionStr()
    {
        string Cliend_Version = "";

        if (Version_Client > 9)
            Cliend_Version = string.Format("{0:000}", Version_Client);
        else
            Cliend_Version = Version_Client.ToString();

        return Cliend_Version;
    }

 
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
    /// 값이 true일 경우 로그인 시 항상 온라인과 오프라인 버튼을 선택하게 함. false일 경우 한 번 선택하면 저장해둔 값으로 로그인 됨.
    /// </summary>
    public static bool AlwaysSelectGameModeWhetherOnlineOrOffline = false;

    /// <summary>
    /// 구글 독스 테이블(게임 데이터) 암호화 여부.
    /// </summary>
    public static bool isGoogleDocsEncrypted = true;
    public static bool isServerPacketEncrypted = true;

    public static string StageLoadingIndicatorName = "StageLoadingIndicator";
    public static string StageBlindName = "StageBlind";

    public static float MaxWaitingTime_ConnectPatchServer = 10f;

    public static float SendPacketToServer_DelayTime = 0.5f;

    public static string SerializeKey = "8ac0f0c039c77d2c3a97d2cd447237dc";
    public static string SerializeIV = "514365216be9a3cb6fbcfac1f888f6ba";

    public static int kakaoGetInvitableFriendLimitNumber = 50;

    public static bool isTableEncodedAsJson = true;
  
    public static bool WhetherLoadUIABWhenOutGameLoading = false;
    public static bool WhetherLoadObjectABWhenOutGameLoading = false;
    public static bool WhetherUseResourceScene = true;
    public static bool WhetherDeleteDocsTxtFileOfResourcesFolder = false;
    public static bool isAbleToPay = true;
    #endregion
}
