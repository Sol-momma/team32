using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionAudioSourceController : MonoBehaviour
{
    private AudioSource audioSource;
    private System.Action<AudioSource> Release;

    public void Initialize(System.Action<AudioSource> Release)
    {
        this.Release = Release;
        audioSource = GetComponent<AudioSource>();
    }

    void Play()
    {
        audioSource.Play();
    }

    public void ReleaseAfterPlay()
    {
        StartCoroutine(ReleaseAfterPlay_());
    }

    IEnumerator ReleaseAfterPlay_()
    {
        Play();
        yield return new WaitForSeconds(audioSource.clip.length);
        Release(audioSource);
    }
}
