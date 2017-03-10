using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAssetBundle : MonoBehaviour {

    enum SoundName
    {
        Girl_s_dancing,
        cinema,
        MAX
    }

    // 번들 다운 받을 서버의 주소(필자는 임시방편으로 로컬 파일 경로 쓸 것임)
    string BundleURL;//= Application.dataPath + "/StreamingAssets";// "jar:file://" + Application.dataPath + "!/assets/bundle.unity3d";
    // 번들의 version
    public int version;

    void Start()
    {
        BundleURL = "file://" + Application.dataPath + "/StreamingAssets/sound";// "jar:file://" + Application.dataPath + "!/assets/bundle.unity3d";
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
            List<AudioClip> Audio = new List<AudioClip>();
            for(int i = 0; i < SoundLoad.Length; i++)
            {
                Audio.Add((AudioClip)SoundLoad[i]);
            }

            SoundManager.instance.m_AudioClip = Audio;

            bundle.Unload(false);

            www.Dispose();

         

        }
    }

}
