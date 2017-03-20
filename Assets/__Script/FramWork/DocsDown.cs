using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class DocsDown : MonoBehaviour {

    public static bool IsEndDocsDown = false;

    public enum DocsNumber
    {
        Sound = 0,
        StoryUIDesine = 923849699,
        Talk = 1187662000,
        Max
    }

	// Use this for initialization
	void Start () {

#if UNITY_EDITOR
        DownroadDocsData();

#else
        if(PlayerPrefs.GetInt("DocsDown") == 0)
        {
            DownroadDocsData();
        }
#endif

    }

    void DownroadDocsData()
    {
        DownloadAndSave("1juWuj8kuhx4NCRtRgNP7ZPTZF4BqDfphJLENEYkACqo");
    }
	
    const string GoogleSheetBaseUrl = "https://docs.google.com/spreadsheet/pub?key={0}&single=true&output=csv&gid={1}";

    public void DownloadAndSave(string key)
    {
        System.Array values = System.Enum.GetValues(typeof(DocsNumber));

        foreach (DocsNumber val in values)
        {
            int id = (int)val;

            if (id == (int)DocsNumber.Max)
            {
                PlayerPrefs.SetInt("DocsDown", 1);
                IsEndDocsDown = true;
                return;
            }

            string url = string.Format(GoogleSheetBaseUrl, key, id);
            WWW www = new WWW(url);
            while (www.isDone == false) ;
            string path = string.Format("{0}/Resources/config/{1}.txt", Application.dataPath, id);

#if UNITY_EDITOR
            //CLog.Log(string.Format("###################### DownloadAndSave / id = {0} / www.text = {1}", id, www.text));
#endif

            string str = www.text;

            str = Utils.parseJson(str.Split(new char[] { '\n', '\r' }, System.StringSplitOptions.RemoveEmptyEntries));

            File.WriteAllText(path, str);

            DestroyImmediate(this);

        }

        IsEndDocsDown = true;

    }


}
