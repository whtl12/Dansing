using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupManager : _SceneManager {
    public enum PopupName
    {
        Start,
        MAX
    }

    PopupName NowPopupName;

    Stack PopupStack = new Stack();
    List<GameObject> AllPopupObj = new List<GameObject>();


    public static PopupManager instance;

	// Use this for initialization
	void Start () {
        instance = this;
        DontDestroyOnLoad(this);

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ClosePopup();
        }

    }

    public void OpenPopup(PopupName name)
    {
        GameObject openPopup = AllPopupObj.Find(item => item.name == name.ToString());

        if(openPopup != null)
        {
            PopupStack.Push(openPopup);
            openPopup.SetActive(true);
        }
       
    }

    public void ClosePopup()
    {
        GameObject closePopup = PopupStack.Pop() as GameObject;

        if(closePopup != null)
        {
            closePopup.SetActive(false);
        }
        else
        {
            if (NowScene == SceneName.InGame)
                StartCoroutine(SceneChangeInfoSet(SceneName.OutGame));
        }

    }

    public void AllClosePopup()
    {
        for(int i = 0; i < AllPopupObj.Count; i++)
        {
            AllPopupObj[i].SetActive(false);
            PopupStack.Clear();
        }
    }

   

    //씬이 전환될때마다 그씬에 있는 UI들을 등록해준다.
    void SetPopupObj()
    {
        AllPopupObj.Clear();
        for (PopupName i = PopupName.Start;  i < PopupName.MAX; i++)
        {
            GameObject obj = GameObject.Find(i.ToString());

            if (obj != null)
            {
                AllPopupObj.Add(obj);
            }
        }
        
    }

    void OnLevelWasLoaded(int level)
    {
        SetPopupObj();
    }



}
