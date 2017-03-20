using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour {

    //지금 사용하지는 않음. 독스로 이름 다들고와서.. 플레이할떄 이름 필요할테니 일단...
    public enum SoundName
    {
        Girl_s_dancing,
        cinema,
        MAX
    }

    public static SoundManager instance;

    public Dictionary<SoundName, AudioClip> m_AudioClip;

    // Use this for initialization
    void Awake () {
        instance = this;
        DontDestroyOnLoad(this);

    }
    //2d 사운드는 Blend 0 / 3d 사운드는 Bland 1 spatialBlend
    public void PlaySound(SoundInfo soundInfo, float _fSpecificVolume, float _fDelay, float _pitch)
    {
        if (soundInfo != null)
        {
            GameObject obj = GameObject.Find("SoundPlay");

            if (obj == null)
                obj = new GameObject("SoundPlay");

            obj.AddComponent<AudioSource>();

            AudioSource audioSource = obj.GetComponent<AudioSource>();

            AudioClip playClip = new AudioClip();

            foreach (KeyValuePair<SoundName,AudioClip> audio in m_AudioClip)
            {
                if (soundInfo.Name == audio.Key)
                {
                    if (!audioSource.isPlaying)
                    {
                        audioSource.clip = audio.Value;
                        audioSource.volume = _fSpecificVolume;
                        audioSource.pitch = _pitch;
                        audioSource.PlayDelayed(_fDelay);

                        return;
                    }

                    playClip = audio.Value;
                    break;

                }
            }

            GameObject newobj = new GameObject("newSoundPlay");
            newobj.AddComponent<AudioSource>();

            AudioSource newAudio = newobj.GetComponent<AudioSource>();
            newAudio.clip = playClip;
            newAudio.pitch = _pitch;
            newAudio.volume = _fSpecificVolume;
            newAudio.PlayDelayed(_fDelay);
            // 딜레이 + 플레이시간 + 2초의 여유후에 오브젝트 삭제.
  
            StartCoroutine(CheckObj(_fDelay + playClip.length + 2f, newAudio));

        }
        else
            Debug.LogError("SoundInfo == NULL");
    }



    private IEnumerator CheckObj(float checkTime, AudioSource AC)
    {
        yield return new WaitForSeconds(checkTime);
        Object.DestroyImmediate(AC.gameObject, true);
    }

}
