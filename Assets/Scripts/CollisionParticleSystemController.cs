using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionParticleSystemController : MonoBehaviour
{
    private new ParticleSystem particleSystem;
    private System.Action<ParticleSystem> Release;

    public void Initialize(System.Action<ParticleSystem> Release)
    {
        particleSystem = GetComponent<ParticleSystem>();
        this.Release = Release;
    }

    void Play()
    {
        particleSystem.Play();
    }

    public void ReleaseAfterPlay()
    {
        StartCoroutine(ReleaseAfterPlay_());
    }

    public IEnumerator ReleaseAfterPlay_()
    {
        Play();
        yield return new WaitForSeconds(particleSystem.main.duration);
        Release(particleSystem);
    }
}
