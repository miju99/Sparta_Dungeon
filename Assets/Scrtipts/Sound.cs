using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    [SerializeField] private List<AudioClip> audioClipList;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    public void PlaySFX(string clipName)
    {
        AudioClip clip = audioClipList.Find(c => c.name == clipName);
        if (clip == null)
        {
            Debug.LogWarning($"SFX Ŭ�� '{clipName}'�� ã�� �� �����ϴ�!");
            return;
        }

        audioSource.PlayOneShot(clip);
    }
}
