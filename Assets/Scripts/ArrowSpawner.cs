using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ArrowSpawner : MonoBehaviour
{
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private ParticleSystem collisionParticleSystemPrefab;
    [SerializeField] private AudioSource collisionSoundPrefab;
    private bool canShoot = true;
    private AudioSource shootArrow;
    private System.Action<int> AddScore;
    private ObjectPool<GameObject> arrowPool;
    private ObjectPool<ParticleSystem> collisionParticleSystemPool;
    private ObjectPool<AudioSource> collisionSoundPool;
    // Start is called before the first frame update
    void Start()
    {
        shootArrow = GetComponent<AudioSource>();
    }

    public void Initialize(System.Action<int> AddScore)
    {
        this.AddScore = AddScore;
        arrowPool = new ObjectPool<GameObject>(
            createFunc: () => Instantiate(arrowPrefab, new Vector3(0, 20, 0), Quaternion.identity),
            actionOnGet: (arrow) => arrow.SetActive(true),
            actionOnRelease: (arrow) => arrow.SetActive(false),
            actionOnDestroy: (arrow) => Destroy(arrow),
            defaultCapacity: 10,
            maxSize: 100);
        collisionParticleSystemPool = new ObjectPool<ParticleSystem>(
            createFunc: () => Instantiate(collisionParticleSystemPrefab),
            actionOnGet: (particleSystem) => particleSystem.gameObject.SetActive(true),
            actionOnRelease: (particleSystem) => particleSystem.gameObject.SetActive(false),
            actionOnDestroy: (particleSystem) => Destroy(particleSystem.gameObject),
            defaultCapacity: 10,
            maxSize: 100);
        collisionSoundPool = new ObjectPool<AudioSource>(
            createFunc: () => Instantiate(collisionSoundPrefab),
            actionOnGet: (audioSource) => audioSource.gameObject.SetActive(true),
            actionOnRelease: (audioSource) => audioSource.gameObject.SetActive(false),
            actionOnDestroy: (audioSource) => Destroy(audioSource.gameObject),
            defaultCapacity: 10,
            maxSize: 100);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject arrow = arrowPool.Get();
        arrow.transform.position = new Vector3(0, 20, 0);
        ParticleSystem collisionParticleSystem = collisionParticleSystemPool.Get();
        AudioSource collisionSound = collisionSoundPool.Get();
        var arrowController = arrow.GetComponent<ArrowController>();
        arrowController.Initialize(
            (arrow) => arrowPool.Release(arrow),
            AddScore,
            collisionParticleSystem,
            (particleSystem) => collisionParticleSystemPool.Release(particleSystem),
            collisionSound,
            (audioSource) => collisionSoundPool.Release(audioSource));

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 world_direction = ray.direction;

        arrow.transform.rotation = Quaternion.LookRotation(world_direction);
        arrow.transform.Rotate(0, 90, 0);
        arrowController.Shoot(world_direction.normalized * 20000f);

        canShoot = false;
        StartCoroutine(EnableShootingAfterSeconds(1f));

        shootArrow.pitch = Random.Range(0.8f, 1.2f);
        shootArrow.Play();
    }

    IEnumerator EnableShootingAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        canShoot = true;
    }

    public void ClearPool()
    {
        arrowPool.Clear();
        collisionParticleSystemPool.Clear();
        collisionSoundPool.Clear();
    }

    public void OnGameOver()
    {
        enabled = false;
    }

    public void OnRestart()
    {
        enabled = true;
    }
}
