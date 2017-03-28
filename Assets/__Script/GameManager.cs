using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    private DataMgr.Stage NowStage = DataMgr.Stage.Tutorial;

	// Use this for initialization
	void Awake () {
        instance = this;
        DontDestroyOnLoad(this);
    }



    public DataMgr.Stage GetSaveStage()
    {
        string mode = PlayerPrefs.GetString("SaveStage");
        DataMgr.Stage stage = DataMgr.Stage.Tutorial;

        if (Utils.IsEnumParseName(typeof(DataMgr.Stage), mode))
            stage = (DataMgr.Stage)Enum.Parse(typeof(DataMgr.Stage), mode);
        else
            stage = DataMgr.Stage.Tutorial;

        return stage;
    }

    public void SetSaveStage(DataMgr.Stage stage)
    {
        NowStage = stage;
        PlayerPrefs.SetString("SaveStage", stage.ToString());
    }
	

}
