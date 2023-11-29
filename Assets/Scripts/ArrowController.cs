using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowController : MonoBehaviour
{
    private Vector3 initial_position;
    [SerializeField] private ParticleSystem collisionParticleSystemPrefab;
    [SerializeField] private AudioSource collisionSoundPrefab;
    private System.Action<int> AddScore;
    private new Rigidbody rigidbody;

    public void Initialize(System.Action<int> AddScore)
    {
        this.AddScore = AddScore;
        rigidbody = GetComponent<Rigidbody>();
        initial_position = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x > 1000f || gameObject.transform.position.z > 1000f || gameObject.transform.position.y < 10f)
        {
            Destroy(gameObject);
        }
    }

    public void Shoot(Vector3 direction)
    {
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
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }

    void PlayParticleSystemOnCollision()
    {
        var collisionParticleSystem = Instantiate(collisionParticleSystemPrefab, gameObject.transform.position, Quaternion.identity);
        var collisionParticleSystemController = collisionParticleSystem.GetComponent<CollisionParticleSystemController>();
        collisionParticleSystemController.Initialize();
        collisionParticleSystemController.DestroyAfterPlay();
    }

    void PlaySoundOnCollision()
    {
        var collisionSound = Instantiate(collisionSoundPrefab, gameObject.transform.position, Quaternion.identity);
        var collisionAudioSourceController = collisionSound.GetComponent<CollisionAudioSourceController>();
        collisionAudioSourceController.Initialize();
        collisionAudioSourceController.DestroyAfterPlay();
    }
}
