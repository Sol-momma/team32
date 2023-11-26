using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionParticleSystemController : MonoBehaviour
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
        GetComponent<ParticleSystem>().Play();
    }

    public void DestroyAfterPlay()
    {
        StartCoroutine(_DestroyAfterPlay());
    }

    public IEnumerator _DestroyAfterPlay()
    {
        Play();
        yield return new WaitForSeconds(GetComponent<ParticleSystem>().main.duration);
        Destroy(gameObject);
    }
}
