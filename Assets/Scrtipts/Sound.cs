using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    [SerializeField] private List<AudioClip> audioClipList; //사운드 리스트 저장

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    public void PlaySFX(string clipName)
    {
        AudioClip clip = audioClipList.Find(c => c.name == clipName); //이름으로 맞는 오디오 재생

        if (clip == null)
        {
            Debug.LogWarning($"SFX 클립 '{clipName}'을 찾을 수 없습니다!");
            return;
        }

        audioSource.PlayOneShot(clip);
    }
}
