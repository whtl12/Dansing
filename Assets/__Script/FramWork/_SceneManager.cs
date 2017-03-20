using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class _SceneManager : MonoBehaviour {

    public enum SceneName
    {
        Intro,
        InGame,
        OutGame,
        Loading,
        MAX
    }


    void Start()
    {
        DontDestroyOnLoad(this);
        StartCoroutine( FirstStartGame());
    }

    protected SceneName NowScene{
        get{
            for(SceneName i = SceneName.Intro; i < SceneName.MAX; i++)
            {
                if (SceneManager.GetActiveScene().name == i.ToString())
                    return i;
            }

            return SceneName.Intro;
        }
    }

    protected void ChangeScene(SceneName name)
    {
        SceneManager.LoadScene(name.ToString());
    }

    public IEnumerator SceneChangeInfoSet(SceneName name)
    {
        ChangeScene(SceneName.Loading);
        //씬 전환 하면서 정보 셋팅할 꺼 있으면 여기에..

        yield return new WaitForSeconds(1.0f);

        ChangeScene(name);
        
    }

    IEnumerator FirstStartGame()
    {
        //Splash 진행중.

        while (!DocsDown.IsEndDocsDown)
        {
            yield return null;
        }

        yield return new WaitForSeconds(2.0f);

        ChangeScene( SceneName.Intro);

        while (!GameDefine.IsLoadDataDocs || !GameDefine.IsLoadAssetBundleOK)
        {
            yield return null;
        }

        ChangeScene(SceneName.OutGame);
    }

   

}
