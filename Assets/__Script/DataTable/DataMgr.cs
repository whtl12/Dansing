using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Data CSV

public class SoundSCV
{
    public string Mode;
    public string Name;
    public int Step;
}

#endregion


#region Data

public class SoundInfo
{
    public string Mode;
    public string Name;
    public int Step;

    public SoundInfo(SoundSCV csv)
    {
        Mode = csv.Mode;
        Name = csv.Name;
        Step = csv.Step;
    }
}


#endregion


public class DataMgr : MonoBehaviour {

    public static DataMgr instance;

    private List<SoundInfo> m_soundTable = new List<SoundInfo>();

    // Use this for initialization
    void Awake () {
        instance = this;
        LoadData();
        DontDestroyOnLoad(this);
    }

    void LoadData()
    {
        // 독스가 생기면 추가해 줘야됨.
        WWWData.RequestReadFromGoogleDrive((int)DocsDown.DocsNumber.Sound, (WWWData docs) =>
        {
            SoundSCV[] infos = Utils.GetInstance_Docs<SoundSCV[]>(docs.Lines);
            if (infos.Length > 0)
            {
                //m_tutorialTable = SetTutorialData(infos);

                for(int i = 0; i < infos.Length; i++)
                {
                    SoundInfo data = new SoundInfo(infos[i]);
                    m_soundTable.Add(data);
                }
                GameDefine.IsLoadAssetBundleOK = true;
            }

        });
    }


    //얻어갈 값이 있으면 여기서 함수 만들어서 들고가기
}
