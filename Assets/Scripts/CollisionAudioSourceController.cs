using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionAudioSourceController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Play()
    {
        GetComponent<AudioSource>().Play();
    }

    public void DestroyAfterPlay()
    {
        StartCoroutine(_DestroyAfterPlay());
    }

    IEnumerator _DestroyAfterPlay()
    {
        Play();
        yield return new WaitForSeconds(GetComponent<AudioSource>().clip.length);
        Destroy(gameObject);
    }
}

