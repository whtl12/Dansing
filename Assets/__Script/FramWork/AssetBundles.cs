

#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

public class AssetBundles : Editor {
    
    [MenuItem("Assets/BuildBundle")]
    static void BuidBundle()
    {
        BuildPipeline.BuildAssetBundles("Assets/StreamingAssets", BuildAssetBundleOptions.None, BuildTarget.Android);
    }
}

#endif
