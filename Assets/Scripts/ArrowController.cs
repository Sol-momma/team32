using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;

public class ArrowController : MonoBehaviour
{
    private Vector3 initial_position;
    private System.Action<GameObject> Release;
    private ParticleSystem collisionParticleSystem;
    private AudioSource collisionSound;
    private System.Action<int> AddScore;
    private new Rigidbody rigidbody;
    private System.Action<ParticleSystem> ReleaseParticleSystem;
    private System.Action<AudioSource> ReleaseAudioSource;

    public void Initialize(
        System.Action<GameObject> Release,
        System.Action<int> AddScore,
        ParticleSystem particleSystem,
        System.Action<ParticleSystem> ReleaseParticleSystem,
        AudioSource audioSource,
        System.Action<AudioSource> ReleaseAudioSource)
    {
        rigidbody = GetComponent<Rigidbody>();
        initial_position = gameObject.transform.position;
        this.Release = Release;
        this.AddScore = AddScore;
        collisionParticleSystem = particleSystem;
        collisionSound = audioSource;
        this.ReleaseParticleSystem = ReleaseParticleSystem;
        this.ReleaseAudioSource = ReleaseAudioSource;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x > 1000f || gameObject.transform.position.z > 1000f || gameObject.transform.position.y < 10f)
        {
            Release(gameObject);
            ReleaseParticleSystem(collisionParticleSystem);
            ReleaseAudioSource(collisionSound);
        }
    }

    public void Shoot(Vector3 direction)
    {
        rigidbody.isKinematic = true;
        rigidbody.isKinematic = false;
        rigidbody.AddForce(direction);
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            var score = (int)((1000 - (gameObject.transform.position - initial_position).magnitude) / 10);
            if (score < 0)
            {
                score = 1;
            }
            AddScore(score);

            PlayParticleSystemOnCollision();
            PlaySoundOnCollision();
            Release(gameObject);
        }
    }

    void PlayParticleSystemOnCollision()
    {
        collisionParticleSystem.transform.position = gameObject.transform.position;
        var collisionParticleSystemController = collisionParticleSystem.GetComponent<CollisionParticleSystemController>();
        collisionParticleSystemController.Initialize((collisionParticleSystem) => ReleaseParticleSystem(collisionParticleSystem));
        collisionParticleSystemController.ReleaseAfterPlay();
    }

    void PlaySoundOnCollision()
    {
        collisionSound.transform.position = gameObject.transform.position;
        var collisionAudioSourceController = collisionSound.GetComponent<CollisionAudioSourceController>();
        collisionAudioSourceController.Initialize((collisionSound) => ReleaseAudioSource(collisionSound));
        collisionAudioSourceController.ReleaseAfterPlay();
    }
}
