using UnityEngine;
using System.Collections;

public partial class GameDefine : MonoBehaviour
{



    #region semifixed


    public static bool IsLoadAssetBundleOK = false;
    public static bool IsLoadDataDocs = false;


  

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
