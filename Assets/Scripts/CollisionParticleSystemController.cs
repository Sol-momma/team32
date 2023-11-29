using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionParticleSystemController : MonoBehaviour
{
    private new ParticleSystem particleSystem;

    public void Initialize()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    void Play()
    {
        particleSystem.Play();
    }

    public void DestroyAfterPlay()
    {
        StartCoroutine(DestroyAfterPlay_());
    }

    public IEnumerator DestroyAfterPlay_()
    {
        Play();
        yield return new WaitForSeconds(particleSystem.main.duration);
        Destroy(gameObject);
    }
}
