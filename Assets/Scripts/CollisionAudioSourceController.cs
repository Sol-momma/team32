using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionAudioSourceController : MonoBehaviour
{
    private AudioSource audioSource;

    public void Initialize()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Play()
    {
        audioSource.Play();
    }

    public void DestroyAfterPlay()
    {
        StartCoroutine(DestroyAfterPlay_());
    }

    IEnumerator DestroyAfterPlay_()
    {
        Play();
        yield return new WaitForSeconds(audioSource.clip.length);
        Destroy(gameObject);
    }
}

