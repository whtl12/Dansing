using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LoadAssetBundle : MonoBehaviour {


    // 번들 다운 받을 서버의 주소(필자는 임시방편으로 로컬 파일 경로 쓸 것임)
    string BundleURL;//= Application.dataPath + "/StreamingAssets";// "jar:file://" + Application.dataPath + "!/assets/bundle.unity3d";
    // 번들의 version
    public int version;

    void Start()
    {
#if UNITY_EDITOR
        BundleURL = "file://" + Application.dataPath + "/StreamingAssets/sound";//
#else
        "jar:file://" + Application.dataPath + "!/StreamingAssets/sound.unity3d";// "jar:file://" + Application.dataPath + "!/assets/bundle.unity3d";
#endif
        StartCoroutine(LoadBundles());
    }

    IEnumerator LoadBundles()
    {
        while (!Caching.ready)
            yield return null;
        using (WWW www = WWW.LoadFromCacheOrDownload(BundleURL, version))
        {
            yield return www;
            if (www.error != null)
                Debug.Log("WWW 다운로드에 에러가 생겼습니다.:" + www.error);

            AssetBundle bundle = www.assetBundle;

            Object[] SoundLoad = bundle.LoadAllAssets();
            Dictionary<SoundManager.SoundName,AudioClip> Audio = new Dictionary<SoundManager.SoundName, AudioClip>();
            for(int i = 0; i < SoundLoad.Length; i++)
            {
                AudioClip audio = (AudioClip)SoundLoad[i];

                SoundManager.SoundName name = SoundManager.SoundName.MAX;
                if (Utils.IsEnumParseName(typeof(SoundManager.SoundName), audio.name))
                    name = (SoundManager.SoundName)System.Enum.Parse(typeof(SoundManager.SoundName), audio.name);
                else
                    name = SoundManager.SoundName.MAX;

                if (name != SoundManager.SoundName.MAX)
                    Audio.Add(name, audio);
                else
                    Debug.LogError("SoundName Error! => " + audio.name);
            }

            SoundManager.instance.m_AudioClip = Audio;

            bundle.Unload(false);

            www.Dispose();
            GameDefine.IsLoadAssetBundleOK = true;



        }
    }

}
