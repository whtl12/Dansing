using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
#region Data CSV

public class SoundSCV
{
    public string Mode;
    public string Name;
    public int Step;
}

public class StoryUIDesineCSV
{
    public string Stage;
    public int Step;
    public string Desc_Korea;
    public string Desc_Eng;
    public int End;
    public string Icon;

}

public class TalkCSV {
    public string Stage;
    public string Character;
    public int Number;
    public string Start;
    public string End;
}

public class StageMapSettingCSV
{
    public string Type;
    public string Name;
    public int index;
    public string Stage;
}


#endregion


#region Data

public class SoundInfo
{
    public enum SoundMode {
        None,
        Story,
        Nomal,
        BGM,
        Effect
    }

    public SoundMode Mode;
    public SoundManager.SoundName Name;
    public int Step;

    public SoundInfo(SoundSCV csv)
    {
        if (Utils.IsEnumParseName(typeof(SoundMode), csv.Mode))
            Mode = (SoundMode)Enum.Parse(typeof(SoundMode), csv.Mode);
        else
            Mode = SoundMode.None;

        if (Utils.IsEnumParseName(typeof(SoundManager.SoundName), csv.Name))
            Name = (SoundManager.SoundName)Enum.Parse(typeof(SoundManager.SoundName), csv.Name);
        else
            Name = SoundManager.SoundName.MAX;

        Step = csv.Step;
    }
}

public class StoryUIDesineInfo
{
    public DataMgr.Stage Stage; // 큰장 1장, 2장...
    public int Step;
    public string Desc_Korea;
    public string Desc_Eng;
    public bool IsEnd;
    public string Icon;

    public StoryUIDesineInfo(StoryUIDesineCSV csv)
    {
        if (Utils.IsEnumParseName(typeof(DataMgr.Stage), csv.Stage))
            Stage = (DataMgr.Stage)Enum.Parse(typeof(DataMgr.Stage), csv.Stage);
        else
            Stage = DataMgr.Stage.Tutorial;
        Step = csv.Step;
        Desc_Korea = csv.Desc_Korea;
        Desc_Eng = csv.Desc_Eng;
        IsEnd = csv.End == 0 ? false : true;
        Icon = csv.Icon;
    }
}

public class TalkInfo {
    public DataMgr.Stage Stage;
    public string Character;
    public int Number;
    public string Start;
    public string End;

    public TalkInfo(TalkCSV csv)
    {
        if (Utils.IsEnumParseName(typeof(DataMgr.Stage), csv.Stage))
            Stage = (DataMgr.Stage)Enum.Parse(typeof(DataMgr.Stage), csv.Stage);
        else
            Stage = DataMgr.Stage.Tutorial;
        Character = csv.Character;
        Number = csv.Number;
        Start = csv.Start;
        End = csv.End;
    }
}

public class StageMapSettingInfo
{
    public enum MapType
    {
        Load,
        House,
        None
    }

    public MapType Type;
    public string Name;
    public int index;
    public DataMgr.Stage Stage;

    public StageMapSettingInfo(StageMapSettingCSV csv)
    {
        if (Utils.IsEnumParseName(typeof(DataMgr.Stage), csv.Stage))
            Stage = (DataMgr.Stage)Enum.Parse(typeof(DataMgr.Stage), csv.Stage);
        else
            Stage = DataMgr.Stage.Tutorial;

        Name = csv.Name;
        index = csv.index;

        if (Utils.IsEnumParseName(typeof(MapType), csv.Type))
            Type = (MapType)Enum.Parse(typeof(MapType), csv.Type);
        else
            Type = MapType.None;

    }
}
#endregion


public class DataMgr : MonoBehaviour {

    public enum Stage
    {
        Tutorial,
        Mode1,
        Mode2,
        Mode3,
        Mode4
    }

    public static DataMgr instance;

    private List<SoundInfo> m_SoundTable = new List<SoundInfo>();
    private List<StoryUIDesineInfo> m_StoryUIDesineTable = new List<StoryUIDesineInfo>();
    private List<TalkInfo> m_TalkTable = new List<TalkInfo>();
    private List<StageMapSettingInfo> m_StageMapSettingTable = new List<StageMapSettingInfo>();

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
                    m_SoundTable.Add(data);
                }
               // GameDefine.IsLoadAssetBundleOK = true;
            }

        });

        WWWData.RequestReadFromGoogleDrive((int)DocsDown.DocsNumber.StoryUIDesine, (WWWData docs) =>
        {
            StoryUIDesineCSV[] infos = Utils.GetInstance_Docs<StoryUIDesineCSV[]>(docs.Lines);
            if (infos.Length > 0)
            {
                for (int i = 0; i < infos.Length; i++)
                {
                    StoryUIDesineInfo data = new StoryUIDesineInfo(infos[i]);
                    m_StoryUIDesineTable.Add(data);
                }
              //  GameDefine.IsLoadDataDocs = true;
            }

        });

        WWWData.RequestReadFromGoogleDrive((int)DocsDown.DocsNumber.Talk, (WWWData docs) =>
        {
            TalkCSV[] infos = Utils.GetInstance_Docs<TalkCSV[]>(docs.Lines);
            if (infos.Length > 0)
            {
                for (int i = 0; i < infos.Length; i++)
                {
                    TalkInfo data = new TalkInfo(infos[i]);
                    m_TalkTable.Add(data);
                }
               // GameDefine.IsLoadDataDocs = true;
            }

        });

        WWWData.RequestReadFromGoogleDrive((int)DocsDown.DocsNumber.StageMapSetting, (WWWData docs) =>
        {
            StageMapSettingCSV[] infos = Utils.GetInstance_Docs<StageMapSettingCSV[]>(docs.Lines);
            if (infos.Length > 0)
            {
                for (int i = 0; i < infos.Length; i++)
                {
                    StageMapSettingInfo data = new StageMapSettingInfo(infos[i]);
                    m_StageMapSettingTable.Add(data);
                }
                GameDefine.IsLoadDataDocs = true;
            }

        });
    }


    //얻어갈 값이 있으면 여기서 함수 만들어서 들고가기
}
