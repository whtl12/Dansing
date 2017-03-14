using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour {

    public static SoundManager instance;

    public Dictionary<string,AudioClip> m_AudioClip;

    // Use this for initialization
    void Awake () {
        instance = this;
        DontDestroyOnLoad(this);

    }
	

}
